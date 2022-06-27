module 電子化文書の日本語レパートリー検証.Models.WmlValidator

open System
open CREPDL
open System.IO
open System.IO.Compression
open System.Text
open System.Web
open System.Xml
open System.Globalization
open Toolkit

let getGraphemeClustersFromWml wmlFileName =
    let zipFile = ZipFile.OpenRead(wmlFileName)
    seq {
        for entry in zipFile.Entries do
            if entry.FullName = "word/document.xml" then
                use stream = entry.Open()
                use reader = XmlReader.Create(stream)
                while reader.Read() do
                    if reader.NodeType = XmlNodeType.Text then
                       let txt = reader.Value  
                       let tee = StringInfo.GetTextElementEnumerator(txt)
                       yield! seq{while tee.MoveNext() do yield tee.Current :?> String}}
            

let validateWmlFile (vs:ValidatorStruct)  (wmlFileName: string) = 
    try
        let gcs = getGraphemeClustersFromWml wmlFileName
        validateSingleFile vs gcs
    with
      | :? System.Exception as e ->
            "Error: " + e.Message