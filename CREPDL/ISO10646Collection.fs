module CREPDL.ISO10646Collection

open Basics
open System.IO
open System.Collections.Generic
open CREPDL.ISO10646CollectionsDefinitions

//A pre-defined collections is represented in either (1) a sequence of code points or 
//ranges, or (2) a CREPDL script.  Sequences are represented either Red-Black trees 
//or Dewey-numbered trees.  
//
//It is not always clear which of the three representation should be
//chosen for a particular collection.  When a collection has a number of
//scattered code points or ranges, Dewey-numbered trees are guranteed to
//be fast, although Red-Back trees might be good enough.  CREPDL
//scripts can use pre-defined collections and regular expressions.

let internal generateRepertoireFromISOCollection  (name: string option) (collectionNumber: int option) = 
    match name, collectionNumber with
        | Some(cname), _ ->  
            try
                let (_,  _ , str) = List.find (fun (_, x, _) -> x = cname) inLineCollections 
                (new StringReader(str)) :> TextReader
            with 
              | :? KeyNotFoundException -> 
                try
                    let (_,  _ , filename) = List.find (fun  (_, x, _) -> x = cname) outOfLineCollections
                    (getStreamReaderForEmbeddedResource filename) :> TextReader
                with
                | :? KeyNotFoundException-> failwith "No such collection"
        | _, Some(cnumber)  ->
            try
                 let (_,  _ , str) = List.find (fun (x, _, _) -> x = cnumber) inLineCollections
                 (new StringReader(str)) :> TextReader
            with 
              | :? KeyNotFoundException -> 
                try
                    let (_,  _ , filename) = List.find (fun (x, _, _)  -> x = cnumber)  outOfLineCollections
                    (getStreamReaderForEmbeddedResource filename) :> TextReader
                with
                | :? KeyNotFoundException -> failwith "No such collection"
        | _,_ -> failwith "Specify either a name or a number"

        
let internal expandRepertoireFromISOCollection  (name: string option) (collectionNumber: int option): TextReader option = 
    match name, collectionNumber with
        | Some(cname), _ ->  
            try
                let (_,  _ , str) = List.find (fun (_, x, _) -> x = cname) collectionsInCREPDL 
                Some((new StringReader(str)) :> TextReader)
            with 
              | :? KeyNotFoundException -> None
        | _, Some(cnumber)  ->
            try
                let (_,  _ , str) = List.find (fun (x, _, _) -> x = cnumber) collectionsInCREPDL 
                Some((new StringReader(str)) :> TextReader)
            with 
              | :? KeyNotFoundException ->   None
        | _, _  -> None

