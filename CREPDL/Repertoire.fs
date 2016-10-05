module CREPDL.Repertoire

open System
open System.Text
open System.IO
open System.Reflection
open Basics
open RBT
open Dewey
open ThreeValuedBoolean

type Registry = 
  ISO10646 of string option * string option * int option
  | CLDR of string option * string option
  | IANA of  string option * string option * int  option
  | UNDEFINED of string
  
type Repertoire = char -> bool
    
let createDeweyRepertoire (sr: StreamReader)  =
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


let createRBTRepertoire (str: string) =

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
    
    
type RepertoireRegistory = int option -> string option -> Repertoire

let createRepertoireRepository rbtCol dCol: RepertoireRegistory =            
    let numberDict = 
        System.Collections.Generic.Dictionary<int, Repertoire>()
    let nameDict = 
        System.Collections.Generic.Dictionary<string, Repertoire>()
    let addRepertoir index name rc =
        numberDict.Add(index, rc)
        nameDict.Add(name, rc)
        ()
    let addRBTRepertoires() =
        List.iter
            (fun (i, name, str) -> 
                    addRepertoir i name (createRBTRepertoire str))
            rbtCol
    let addDeweyRepertoires() =
        let asm = Assembly.GetExecutingAssembly()
        let path = Path.GetDirectoryName(asm.Location)
        let pppath = (Directory.GetParent (path)).Name
        
        List.iter
            (fun (i, name, filename) ->
                let fn = Path.Combine(path, filename)
                let textStreamReader = 
                    new StreamReader(asm.GetManifestResourceStream(filename));
                addRepertoir i name (createDeweyRepertoire textStreamReader))
            dCol
    let getRepertoire (collectionNumber: int option) (name: string option)  =
        match (name, collectionNumber) with
           | Some(nm), _ when nameDict.ContainsKey(nm) -> nameDict.[nm]
           | _, Some(cnum) when numberDict.ContainsKey(cnum) -> numberDict.[cnum]
           | _,_ -> failwith "No such repertoires"  
    
    addRBTRepertoires()
    addDeweyRepertoires()
    getRepertoire ;;
    
    
let checkCharAgainst10646Collection char (rr: RepertoireRegistory) collectionNumber name version: threeValuedBoolean =
    let repertoire = rr name collectionNumber
    if repertoire char then True else False
    
let checkCharAgainstCLDR  charn name versio: threeValuedBoolean =
    System.Console.WriteLine("CLDR is not supported yet")
    Unknown
    
let checkCharAgainstIANA ch encName miBenum version: threeValuedBoolean =
    match encName, miBenum with
    | Some(strEncName: string), _ -> 
        try
            let enc = Encoding.GetEncoding(strEncName, new EncoderExceptionFallback(), 
                                                       new DecoderExceptionFallback())
            let chars = enc.GetChars(enc.GetBytes(string ch))
            if chars.[0] = ch then True else False
        with | :? EncoderFallbackException -> False
             | :? System.ArgumentException -> 
                System.Console.WriteLine("The charset name \"" 
                                          + strEncName + " is not supported")
                Unknown
    | None, Some(num) -> 
        System.Console.WriteLine("miBenum is not supported")
        Unknown
    | _,_ -> failwith "Both number and name are missing"

let checkCharAgainstRepertoire char (rr: RepertoireRegistory) (registry: Registry) 
                               (minUV, maxUV): threeValuedBoolean =
    match registry with
    | ISO10646(version, name, collectionNumber) -> 
        checkCharAgainst10646Collection char rr name collectionNumber version
    | CLDR(version, name) -> checkCharAgainstCLDR char name version
    | IANA(version, name, mIBEnum)  -> 
        checkCharAgainstIANA char name mIBEnum version
    | UNDEFINED(x) -> Unknown
