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


type RepertoireCollection = int option -> string option -> Lazy<Repertoire>

let createRepertoireCollection rbtCol dCol : RepertoireCollection =            
    let numberDict = 
        System.Collections.Generic.Dictionary<int, Lazy<Repertoire>>()
    let nameDict = 
        System.Collections.Generic.Dictionary<string, Lazy<Repertoire>>()
    let addRepertoir index name (rc: Lazy<Repertoire>) =
        numberDict.Add(index, rc)
        if name<>"" then nameDict.Add(name, rc)
        ()
    let addRBTRepertoires() =
        List.iter
            (fun (i, name, str) -> 
                    let lazyRepoirtore = lazy (createRBTRepertoire str)
                    addRepertoir i name lazyRepoirtore)
            rbtCol
    let addDeweyRepertoires() =
        
        List.iter
            (fun (i, name, filename) ->
                let lazyRepoirtore = 
                    lazy (
                        createDeweyRepertoire (getStreamReaderForEmbeddedResource filename))
                addRepertoir i name lazyRepoirtore)
            dCol

    let getRepertoire (collectionNumber: int option) (name: string option)  =
        match (name, collectionNumber) with
           | Some(nm), _ when nameDict.ContainsKey(nm) -> nameDict.[nm]
           | _, Some(cnum) when numberDict.ContainsKey(cnum) -> numberDict.[cnum]
           | _,_ -> failwith "Specify either a name or a number"
    
    addRBTRepertoires()
    addDeweyRepertoires()
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