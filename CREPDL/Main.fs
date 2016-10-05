module CREPDL.Main

open System
open System.Text
open Basics
open Validation
open Repertoire
open ISO10646

open ThreeValuedBoolean
open TopLevelValidation

[<EntryPoint>]
let main args =
    Dewey.checkShiftSizeCount()
    let startTime = System.DateTime.Now in
    let rr = createRepertoireRepository (rbtCollections()) (deweyCollections()) in
    System.Console.WriteLine(System.DateTime.Now - startTime)
    let returnCode = 
      try
        match args with
            | [|crepdlFile; textFile|]
              -> validateFile rr crepdlFile textFile "utf-8" System.Console.Out |> writeThreeValuedBoolean
                 0
            | [|crepdlFile; textFile; encName|]
              -> validateFile rr crepdlFile textFile encName System.Console.Out |> writeThreeValuedBoolean
                 0
            | _ -> System.Console.WriteLine "Specify a CREPDL file and a text file"
                   1
       with
            | Failure msg 
                -> System.Console.WriteLine(msg)
                   1
            | :?  System.IO.FileNotFoundException 
               -> System.Console.WriteLine "File not found"
                  1

    System.Console.WriteLine(System.DateTime.Now - startTime)
    returnCode


//    let currentEncoding = System.Console.OutputEncoding
//    try 
//    System.Console.OutputEncoding <- new UTF8Encoding();
        


//    finally 
 //       System.Console.OutputEncoding <- currentEncoding