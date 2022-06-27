module 電子化文書の日本語レパートリー検証.Models.Toolkit
 
open CREPDL
open System.IO
open System
open System.Text

type ValidatorStruct =
    {CommonJapaneseValidator: CREPDLValidator; 
     JIS2004IdeographicsExtensionValidator: CREPDLValidator; 
     JapaneseNonIdeographicsExtensionValidator: CREPDLValidator}

let commonJapanese =
    @"<union xmlns=""http://purl.oclc.org/dsdl/crepdl/ns/structure/2.0"" mode=""graphemeCluster"">
        <repertoire
        registry=""10646"" number=""287""/>
       <char>[\n|\r|\t]|(\r\n)</char>
      </union>"

let jIS2004IdeographicsExtension =
    @"<repertoire xmlns=""http://purl.oclc.org/dsdl/crepdl/ns/structure/2.0"" mode=""graphemeCluster""
        registry=""10646"" number=""371""/>"

let japaneseNonIdeographicsExtension = 
    @"<repertoire xmlns=""http://purl.oclc.org/dsdl/crepdl/ns/structure/2.0"" mode=""graphemeCluster""
        registry=""10646"" number=""286""/>";

let createValidatorStruct() = 
    {CommonJapaneseValidator = 
        new CREPDLValidator(new StringReader(commonJapanese));
     JIS2004IdeographicsExtensionValidator =
        new CREPDLValidator(new StringReader(jIS2004IdeographicsExtension));
     JapaneseNonIdeographicsExtensionValidator =
        new CREPDLValidator(new StringReader(japaneseNonIdeographicsExtension))}

let printCharacter  (str: string) =
    let stw = new StringWriter()
    let mutable index = 0
    while index < str.Length do
        let i = Char.ConvertToUtf32(str, index)
        i.ToString("X4") |> fprintf stw "U+%s, "
        if i > 0xFFFF then index <- index + 2
        else index <- index + 1
    $"{str} ({stw.ToString().TrimEnd([|','; ' '|])})" 

let validateSingleFile (vs:ValidatorStruct)  (graphemeClusters: seq<string>) = 
    let sb = new StringBuilder() 
    let appendLine (s:string) = 
        sb.AppendLine(s) |> ignore
    for gc in graphemeClusters do
        if vs.CommonJapaneseValidator.validateGraphemeCluster(gc) 
          = CREPDLValidationResult.True then ()
        elif vs.JIS2004IdeographicsExtensionValidator.validateGraphemeCluster(gc) 
          = CREPDLValidationResult.True then appendLine $"JIS2004拡張漢字 {printCharacter gc}"
        elif vs.JapaneseNonIdeographicsExtensionValidator.validateGraphemeCluster(gc)
          = CREPDLValidationResult.True then appendLine $"拡張非漢字集合 {printCharacter gc}"
        else appendLine $"範囲外の文字 {printCharacter gc}"
    sb.ToString()

let validateMultipleFiles (vs:ValidatorStruct) 
      (pairsOfFileNameAndGraphemeClusters: seq<string * seq<string>>) = 
    let sb = new StringBuilder() 
    let appendLine (s:string) = 
        sb.AppendLine(s) |> ignore
    for (fileName, graphemeClusters) in pairsOfFileNameAndGraphemeClusters do
        appendLine fileName
        validateSingleFile vs graphemeClusters
        |> appendLine
    sb.ToString()

