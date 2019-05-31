namespace CREPDL

open Basics
open ThreeValuedBoolean
open StringValidation
open Registry2Repertoire
open CheckExpandedScript
open ReadCharacter
open ExpandRefAndRepertoire
open ReadGraphemeCluster
open ISO10646Collection
open System.Xml.Linq
open System.IO
open System

/// <summary>True (in the collection), False (not in the collection), or Unknown</summary>
type CREPDLValidationResult = True = 0 | False = 1 | Unknown = 2;;

/// <summary>This class provides an interface for invoking CREPDL validators.</summary>
type CREPDLValidator private (crepdl: XElement, u:unit) =
    static let checkCharWithMemoCount = 3000
    static let defaultMinVersion = versionString2Int "2.0"
    static let defaultMaxVersion = versionString2Int "5.9"
    

    let script = expandRefAndRepertoire [] crepdl

    let rootMode = getRootMode script


    let stringChecker = 
        let rrd = createRegistryRepertoireDictionary script
        memoize (fun str -> checkString rrd 
                                script str (defaultMinVersion, defaultMaxVersion)) 
                                checkCharWithMemoCount
                                
/// <summary>Constructs a validator.</summary>
/// <param name="crepdl">An XElement representing a CREPDL script</param>
    new (crepdl: XElement) = CREPDLValidator(crepdl, ())

/// <summary>Constructs a validator.</summary>
/// <param name="filename">A CREPDL file name</param>
    new (filename: string) =
        let x = (XDocument.Load(filename, LoadOptions.SetBaseUri)).Root
        CREPDLValidator(x, ())

/// <summary>Constructs a validator.</summary>
/// <param name="tr">A TextReader for a CREPDL script</param>
    new (tr: TextReader) =
        let x = (XDocument.Load(tr, LoadOptions.SetBaseUri)).Root
        CREPDLValidator(x, ())

/// <summary>Validates a string representing a Unicode character
/// and report a three-valued boolean</summary>        
/// <param name="charStr">A string representing a Unicode character</param>
/// <returns>Either True, False, or Unknown</returns>
    member this.validateCharacter (charStr: string): CREPDLValidationResult = 
        if rootMode <> CharacterMode then invalidOp "The root mode is not CharacterMode" 
        match stringChecker charStr with
        | True -> CREPDLValidationResult.True | False -> CREPDLValidationResult.False | Unknown -> CREPDLValidationResult.Unknown

/// <summary>Validates a string representing a Unicode grapheme cluster
/// and report a three-valued boolean</summary>        
/// <param name="gcStr">A string representing a Unicode grapheme cluster</param>
/// <returns>Either True, False, or Unknown</returns>
    member this.validateGraphemeCluster(gcStr: string): CREPDLValidationResult= 
        if rootMode <> GraphemeClusterMode then invalidOp "The root mode is not GraphemeClusterMode" 
        match stringChecker gcStr with
        | True -> CREPDLValidationResult.True | False -> CREPDLValidationResult.False | Unknown -> CREPDLValidationResult.Unknown
        
/// <summary>Performs validation</summary>
/// <param name="tr">a TextReader for the content to be validated</param>
/// <returns>An array pair, where the first array contains what may be or may not be included 
/// and the second contains what is not included.</returns>
    member this.validateTextStream (tr: TextReader): string array * string array= 
        let mutable unknowns = []
        let mutable notIncluded = []
        let enumerator  =
            match rootMode with
            | CharacterMode -> getCharacterEnumerator tr
            | GraphemeClusterMode -> getGraphemeClusterEnumerator tr
        for str in enumerator do
            match stringChecker str with
            | True -> ()
            | Unknown -> 
                unknowns <- str::unknowns
            | False  -> 
                notIncluded <- str::notIncluded
        (Array.ofList(List.rev unknowns), Array.ofList(List.rev notIncluded))

        
/// <summary>Performs validation</summary>
/// <param name="str">A string to be validated</param>
/// <returns>An array pair, where the first array contains what may be or may not be included 
/// and the second contains what is not included.</returns>
    member this.validateString (str: string): string array * string array= 
        this.validateTextStream(new StringReader(str))
        
/// <summary>Performs validation</summary>
/// <param name="filename">A file name to be validated</param>
/// <param name="encName">An encoding name</param>
/// <returns>An array pair, where the first array contains what may be or may not be included 
/// and the second contains what is not included.</returns>
    member this.validateFile (filename: string) (encName: string): string array * string array = 
          let enc =
            try
                Text.Encoding.GetEncoding(encName)
            with
                | :?  System.ArgumentException as exc
                  -> failwith (encName + ": ilegal encoding name")
          use fs = new FileStream(filename,  FileMode.Open)
          use sr = new StreamReader(fs, enc)
          this.validateTextStream(sr)

