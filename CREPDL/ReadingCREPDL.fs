module CREPDL.ReadingCREPDL

open System;
open System.IO;
open System.Xml.Linq;

open Basics
open ActivePattern

[<Literal>]
let readOneCREPDLWithMemoCount = 100

let private testNamespace (node: XElement) =
   if node.Name.NamespaceName.Equals crepdlNamespace then () 
   else failwith ("illegal namespace: " +  node.Name.NamespaceName)
    
let readOneCREPDL (absUri: Uri): XElement =
    try
        let doc = XDocument.Load(absUri.ToString(), LoadOptions.SetBaseUri)
        let root = doc.Root
        testNamespace root
        root
    with
        | :? FileNotFoundException as e ->
            failwith ("file not found: " + absUri.ToString())

let readOneCREPDLWithMemo: Uri-> XElement =
            memoize (fun uri -> readOneCREPDL uri) readOneCREPDLWithMemoCount

let readOneCREPDLFromString (schemaString: string): XElement =
    let root = XDocument.Parse(schemaString).Root
    testNamespace root
    root

let readOneCREPDLFromStringWithMemo: string -> XElement =
    memoize (fun str -> readOneCREPDLFromString str) readOneCREPDLWithMemoCount

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