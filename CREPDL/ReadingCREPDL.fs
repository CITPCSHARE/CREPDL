module CREPDL.ReadingCREPDL

open System;
open System.IO;
open System.Xml.Linq;

open Basics
open ActivePattern

[<Literal>]
let readOneCREPDLWithMemoCount = 100

let readOneCREPDL (absUri: Uri): XElement =
    try
        let doc = XDocument.Load(absUri.ToString(), LoadOptions.SetBaseUri)
        doc.Root
    with
        | :? FileNotFoundException as e ->
            failwith ("file not found: " + absUri.ToString())

let readOneCREPDLWithMemo: Uri-> XElement =
            memoize (fun uri -> readOneCREPDL uri) readOneCREPDLWithMemoCount

let readOneCREPDLFromString (schemaString: string): XElement =
    XDocument.Parse(schemaString).Root

let readOneCREPDLFromStringWithMemo: string -> XElement =
    memoize (fun str -> readOneCREPDLFromString str) readOneCREPDLWithMemoCount


let checkModeConsistency (crepdl: XElement): unit =
    let rec help (parentMode: mode) (crepdl: XElement): unit =
        match crepdl with
        | Union(Some(md),_, _, children) 
        | Intersection(Some(md),_, _, children) 
        | Difference(Some(md),_, _, children)
            -> if parentMode = md then
                    List.iter (help md) children
                else failwith  "Different mode";
        | Union(None,_, _, children) 
        | Intersection(None,_, _, children) 
        | Difference(None,_, _, children)
            -> List.iter (help parentMode) children

        | Repertoire(Some(md),_, _, _) | Char(Some(md),_, _, _, _) 
            -> if parentMode <> md then failwith "Different mode"
        | Repertoire(None,_, _, _) | Char(None,_, _, _, _) 
            ->  ()
                 
        | GraphemeCluster(Some(md),_, _, _, _) 
            -> if parentMode <> md then
                    failwith "Different mode"
                elif md = CharacterMode then
                    failwith "GraphemeCluster is unusable in the character mode"
        | GraphemeCluster(None,_, _, _, _)
            ->  if parentMode = CharacterMode then
                    failwith "GraphemeCluster is unusable in the character mode"

        | Ref(Some(md), _, _,absUri) ->  
             if parentMode <> md then failwith "Different mode"
             else help parentMode (readOneCREPDLWithMemo absUri) 
            
        | Ref(None, _, _,absUri) ->  
            help parentMode (readOneCREPDLWithMemo absUri) 
    help (getRootMode crepdl) crepdl;;


let readAndCheckSchema (schemaUri: string) : XElement =
     
    let rec dagCheck (parents: List<XElement>) (crepdl: XElement) : bool =
        if List.exists (fun x -> x = crepdl) parents then false
        else
        match crepdl with
        | Union(_,_,_, children) | Intersection(_,_,_, children) | Difference(_,_,_, children)
            -> List.forall (dagCheck (crepdl::parents)) children
        | Repertoire(_,_, _, _) | Char(_,_, _, _, _) | GraphemeCluster(_,_, _, _, _) -> true
        | Ref(_,_, _,absUri) -> dagCheck (crepdl::parents) (readOneCREPDLWithMemo absUri)


    let schema = readOneCREPDLWithMemo (createUri schemaUri)

    if not(dagCheck [] schema) then failwith "Loop caused by ref elements"
    else  checkModeConsistency schema ; schema
     