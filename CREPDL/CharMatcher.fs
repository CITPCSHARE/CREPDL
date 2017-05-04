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

let createRegV1 (regStr: string): Regex =
    if regStr.Length = 1 //Char or WildCardEsc
        || (regStr.StartsWith("[") && regStr.EndsWith("]")) //charClassExpr
        || (regStr.StartsWith("\\") && regStr.Length = 2) //SingleCharEsc or MultiCharEsc
        || (let chReg = new Regex("^\\\P{.+}$") 
            chReg.Match(regStr).Success) //catExc or complEsc  "\\P{[\{\}]+}"
        || (let chReg = new Regex("^\\\p{.+}$") 
            chReg.Match(regStr).Success) //catExc or complEsc  "\\p{[\{\}]+}"
//        || (let chReg = new Regex("\\\N{.+}") in chReg.Match(regStr).Success) //catExc or complEsc  "\\p{[\{\}]+}"
    then new Regex(regStr)
    else failwith  ("illegal regular expression: " +  regStr);

let createRegV2 (regStr: string) syntaxSugar: Regex =
    let x = if syntaxSugar then deSyntaxSugar regStr else regStr
    new Regex(x);

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