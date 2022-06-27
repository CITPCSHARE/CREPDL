module 電子化文書の日本語レパートリー検証.Models.HtmlValidator

open HtmlAgilityPack
open System
open System.IO
open System.Web
open System.Globalization

open Toolkit

let getGraphemeClustersFromHtml (htmlStrm: Stream) = 
    let htmlDocument = new HtmlDocument()
    htmlDocument.Load(htmlStrm, Text.Encoding.UTF8)
    seq {for node in htmlDocument.DocumentNode.SelectNodes("//*/text()") do
            let decodedText = HttpUtility.HtmlDecode(node.InnerText)
            let tee = StringInfo.GetTextElementEnumerator(decodedText)
            yield! seq{while tee.MoveNext() do yield tee.Current :?> String}}

let validateHtmlFile (vs:ValidatorStruct) (htmlFileName: string) = 
    try
      use fs = new FileStream (htmlFileName, FileMode.Open)
      let gcs = getGraphemeClustersFromHtml fs
      validateSingleFile vs gcs
    with
      | :? System.Exception as e ->
            "Error: " + e.Message

