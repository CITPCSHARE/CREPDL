module CREPDL.Repertoire

open System
open System.Text
open System.IO
open Basics
open RBT
open Dewey

type Repertoire = int32 -> bool

let private split (line: string) =
    match line.Split(',') with
    | [| s; e |] -> (int s, int e)
    | [| x |] -> (int x, int x)
    | _ -> failwith ("invalid line: " + line) 


let private endOfTextReader (tr:TextReader)=
    tr.Peek() = -1;;
//        match tr with 
//        | :? StreamReader as sr -> sr.EndOfStream
//        | :? StringReader as sr -> sr.Peek() = -1
//        | _ -> failwith "should not happen"

let private charList (tr:TextReader) =
    seq { while not(endOfTextReader tr) do
             let line = tr.ReadLine()
             yield!
                 let (s, e) = split line in [s .. e]  };;

let createSetRepertoire (tr: Lazy<TextReader>): Repertoire  =

    let allCodePoints = Set.ofSeq (charList (tr.Force()))
    
    let checkUCSChar (i: int32) = allCodePoints.Contains i
                       
    checkUCSChar;;

let createDeweyRepertoire (tr: Lazy<TextReader>): Repertoire  =
    
    let pOrP = ref NotAllocated

    for ch in charList (tr.Force()) do
        pOrP := addPoint (!pOrP) (codeValue2RangeList ch)
    
    let checkUCSChar (i: int32) =
        checkPoint !pOrP (codeValue2RangeList i)
                                 
    checkUCSChar;;


let createRBTRepertoire (tr: Lazy<TextReader>): Repertoire  =

    let createRange x y =
        if x <= y then (x, y)
        else failwith "incorrect range"

    let collectionRangeComparer (x1, x2) (y1, y2) =
        if x2 < y1 then -1
        else if y2 < x1 then 1
        else if x1 = y1 && x2 = y2 then 0
        else failwith "Non-disjoint ranges"
            
    let collectionRangeMemq (x1, x2) v =
        if x2 < v then -1
        elif v < x1 then 1
        else 0
            
    let string2RangeList (tr: TextReader) =
        seq { while not(endOfTextReader tr) do
                            let line = tr.ReadLine()
                            yield
                                let (s, e) = split line in createRange (int s) (int e) 
        } |> Seq.toList

    let simplify rangeList =
        let rec simplify_help seed rl simplifiedInvertedList =
            match (seed, rl) with
            | ((ss, se), (s, e)::tail) ->
                if se + 1 = s then simplify_help (ss, e) tail simplifiedInvertedList
                else simplify_help (s, e) tail (seed::simplifiedInvertedList)
            | (_, []) -> seed::simplifiedInvertedList
        List.tail (List.rev (simplify_help (-1, -1) rangeList []))
    
    let tree =
        let init = empty_explicit collectionRangeComparer collectionRangeMemq
        let rangeList = simplify (string2RangeList (tr.Force()))
        List.fold (fun tree r -> insert r tree) init rangeList

    let checkUCSChar (i: int32) =
        match find i tree with 
        | Some(t) -> true
        | None -> false
                                 
    checkUCSChar;;
    