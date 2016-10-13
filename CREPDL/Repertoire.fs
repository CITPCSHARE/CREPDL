module CREPDL.Repertoire

open System
open System.Text
open System.IO
open System.Reflection
open Basics
open RBT
open Dewey
open ThreeValuedBoolean
open System.Xml.Linq;

  
type Repertoire = char -> bool

type RepertoireInCREPDL = string -> XElement
    
let createDeweyRepertoire (sr: StreamReader): Repertoire  =
    
    let pOrP = ref NotAllocated

    let rec readLines () =
        if sr.EndOfStream then []
        else
           sr.ReadLine()::readLines()

    let charList =  seq { for line in readLines() do
                            yield!
                                match line.Split(',') with
                                | [| s; e |] ->[(int s) .. (int e)]
                                | [| x |] -> if x.Length > 0 then [int x] else []
                                | _ -> failwith ("invalid line: " + line) 
                    }
        
    for ch in charList do
        pOrP := addPoint (!pOrP) (codeValue2RangeList ch)
    
    let checkUCSChar (ch: char) =
        checkPoint !pOrP (codeValue2RangeList (int ch))
                                 
    checkUCSChar;;


let createRBTRepertoire (str: string): Repertoire  =

    let createRange x y =
        if x <= y then (x, y)
        else failwith "incorrect range"

    let collectionRangeComparer (x1, x2) (y1, y2) =
        if x2 < y1 then -1
        else if y2 < x1 then 1
        else if x1 = y1 && x2 = y2 then 0
        else failwith "Non-disjoint ranges"
            
    let collectionRangeMemq (x1, x2) v =
        if x1 <= v && v <= x2 then 0
        else if x2 < v then -1 else 1
            
    let string2RangeList (str: string) =
        let lines = str.Split([|'\r'; '\n'|], StringSplitOptions.RemoveEmptyEntries)
        Array.fold
            (fun ls (line: string) -> 
                let range = match line.Split(',') with
                            | [| s; e |] -> createRange (int s) (int e)
                            | [| x |] -> let pint = int x in createRange pint pint
                            | _ -> failwith "invalid line"
                range::ls)
            [] lines

    let simplify rangeList =
        let rec simplify_help seed rl =
            match (seed, rl) with
            | ((ss, se), (s, e)::tail) ->
                if se + 1 = s then simplify_help (ss, e) tail
                else seed::(simplify_help (s, e) tail)
            | (_, []) -> [seed]
        List.tail (simplify_help (-1, -1) rangeList)
    
    let tree =
        let init = empty_explicit collectionRangeComparer collectionRangeMemq
        let rangeList = simplify (string2RangeList str)
        List.fold (fun tree r -> insert r tree) init rangeList

    let checkUCSChar (char: char) =
        match find (int char) tree with 
        | Some(t) -> true
        | None -> false
                                 
    checkUCSChar;;
    

let createCREPDLRepertoire (schemaString: string) = 
    XDocument.Parse( schemaString).Root