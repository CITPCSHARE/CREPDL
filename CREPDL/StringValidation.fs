module CREPDL.StringValidation


open System.Xml.Linq;

open Basics
open ThreeValuedBoolean
open ActivePattern
open Repertoire
open CharMatcher
open Registry
open ReadScript
open Registry2Repertoire



let rec unionHelp (rrd: RegistryRepertoireDictionary) (str: string) list (mn, mx) =
            match list with 
            | [] ->  False 
            | head::tail ->
                match checkString rrd head str (mn, mx) with
                | True -> True
                | False -> unionHelp rrd str tail (mn, mx)
                | Unknown when unionHelp rrd str tail (mn, mx) = True -> True
                | _ -> Unknown
                
and intersectionHelp (rrd: RegistryRepertoireDictionary)  (str: string) list (mn, mx) =
            match list with 
            | [] ->  True 
            | head::tail ->
                match checkString rrd head str (mn, mx) with
                | False -> False
                | True -> intersectionHelp rrd str tail (mn, mx)  
                | Unknown when intersectionHelp rrd str tail (mn, mx)  = False -> False
                | _ ->  Unknown
                
and differenceHelp (rrd: RegistryRepertoireDictionary) (str: string) (list: list<XElement>) (mn, mx)  =
          match checkString rrd list.Head str (mn, mx)  with
            | False -> False
            | True ->
                match unionHelp rrd str list.Tail (mn, mx)  with
                | False -> True  
                | True -> False   
                | Unknown -> Unknown  
            | Unknown ->
                match unionHelp rrd str list.Tail (mn, mx)  with
                | True -> False 
                | False | Unknown -> Unknown
                       
and checkString (rrd: RegistryRepertoireDictionary) (crepdl: XElement) (str: string) (minUV, maxUV): ThreeValuedBoolean =
        let minMaxHelp  =
            function
                | None ->       function None -> (minUV, maxUV) | Some(max) -> (minUV, max)
                | Some(min) ->  function None -> (min, maxUV) | Some(max) -> (min, max)
        match crepdl with 
        | Union(_, mn, mx, children) -> 
            unionHelp rrd str children (minMaxHelp mn mx)
        | Intersection(_,mn, mx, children) -> 
            intersectionHelp rrd str children  (minMaxHelp mn mx)
        | Difference(_,mn, mx, children) -> 
            differenceHelp rrd str children (minMaxHelp mn mx)
        | Repertoire(_,mn, mx, registry)  -> 
            let repertoire = rrd registry
            repertoire str
        | Char(_,mn, mx, kernel, hull, flag)  -> 
            checkStringAgainstChar str kernel hull flag (minMaxHelp mn mx)
        | Ref(_,mn, mx, _, children) -> 
            if children.Length = 1 then
                checkString rrd children.[0] str  (minMaxHelp mn mx)
            else failwith "should not happen"
    
    