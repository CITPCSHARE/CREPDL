module CREPDL.RepertoireCollection

open System
open System.Text
open System.IO
open Basics
open RBT
open Dewey
open ThreeValuedBoolean
open Registry
open Repertoire
open Token
open ISO10646Collection
open  System.Collections.Generic


type RepertoireCollection = int option -> string option -> Lazy<Repertoire>



     
let createRepertoireCollection inLineCol outOfLineCol 
        (repOfCol: IDictionary<int, RepresentationType>): RepertoireCollection =            
    let numberDict = 
        Dictionary<int, Lazy<Repertoire>>()
    let nameDict = 
        Dictionary<string, Lazy<Repertoire>>()
    let addRepertoir index name (rc: Lazy<Repertoire>) =
        numberDict.Add(index, rc)
        if name<>"" then nameDict.Add(name, rc)

    let unifiedCollections =
        List.append
            (List.map
                (fun (num, name, str) -> 
                    let repType = 
                        match repOfCol.TryGetValue num with 
                        | (true, repType) -> repType
                        | _ -> RBT
                    let tr = lazy (new StringReader(str) :> TextReader)
                    (num, name, tr, repType)) 
                inLineCol)
            (List.map
                (fun (num, name, filename) -> 
                    let repType = 
                        match repOfCol.TryGetValue num with 
                        | (true, repType) -> repType
                        | (false, _) -> Set
                    let tr = lazy (getStreamReaderForEmbeddedResource filename :> TextReader)
                    (num, name, tr, repType)) 
                outOfLineCol)

    let addRepertoires() =
        List.iter
            (fun (i, name, (tr: Lazy<TextReader>), repType) -> 
                let lazyRepoirtore = 
                    match repType with
                    | RBT -> lazy (createRBTRepertoire tr) 
                    | Dewey -> lazy (createDeweyRepertoire tr)
                    | Set -> lazy (createSetRepertoire tr)
                addRepertoir i name lazyRepoirtore)
            unifiedCollections

    let getRepertoire (collectionNumber: int option) (name: string option)  =
        match (name, collectionNumber) with
           | Some(nm), _ when nameDict.ContainsKey(nm) -> nameDict.[nm]
           | _, Some(cnum) when numberDict.ContainsKey(cnum) -> numberDict.[cnum]
           | _,_ -> failwith "Specify either a name or a number"
    
    addRepertoires()
    getRepertoire ;;
    

    
let checkCharAgainst10646Collection (tkn: token) (repCpl: RepertoireCollection) name  collectionNumber  version: threeValuedBoolean =
    let repertoire = repCpl  collectionNumber name
    let validator = repertoire.Force()
    if validator (getInt32FromToken tkn) then True else False
    
let checkCharAgainstCLDR  (tkn: token) name version: threeValuedBoolean =
    System.Console.WriteLine("CLDR is not supported yet")
    Unknown

let checkCharAgainstIANA (tkn: token) encName miBenum version: threeValuedBoolean =
    match encName, miBenum with
    | Some(strEncName: string), _ -> 
        try
            let enc = Encoding.GetEncoding(strEncName, new EncoderExceptionFallback(), 
                                                       new DecoderExceptionFallback())
            let chars = enc.GetChars(enc.GetBytes(getStringFromToken tkn))
            if chars.[0] = char (getInt32FromToken tkn) then True else False
        with | :? EncoderFallbackException -> False
             | :? System.ArgumentException -> 
                System.Console.WriteLine("The charset name \"" 
                                          + strEncName + " is not supported")
                Unknown
    | None, Some(num) -> 
        System.Console.WriteLine("miBenum is not supported")
        Unknown
    | _,_ -> failwith "Both number and name are missing"

let checkCharAgainstRepertoire (tkn: token) (repCpl: RepertoireCollection) (registry: Registry) 
                               (minUV, maxUV): threeValuedBoolean =
    match registry with
    | ISO10646(version, name, collectionNumber) -> 
        checkCharAgainst10646Collection tkn repCpl  name collectionNumber version
    | CLDR(version, name) -> checkCharAgainstCLDR tkn name version
    | IANA(version, name, mIBEnum)  -> 
        checkCharAgainstIANA tkn name mIBEnum version