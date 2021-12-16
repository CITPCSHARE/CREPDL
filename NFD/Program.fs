//This project is to create collections by  combining or applying the NFD normalization to those in JIS X 0212

open CREPDL.ISO10646Collection
open CREPDL.ThreeValuedBoolean
open CREPDL
open System.IO
open System.Text

open System;

let create285Validator() =
    let crepdlScriptString =
        @"<repertoire 
        registry=""10646"" number=""285"" xmlns=""http://purl.oclc.org/dsdl/crepdl/ns/structure/2.0""/> <!-- BASIC JAPANESE (or JIS X 0208) -->"
    new CREPDLValidator(new StringReader(crepdlScriptString))

let create286Validator() =
    let crepdlScriptString =
        @"<repertoire 
        registry=""10646"" number=""286"" xmlns=""http://purl.oclc.org/dsdl/crepdl/ns/structure/2.0""/> <!-- JAPANESE NON IDEOGRAPHICS EXTENSION -->"
    new CREPDLValidator(new StringReader(crepdlScriptString))

let create287Validator() =
    let crepdlScriptString =
        @"<repertoire 
        registry=""10646"" number=""287"" xmlns=""http://purl.oclc.org/dsdl/crepdl/ns/structure/2.0""/> <!--  COMMON JAPANESE -->"
    new CREPDLValidator(new StringReader(crepdlScriptString))


let create371Validator() =
    let crepdlScriptString =
        @"<repertoire 
        registry=""10646"" number=""371"" xmlns=""http://purl.oclc.org/dsdl/crepdl/ns/structure/2.0""/> <!-- JIS2004 IDEOGRAPHICS EXTENSION -->"
    new CREPDLValidator(new StringReader(crepdlScriptString))


let examineCodePoints (validator: CREPDLValidator) sw =
    for i = 0x20 to 0xFFFD do
      let ch = char i
      if not(Char.IsSurrogate(ch)) then
          let str = ch.ToString()
          let (ar1, ar2) = validator.validateString(str)
          if  ar1.Length = 0 && ar2.Length = 0 then
                let normalizedString = str.Normalize(NormalizationForm.FormD)
                if normalizedString.Length > 1 then
                    fprintf sw "U+%04X(%s) = " i str
                    normalizedString.ToCharArray() 
                    |> Array.map int
                    |> Array.iter ( fprintf sw "U+%04X ")
                    fprintfn sw ""

let examineCombiningCharacters () =
   let examineCodePoints (validator: CREPDLValidator) =
       for i in [0X0306; 0X0308; 0X030A; 0X0338; 0X3099; 0X309A; 0X0300; 0X0301; 0X0302; 0X0303; 0X0304; 0X0306; 0X0307; 0X0308; 0X030A; 0X030B; 0X030C; 0X0327; 0X0328; 0X0338; 0X3099] do
            let str = (char i).ToString()
            let (ar1, ar2) = validator.validateString(str)
            if  ar1.Length = 0 && ar2.Length = 0 then
              printfn "U+%04X" i 
            

   printfn  "BASIC JAPANESE"
   create285Validator() |> examineCodePoints
   printfn  "JAPANESE NON IDEOGRAPHICS EXTENSION"
   create286Validator()|> examineCodePoints
   printfn  "COMMON JAPANESE"
   create287Validator()|> examineCodePoints
    

[<EntryPoint>]
let main argv =
    let sw = new StreamWriter(new FileStream("G:\CREPDLJA1.txt", FileMode.Create), Encoding.UTF8)
    fprintfn sw "BASIC JAPANESE"
    let validator = create285Validator()
    examineCodePoints validator  sw
    fprintfn sw "JAPANESE NON IDEOGRAPHICS EXTENSION"
    let validator = create286Validator()
    examineCodePoints validator  sw
    fprintfn sw "COMMON JAPANESE"
    let validator = create287Validator()
    examineCodePoints validator  sw
    fprintfn sw "JIS2004 IDEOGRAPHICS EXTENSION"
    let validator = create371Validator()
    examineCodePoints validator  sw
    sw.Close()
    examineCombiningCharacters ()
    0 // return an integer exit code