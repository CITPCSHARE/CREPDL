module 電子化文書の日本語レパートリー検証.Models.EpubValidator

open System.IO.Compression
open HtmlValidator
open Toolkit

let getGraphemeClustersFromEPUBFile epubFileName = 
    let zipFile = ZipFile.OpenRead(epubFileName)
    seq {
        for entry in zipFile.Entries do
            if entry.Name.EndsWith(".xhtml") 
                || entry.Name.EndsWith(".html") 
                || entry.Name.EndsWith(".htm") then
                use stream = entry.Open()
                yield entry.Name, getGraphemeClustersFromHtml stream }

let validateEpubFile validators epubFileName = 
    try
        getGraphemeClustersFromEPUBFile epubFileName 
        |> validateMultipleFiles validators
    with
      | :? System.Exception as e ->
            "Error: " + e.Message
let validateEpubDirectory validators epubDiretoryName = 
    "Not implemented yet"
