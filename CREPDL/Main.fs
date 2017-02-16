﻿module CREPDL.Main


open ISO10646Collection
open ThreeValuedBoolean
open TopLevelValidation
open RepertoireCollection

[<EntryPoint>]
let main args =
    Dewey.checkShiftSizeCount()
    let startTime = System.DateTime.Now in
    let repCol = 
        createRepertoireCollection 
            inLineCollections 
            outOfLineCollections 
            (dict [])
    System.Console.WriteLine(System.DateTime.Now - startTime)
    let returnCode = 
      try
        match args with
            | [|crepdlFile; textFile|]
              -> validateFile repCol crepdlFile textFile "utf-8" System.Console.Out |> writeThreeValuedBoolean
                 0
            | [|crepdlFile; textFile; encName|]
              -> validateFile repCol crepdlFile textFile encName System.Console.Out |> writeThreeValuedBoolean
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

