module 電子化文書の日本語レパートリー検証.Models.TextValidator

open System
open System.IO
open System.Web
open System.Globalization

open Toolkit

let getGraphemeClustersFromText (textStrm: Stream) = 
    use sr = new StreamReader(textStrm)
    let decodedText = sr.ReadToEnd()
    let tee = StringInfo.GetTextElementEnumerator(decodedText)
    seq{while tee.MoveNext() do yield tee.Current :?> String}

let validateTextFile (vs:ValidatorStruct) (htmlFileName: string) = 
    try
      use fs = new FileStream (htmlFileName, FileMode.Open)
      let gcs = getGraphemeClustersFromText fs
      validateSingleFile vs gcs
    with
      | :? System.Exception as e ->
            "Error: " + e.Message

