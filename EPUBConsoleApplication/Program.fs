open System
open CREPDL
open System.IO
open CREPDL.EPUBValidation

let private crepdlSource = 
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

[<EntryPoint>]
let main argv = 
    Console.OutputEncoding <- System.Text.Encoding.UTF8;
    use sw = new StreamWriter(Console.OpenStandardOutput())
    match argv with 
    | [| crepdlFileName; epubFileName |] -> 
        printfn "Started"
        try
            let validator = new CREPDLValidator(new StreamReader(crepdlFileName))
            printfn "Validator created"
            try 
              scanZip sw epubFileName validator
            with
            | :? SystemException -> 
              Console.Error.WriteLine("Error in the EPUB file.")
        with 
        | :? System.Xml.XmlException -> 
            Console.Error.WriteLine("Syntax error in the CREPDL Script")
    | [|epubFileName|] -> 
        printfn "Started"
        let validator = new CREPDLValidator(new StringReader(crepdlSource))
        printfn "Validator created"
        scanZip sw epubFileName validator
    | _ -> Console.WriteLine("Specify an EPUB file name or a CREPDL script file name followed by an EPUB file name")
    0 // return an integer exit code
