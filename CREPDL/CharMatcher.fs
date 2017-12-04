module CREPDL.CharMatcher
open System.Text.RegularExpressions;
open ThreeValuedBoolean
open Icu;

let private deSyntaxSugar str =
    let iter = BreakIterator.Split(BreakIterator.UBreakIteratorType.CHARACTER, Locale(), str)
    let mutable reverseList = []
    for gc in iter do
        if gc.Length = 1 then
            reverseList <- gc::reverseList
        else 
            reverseList <- ("(" + gc + ")")::reverseList
    List.fold (fun soFar y -> y+soFar) "" reverseList

let createReg (regStr: string): Regex =
    new Regex(regStr)

let checkStringAgainstChar (str: string) (kernel:Regex option) (hull:Regex option) flag (minUV, maxUV): ThreeValuedBoolean =
    let checkReg (reg:Regex) =
        let m = reg.Match(str)
        m.Success && m.Length = str.Length
    match kernel, hull, flag with
    | None, None, _ -> failwith "cannot happen"
    | Some(kregex), None, _  -> if checkReg kregex then True else Unknown
    | None, Some(hregex), _ -> if checkReg hregex then Unknown else False
    | Some(kregex), Some(hregex), true ->
        if checkReg kregex then True 
        else False
    | Some(kregex), Some(hregex), false ->
        if checkReg kregex then True 
        else if not(checkReg hregex) then False
        else Unknown;; 