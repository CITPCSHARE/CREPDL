open System
open HtmlAgilityPack
open CREPDL.Validation
open System.IO
open System.IO.Compression
open System.Web

let crepdlSource = 
        @"<union xmlns=""http://purl.oclc.org/dsdl/crepdl/ns/structure/2.0"" mode=""graphemeCluster"">
        <repertoire 
          registry=""10646"" number=""371""/> <!-- JIS2004 IDEOGRAPHICS EXTENSION -->
        <repertoire 
          registry=""10646"" number=""285""/> <!-- BASIC JAPANESE (or JIS X 0208) -->
        <repertoire 
          registry=""10646"" number=""286""/> <!-- JAPANESE NON IDEOGRAPHICS EXTENSION -->
        <repertoire 
          registry=""10646"" number=""287""/> <!--  COMMON JAPANESE -->
        <char>[\n|\r|\t]|(\r\n)</char>
        </union>"

let printCharacter (str: string) =
    printf "%s (" str
    for i = 0 to str.Length - 1 do
            let v = str.Chars i |> int
            v.ToString("x4") |>
                if i = str.Length - 1 then
                 printf "U+%s" 
                else printf "%s, "
    printfn ")"

let scanZip (filePath: string) (validator: Validator) = 
    let zipFile = ZipFile.OpenRead(filePath)
    for entry in zipFile.Entries do
        if entry.Name.EndsWith(".xhtml") 
            || entry.Name.EndsWith(".html") 
            || entry.Name.EndsWith(".htm") then

            let mutable unknowns = set []
            let mutable notIncluded = set []
            let htmlDocument = new HtmlDocument()
            htmlDocument.Load(entry.Open(), System.Text.Encoding.UTF8)
            printfn "Checking File name: %s" entry.FullName
            for node in htmlDocument.DocumentNode.SelectNodes("//*/text()") do
                let decodedText = HttpUtility.HtmlDecode( node.InnerText)
                let (unknowns1, notIncluded1) = validator.validateTextStream(new StringReader(decodedText))
                unknowns <- Set.union unknowns (Set.ofArray(unknowns1))
                notIncluded <- Set.union notIncluded (Set.ofArray(notIncluded1))
            if unknowns.Count <> 0 then
                System.Console.WriteLine("Unknowns:")
            for u in unknowns do
                printCharacter u
            if notIncluded.Count <> 0 then
                System.Console.WriteLine("Not Included:")
            for n in notIncluded do
                printCharacter n


[<EntryPoint>]
let main argv = 
    Console.OutputEncoding <- System.Text.Encoding.UTF8;
    match argv with 
    | [|epubFileName; crepdlFileName |] -> 
        let validator = new Validator(new StreamReader(crepdlFileName))
        scanZip epubFileName validator
    | [|epubFileName|] -> 
        let validator = new Validator(new StringReader(crepdlSource))
        scanZip epubFileName validator
    | _ -> Console.WriteLine("Specify an EPUB file name")
    0 // return an integer exit code
