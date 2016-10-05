module CREPDL.TopLevelValidation

open System;
open System.IO;
open System.Net
open System.Xml.Linq;
open System.Text.RegularExpressions;
open System.Text;

open Basics
open ThreeValuedBoolean
open SurrogateAwareTextReader
open ActivePattern
open Repertoire
open Char
open Validation
open ReadingCREPDL
                          
let validateTextReader (rr: RepertoireRegistory) (schema: XElement) (tr: TextReader) (sr: TextWriter): threeValuedBoolean =
    let mutable character = readChar tr
    let mutable result = True
    let mutable lineNumber = 1
    let mutable charNumber = 1
    while (int character) <> 0xFFFF do
        if (character = char '\n') || (character = char '\r') then 
            lineNumber <- lineNumber + 1;
            charNumber <- 1
        match checkCharWithMemo rr schema character with
            | True -> () 
            | False -> sr.Write("Line:" + lineNumber.ToString() + " Position: " + charNumber.ToString() + " ");
                       sr.WriteLine(character.ToString() + "(U+" + (int character).ToString("X4") + "): incorrect");
                       result <- False
            | Unknown -> sr.WriteLine(character.ToString() + ": unknown");
                         result <- if result = True then  Unknown 
                                   else if result = False then False
                                   else Unknown
        character <- readChar tr
        charNumber <- charNumber + 1
    result

let validateFile (rr: RepertoireRegistory) (schemaUri: string) 
                 (filename: string) (encName: string) (tw: TextWriter): threeValuedBoolean =
  let enc =
    try
        Text.Encoding.GetEncoding(encName)
    with
        | :?  System.ArgumentException as exc
          -> failwith (encName + ": ilegal encoding name")
  
  use fs = new FileStream(filename,  FileMode.Open)
  use sr = new StreamReader(fs, enc)
  validateTextReader rr (readAndCheckSchema schemaUri) sr tw


let validateString (rr: RepertoireRegistory) (schemaUri: string)
                   (str: string) (sr: TextWriter): threeValuedBoolean =
   validateTextReader rr (readAndCheckSchema schemaUri) (new StringReader(str)) sr 