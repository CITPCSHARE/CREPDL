module CREPDL.Char


open System.Text
open System.Text.RegularExpressions;
open Basics
open ThreeValuedBoolean

let checkCharAgainstChar (ch: char) (kernel:Regex option) (hull:Regex option) (minUV, maxUV): threeValuedBoolean =
    let checkReg (reg:Regex) =
        reg.Match(ch.ToString()).Success
    match (kernel, hull) with
    | None, None -> failwith "cannot happen"
    | Some(kregex), None  -> if checkReg kregex then True else Unknown
    | None, Some(hregex) -> if checkReg hregex then Unknown else False
    | Some(kregex), Some(hregex) ->
        if checkReg kregex then True 
        else if not(checkReg hregex) then False
        else Unknown;; 