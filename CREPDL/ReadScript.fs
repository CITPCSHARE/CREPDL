module CREPDL.ReadScript

open System;
open System.IO;
open System.Xml.Linq;

open Basics
open ActivePattern


let internal readScriptFromUri (absUri: Uri): XElement =
    try
        let doc = XDocument.Load(absUri.ToString(), LoadOptions.SetBaseUri)
        doc.Root
    with
        | :? FileNotFoundException as e ->
            failwith ("file not found: " + absUri.ToString())


let internal readScriptFromString (schemaString: string): XElement =
    XDocument.Parse(schemaString, LoadOptions.SetBaseUri).Root



