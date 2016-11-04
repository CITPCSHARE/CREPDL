module CREPDL.TopLevelValidation

open System;
open System.IO;
open System.Xml.Linq;

open ThreeValuedBoolean
open SurrogateAwareTextReader
open Validation
open ReadingCREPDL
open RepertoireCollection
                          
let validateTextReader (repCol: RepertoireCollection) (schema: XElement) (tr: TextReader) (sr: TextWriter): threeValuedBoolean =
    let mutable strI = readChar tr
    let mutable result = True
    let mutable lineNumber = 1
    let mutable charNumber = 1
    while snd strI <> 0xFFFFFFFF do
        if (snd strI = int32 (char '\n')) || (snd strI =  int32 (char '\r')) then 
            lineNumber <- lineNumber + 1;
            charNumber <- 1
        match checkCharWithMemo repCol schema strI with
            | True -> () 
            | False -> sr.Write("Line:" + lineNumber.ToString() + " Position: " + charNumber.ToString() + " ");
                       sr.WriteLine((fst strI) + "(U+" + (snd strI).ToString("X4") + "): incorrect");
                       result <- False
            | Unknown -> sr.WriteLine((fst strI) + ": unknown");
                         result <- if result = True then  Unknown 
                                   else if result = False then False
                                   else Unknown
        strI <- readChar tr
        charNumber <- charNumber + 1
    result

let validateFile (repCol: RepertoireCollection) (schemaUri: string) 
                 (filename: string) (encName: string) (tw: TextWriter): threeValuedBoolean =
  let enc =
    try
        Text.Encoding.GetEncoding(encName)
    with
        | :?  System.ArgumentException as exc
          -> failwith (encName + ": ilegal encoding name")
  
  use fs = new FileStream(filename,  FileMode.Open)
  use sr = new StreamReader(fs, enc)
  validateTextReader repCol (readAndCheckSchema schemaUri) sr tw


let validateString (repCol: RepertoireCollection) (schemaUri: string)
                   (str: string) (sr: TextWriter): threeValuedBoolean =
   validateTextReader repCol (readAndCheckSchema schemaUri) (new StringReader(str)) sr 


let validateStringAgainstSchemaString (repCol: RepertoireCollection) (schemaString: string)
                   (str: string) (sr: TextWriter): threeValuedBoolean =

   validateTextReader repCol (XDocument.Parse( schemaString).Root) (new StringReader(str)) sr 