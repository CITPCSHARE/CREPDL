module CREPDL.Validation


open System.Xml.Linq;
open System.Text.RegularExpressions;
open System.Text;

open Basics
open ThreeValuedBoolean
open ActivePattern
open Repertoire
open Char
open Registry
open ReadingCREPDL
open RepertoireCollection
open ExpandCollectionInCREPDL


[<Literal>]
let checkCharWithMemoCount = 1000
let defaultMinVersion = versionString2Int "2.0"
let defaultMaxVersion = versionString2Int "5.9"

let rec unionHelp (repCol: RepertoireCollection) char list (mn, mx) =
            match list with 
            | [] ->  False 
            | head::tail ->
//                union
//                    (checkChar rr head char (mn, mx))
//                    (fun () -> unionHelp rr char tail (mn, mx))
//                    
                match checkChar repCol head char (mn, mx) with
                | True -> True
                | False -> unionHelp repCol char tail (mn, mx)
                | Unknown when unionHelp repCol char tail (mn, mx) = True -> True
                | _ -> Unknown
                
and intersectionHelp (repCol: RepertoireCollection) char list (mn, mx) =
            match list with 
            | [] ->  True 
            | head::tail ->
//                intersection
//                    (checkChar rr head char (mn, mx))
//                    (fun () -> intersectionHelp rr char tail (mn, mx))
                match checkChar repCol head char (mn, mx) with
                | False -> False
                | True -> intersectionHelp repCol char tail (mn, mx)  
                | Unknown when intersectionHelp repCol char tail (mn, mx)  = False -> False
                | _ ->  Unknown
                
and differenceHelp (repCol: RepertoireCollection) char (list: list<XElement>) (mn, mx)  =
//            difference
//                (checkChar rr list.Head char (mn, mx))
//                (fun () -> unionHelp rr char list.Tail (mn, mx))
          match checkChar repCol list.Head char (mn, mx)  with
            | False -> False
            | True ->
                match unionHelp repCol char list.Tail (mn, mx)  with
                | False -> True  
                | True -> False   
                | Unknown -> Unknown  
            | Unknown ->
                match unionHelp repCol char list.Tail (mn, mx)  with
                | True -> False 
                | False | Unknown -> Unknown
                       
and checkChar (repCol: RepertoireCollection) (crepdl: XElement) (char: char) (minUV, maxUV): threeValuedBoolean =
        let minMaxHelp  =
            function
                | None ->       function None -> (minUV, maxUV) | Some(max) -> (minUV, max)
                | Some(min) ->  function None -> (min, maxUV) | Some(max) -> (min, max)
        match crepdl with 
        | Union(mn, mx, children) -> 
            unionHelp repCol char children (minMaxHelp mn mx)
        | Intersection(mn, mx, children) -> 
            intersectionHelp repCol char children  (minMaxHelp mn mx)
        | Difference(mn, mx, children) -> 
            differenceHelp repCol char children (minMaxHelp mn mx)
        | Repertoire(mn, mx, registry)  -> 
            match registry with
            | ISO10646(_, name, number)  -> 
                match getCollectionInCREPDL number name with
                | Some(schemaString) ->
                    let crepdl = readOneCREPDLFromStringWithMemo schemaString
                    checkChar repCol crepdl char (minMaxHelp mn mx)
                | None -> checkCharAgainstRepertoire char repCol registry (minMaxHelp mn mx)
            | _ -> checkCharAgainstRepertoire char repCol registry (minMaxHelp mn mx) 
        | Char(mn, mx, kernel, hull)  -> 
            checkCharAgainstChar char kernel hull  (minMaxHelp mn mx)
        | Ref(mn, mx, absUri) -> 
            checkChar repCol (readOneCREPDLWithMemo absUri) char  (minMaxHelp mn mx)
        | Illegal -> failwith ("syntax error: " + crepdl.Name.ToString())
    
    
let checkCharWithMemo (repCol: RepertoireCollection) (crepdl: XElement) =
        memoize (fun c -> checkChar repCol crepdl c (defaultMinVersion, defaultMaxVersion)) checkCharWithMemoCount