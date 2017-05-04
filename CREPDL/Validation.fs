module CREPDL.Validation

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

///<summary>This class provide an interface for invoking CREPDL validators.</summary>
///<param name="crepdl">An XElement representing a CREPDL script</param>
type Validator(crepdl: XElement) =
    static let checkCharWithMemoCount = 3000
    static let defaultMinVersion = versionString2Int "2.0"
    static let defaultMaxVersion = versionString2Int "5.9"

    let script = crepdl
    do expandRefAndRepertoire [] script
       checkModeConsistency script
       initializeCollections ()

    let rootMode = getRootMode script

    let stringChecker = 
        memoize (fun str -> checkString (createRegistryRepertoireDictionary crepdl) 
                                crepdl str (defaultMinVersion, defaultMaxVersion)) 
                                checkCharWithMemoCount

///<summary>Constructs a validator from a CREPDL file.</summary>
///<param name="filename">A CREPDL file name</param>
    new (filename: string) =
        let x = (XDocument.Load(filename, LoadOptions.SetBaseUri)).Root
        Validator(x)

///<summary>Constructs a validator from a CREPDL TextReader.</summary>
///<param name="tr">a TextReader for a CREPDL script</param>
    new (tr: TextReader) =
        let x = (XDocument.Load(tr, LoadOptions.SetBaseUri)).Root
        Validator(x)


///<summary>Validates a string representing a Unicode character
/// and report a three-valued boolean</summary>        
///<param name="charStr">a string representing a Unicode character</param>
///<returns>A three-valued boolean representing whether the given Unicode character 
///is included, may be included, or is not included.
    member this.validateCharacter (charStr: string): threeValuedBoolean = 
        if rootMode <> CharacterMode then invalidOp "The root mode is not CharacterMode" 
        stringChecker charStr
        
///<summary>Validates a string representing a Unicode grapheme cluster
/// and report a three-valued boolean</summary>        
///<returns>A three-valued boolean representing whether the given Unicode character 
///is included, may be included, or is not included.
///<param name="gcStr">a string representing a Unicode grapheme cluster</param>
    member this.validateGraphemeCluster(gcStr: string): threeValuedBoolean= 
        if rootMode <> GraphemeClusterMode then invalidOp "The root mode is not GraphemeClusterMode" 
        stringChecker gcStr
        
///<summary>Performs validation</summary>
///<param name="tr">a TextReader for the content to be validated</param>
///<returns>a list pair. where the first list contains 
///what is not included and the second contains what may be included</returns>
    member this.validateTextStream (tr: TextReader): string list * string list= 
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
        (List.rev unknowns, List.rev notIncluded)

        
///<summary>Performs validation</summary>
///<param name="str">a string to be validated</param>
///<returns>a list pair. where the first list contains 
///what is not included and the second contains what may be included</returns>
    member this.validateString (str: string): string list * string list= 
        this.validateTextStream(new StringReader(str))
        
///<summary>Performs validation</summary>
///<param name="filename">a file name to be validated</param>
///<param name="encName">an encoding name</param>
///<returns>a list pair. where the first list contains 
///what is not included and the second contains what may be included</returns>
    member this.validateFile (filename: string) (encName: string): string list * string list= 
          let enc =
            try
                Text.Encoding.GetEncoding(encName)
            with
                | :?  System.ArgumentException as exc
                  -> failwith (encName + ": ilegal encoding name")
          use fs = new FileStream(filename,  FileMode.Open)
          use sr = new StreamReader(fs, enc)
          this.validateTextStream(sr)

