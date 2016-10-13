module CREPDL.ExpandCollectionInCREPDL

open System.Collections.Generic
open ISO10646Collection

let isDefinedInCREPDL (collectionNumber: int option) (collectionName: string option): bool  =

    let numbers = List.map (fun (x, _, _) -> x) collectionsInCREPDL
    let names = List.map (fun (_, x, _) -> x) collectionsInCREPDL

    match (collectionName, collectionNumber) with
           | Some(nm), _  -> List.contains nm names
           | _, Some(cnum)  -> List.contains cnum numbers
           | _,_ -> failwith "Specify either a name or a number"  


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