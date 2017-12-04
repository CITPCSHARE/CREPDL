module CREPDL.Registry2Repertoire
open System.Xml
open System.Xml.Linq
open ActivePattern
open Registry
open Repertoire
open ReadScript
open ThreeValuedBoolean
open ISO10646Collection
open IVSChecker
open System.Collections.Generic
open System.Text
open System.IO

type RegistryRepertoireDictionary = Registry -> Repertoire

let generateRepertoireFromIANACharset encName miBenum: Repertoire =
    match encName, miBenum with
    | Some(strEncName: string), _ -> 
        try
            let enc = Encoding.GetEncoding(strEncName, new EncoderExceptionFallback(), 
                                                       new DecoderExceptionFallback())
             
            (fun str ->  
               try
                 if enc.GetString(enc.GetBytes str) = str then True else False
               with 
               | :? EncoderFallbackException
               | :? DecoderFallbackException -> False)
        with
             | :? System.ArgumentException -> 
                failwith ("The charset name " + strEncName + " is not supported.")
    | None, Some(num) -> 
        invalidArg  "miBenum is not supported"
    | _,_ -> failwith "Both number and name are missing"


let generateRepertoire (rgst: Registry) =
    match rgst with
    | ISO10646(name, number) -> 
        let textReader = generateRepertoireFromISOCollection  name number 
        createRepertoireFromTextReader textReader
    | CLDR(version, name)-> failwith"CLDR is not supported yet"
    | IANA(name, number)-> generateRepertoireFromIANACharset  name number 
    | IVD(name) -> generateRepertoireFromIVD name
  
let createRegistryRepertoireDictionary (crepdl: XElement): RegistryRepertoireDictionary =
    let dict = new Dictionary<Registry,Repertoire>()
    let rec scanRegistry  (crepdl: XElement): unit =
        match crepdl with
        | Union(_,_, _, children) 
        | Intersection(_,_, _, children) 
        | Difference(_,_, _, children)
        | Ref(_, _, _,_, children)  
            -> List.iter scanRegistry children

        | Repertoire(_,_, _, rgst) 
            -> if not(dict.ContainsKey(rgst)) then
                 let rep = generateRepertoire rgst
                 dict.[rgst] <- rep
                 
        | Char(_,_, _, _, _, _) 
            -> () 

    scanRegistry crepdl
    (fun rgst -> dict.[rgst])