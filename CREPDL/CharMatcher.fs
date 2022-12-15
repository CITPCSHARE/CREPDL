module CREPDL.CharMatcher
open Basics
open System.Text.RegularExpressions;
open ThreeValuedBoolean

let internal createReg (regStr: string): string =
    "^" + regStr + "$"

let internal checkStringAgainstChar (str: string) (kernel:string option) (hull:string option) flag (minUV, maxUV): ThreeValuedBoolean =
    let checkReg (regex :string) =
        Regex.IsMatch(str, regex)
    try 
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
            else Unknown
    with 
    | :? System.ArgumentException as e ->
        raise e;; 