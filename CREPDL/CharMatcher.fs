module CREPDL.CharMatcher
open Basics
open System.Text.RegularExpressions;
open ThreeValuedBoolean
open Icu;

let private deSyntaxSugar str =
    //This is to parenthesize any non-BMP character.
    let iter = BreakIterator.Split(BreakIterator.UBreakIteratorType.CHARACTER, Locale(), str)
    let mutable reverseList = []
    for gc in iter do
        if gc.Length = 1 then
            reverseList <- gc::reverseList
        else 
            reverseList <- ("(" + gc + ")")::reverseList
    List.fold (fun soFar y -> y+soFar) "" reverseList

let internal createRegexMatcher  =

    memoize (fun regStr -> 
                try
                    new RegexMatcher(regStr, RegexMatcher.URegexpFlag.COMMENTS)
                with
                | :? System.ArgumentException as ae 
                    -> raise ( System.ArgumentException (regStr + " is an illegal regular expression."))
                | e  ->  failwith (e.Message)
             ) 100

let internal createReg (regStr: string): Regex =
    new Regex(regStr)

let internal checkStringAgainstChar (str: string) (kernel:RegexMatcher option) (hull:RegexMatcher option) flag (minUV, maxUV): ThreeValuedBoolean =
    let checkReg (regexMatcher:RegexMatcher) =
        regexMatcher.Matches(str)
    match kernel, hull, flag with
    | None, None, _ -> failwith "cannot happen"
    | Some(kregex), None, _  -> if checkReg(kregex) then True else Unknown
    | None, Some(hregex), _ ->  if checkReg(hregex) then Unknown else False
    | Some(kregex), Some(hregex), true ->
        if checkReg kregex then True 
        else False
    | Some(kregex), Some(hregex), false ->
        if checkReg kregex then True 
        else if not(checkReg hregex) then False
        else Unknown;; 