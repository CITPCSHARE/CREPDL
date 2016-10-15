module  CREPDLTest.ConstructAllCollections

open System
open CREPDL.Basics
open CREPDL.Validation
open CREPDL.Repertoire
open CREPDL.ISO10646Collection
open CREPDL.ThreeValuedBoolean
open CREPDL.ReadingCREPDL
open CREPDL.TopLevelValidation

let constructAll10646Collections repCol = 
    let allCollections= List.append rbtCollections (List.append deweyCollections collectionsInCREPDL)
    let all10646Collections =
        List.filter (fun x -> x > 0)
            (List.map (fun (x, _, _) -> x) allCollections)

    List.iter 
        (fun (x: int) -> 
            System.Console.WriteLine(x);
            let y = @"<repertoire "
                            + @" xmlns=""http://purl.oclc.org/dsdl/crepdl/ns/structure/1.0"" "
                            + @" registry=""10646"" number=""" 
                            + x.ToString()
                            + @"""/>"
            validateStringAgainstSchemaString repCol y "\uFFF0" System.Console.Out |> writeThreeValuedBoolean)
        all10646Collections