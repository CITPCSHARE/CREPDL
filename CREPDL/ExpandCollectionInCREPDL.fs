module CREPDL.ExpandCollectionInCREPDL

open System.Collections.Generic
open ISO10646Collection


let getCollectionInCREPDL  (collectionNumber: int option) (collectionName: string option) =
    
    match collectionNumber, collectionName with
    | Some(colNum),_ -> 
        try 
          let (_,_,z) = List.find (fun (x, _, _) -> colNum = x) collectionsInCREPDL
          Some(z)
        with
            | :? KeyNotFoundException -> None
    | _, Some(colName)  -> 
        try 
          let (_,_,z) = List.find (fun (_, y, _) -> colName = y) collectionsInCREPDL
          Some(z)
        with
            | :? KeyNotFoundException -> None
    | _, _ -> None