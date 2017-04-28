﻿module  CREPDL.GCValidation

open System.Xml.Linq;

open Basics
open ThreeValuedBoolean
open ActivePattern
open Repertoire
open Char
open Registry
open ReadingCREPDL
open RepertoireCollection
open Token
open ExpandCollectionInCREPDL


[<Literal>]
let checkCharWithMemoCount = 1000
let defaultMinVersion = versionString2Int "2.0"
let defaultMaxVersion = versionString2Int "5.9"

let rec private unionHelp (repCol: RepertoireCollection) (tkn: token) list (mn, mx) =
            match list with 
            | [] ->  False 
            | head::tail ->
                match checkChar repCol head tkn (mn, mx) with
                | True -> True
                | False -> unionHelp repCol tkn tail (mn, mx)
                | Unknown when unionHelp repCol tkn tail (mn, mx) = True -> True
                | _ -> Unknown
                
and private intersectionHelp (repCol: RepertoireCollection) (tkn: token) list (mn, mx) =
            match list with 
            | [] ->  True 
            | head::tail ->
                match checkChar repCol head tkn (mn, mx) with
                | False -> False
                | True -> intersectionHelp repCol tkn tail (mn, mx)  
                | Unknown when intersectionHelp repCol tkn tail (mn, mx)  = False -> False
                | _ ->  Unknown
                
and private differenceHelp (repCol: RepertoireCollection) (tkn: token) (list: list<XElement>) (mn, mx)  =
          match checkChar repCol list.Head tkn (mn, mx)  with
            | False -> False
            | True ->
                match unionHelp repCol tkn list.Tail (mn, mx)  with
                | False -> True  
                | True -> False   
                | Unknown -> Unknown  
            | Unknown ->
                match unionHelp repCol tkn list.Tail (mn, mx)  with
                | True -> False 
                | False | Unknown -> Unknown
                       
and checkChar (repCol: RepertoireCollection) (crepdl: XElement) (tkn: token) (minUV, maxUV): threeValuedBoolean =
        let minMaxHelp  =
            function
                | None ->       function None -> (minUV, maxUV) | Some(max) -> (minUV, max)
                | Some(min) ->  function None -> (min, maxUV) | Some(max) -> (min, max)
        match crepdl with 
        | Union(_, mn, mx, children) -> 
            unionHelp repCol tkn children (minMaxHelp mn mx)
        | Intersection(_,mn, mx, children) -> 
            intersectionHelp repCol tkn children  (minMaxHelp mn mx)
        | Difference(_,mn, mx, children) -> 
            differenceHelp repCol tkn children (minMaxHelp mn mx)
        | Repertoire(_,mn, mx, registry)  -> 
            match registry with
            | ISO10646(_, name, number)  -> 
                match getCollectionInCREPDL number name with
                | Some(schemaString) ->
                    let crepdl = readOneCREPDLFromStringWithMemo schemaString
                    checkChar repCol crepdl tkn (minMaxHelp mn mx)
                | None -> checkCharAgainstRepertoire tkn repCol registry (minMaxHelp mn mx)
            | _ -> checkCharAgainstRepertoire tkn repCol registry (minMaxHelp mn mx) 
        | Char(_,mn, mx, kernel, hull)  -> 
            checkStringAgainstChar (getStringFromToken tkn) kernel hull  (minMaxHelp mn mx)
        | GraphemeCluster(_,_,_,_,_) ->
            failwith "should not happen"
        | Ref(_,mn, mx, absUri) -> 
            checkChar repCol (readOneCREPDLWithMemo absUri) tkn (minMaxHelp mn mx)
    
    
let checkCharWithMemo (repCol: RepertoireCollection) (crepdl: XElement) =
        memoize (fun c -> checkChar repCol crepdl c (defaultMinVersion, defaultMaxVersion)) checkCharWithMemoCount