module CREPDL.EPUBValidation
open System
open HtmlAgilityPack
open CREPDL
open System.IO
open System.IO.Compression
open System.Web

let private printCharacter (tw: TextWriter) (str: string) =
    let stw = new StringWriter()
    let mutable index = 0
    while index < str.Length do
        let i = Char.ConvertToUtf32(str, index)
        i.ToString("X4") |> fprintf stw "U+%s, "
        if i > 0xFFFF then index <- index + 2
        else index <- index + 1
    stw.ToString().TrimEnd([|','; ' '|]) |>
    fprintfn tw "%s (%s)" str

let public scanZip (tw: TextWriter) (filePath: string) (validator: CREPDLValidator) = 
    let zipFile = ZipFile.OpenRead(filePath)
    tw.WriteLine("UnZipping")
    for entry in zipFile.Entries do
        if entry.Name.EndsWith(".xhtml") 
            || entry.Name.EndsWith(".html") 
            || entry.Name.EndsWith(".htm") then

            let mutable unknowns = set []
            let mutable notIncluded = set []
            let htmlDocument = new HtmlDocument()
            htmlDocument.Load(entry.Open(), System.Text.Encoding.UTF8)
            fprintfn tw "Checking File name: %s" entry.FullName
            for node in htmlDocument.DocumentNode.SelectNodes("//*/text()") do
                let decodedText = HttpUtility.HtmlDecode( node.InnerText)
                let (unknowns1, notIncluded1) = validator.validateTextStream(new StringReader(decodedText))
                unknowns <- Set.union unknowns (Set.ofArray(unknowns1))
                notIncluded <- Set.union notIncluded (Set.ofArray(notIncluded1))
            if unknowns.Count <> 0 then
                tw.WriteLine("Unknowns:")
            for u in unknowns do
                printCharacter tw u
            if notIncluded.Count <> 0 then
                tw.WriteLine("Not Included:")
            for n in notIncluded do
                printCharacter tw n