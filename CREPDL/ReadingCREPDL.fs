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
        let root = doc.Root
        if root.Name.NamespaceName.Equals crepdlNamespace
          then root
          else failwith ("illegal namespace: " +  root.Name.NamespaceName)
    with
        | :? FileNotFoundException as e ->
            failwith ("file not found: " + absUri.ToString())

let readOneCREPDLWithMemo: Uri-> XElement =
            memoize (fun uri -> readOneCREPDL uri) readOneCREPDLWithMemoCount

let readAndCheckSchema (schemaUri: string) : XElement =
     
    let rec dagCheck (parents: List<XElement>) (crepdl: XElement) : bool =
        if List.exists (fun x -> x = crepdl) parents then false
        else
        match crepdl with
        | Union(_, _, children) | Intersection(_, _, children) | Difference(_, _, children)
            -> List.forall (dagCheck (crepdl::parents)) children
        | Repertoire(_, _, _) | Char(_, _, _, _)  -> true
        | Ref(_, _, absUri) -> dagCheck (crepdl::parents) (readOneCREPDLWithMemo absUri)
        | Illegal -> failwith ("syntax error: " + crepdl.Name.ToString())
         
    let schema = readOneCREPDLWithMemo (createUri schemaUri)
     
    if dagCheck [] schema
        then schema
        else failwith "Loop caused by ref elements"