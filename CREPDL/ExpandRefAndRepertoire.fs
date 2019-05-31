module CREPDL.ExpandRefAndRepertoire

open ReadScript
open ActivePattern
open Basics
open ISO10646Collection
open Registry
open System.Xml.Linq

let internal copyElement (elem: XElement): XElement = 
    let copy = new XElement( elem.Name)
    let minA = elem.Attribute(XNamespace.None + "minUcsVersion")
    let maxA = elem.Attribute(XNamespace.None + "maxUcsVersion")
    let modeA = elem.Attribute(XNamespace.None + "mode")
    let hrefA = elem.Attribute(XNamespace.None + "href")
    if minA <> null then copy.Add(minA)
    if maxA <> null then copy.Add(maxA)
    if modeA <> null then copy.Add(modeA)
    if hrefA <> null then copy.Add(hrefA)
    copy

let rec internal expandRefAndRepertoire (parents: List<System.Uri>) (crepdl: XElement): XElement =

    match crepdl with
    | Union(_,_, _, children) 
    | Intersection(_,_, _, children) 
    | Difference(_,_, _, children)
        -> let copy = copyElement crepdl
           for child in List.rev children do
             copy.AddFirst (expandRefAndRepertoire parents child)
           copy
    | Char(_,_, _, _, _, _) 
        -> crepdl
    | Repertoire(_, _, _, ISO10646(name, number) )
        ->  match expandRepertoireFromISOCollection name number with
            | Some(tr) -> 
                let node = readScriptFromString (tr.ReadToEnd())
                expandRefAndRepertoire parents node
            | None -> crepdl
    | Repertoire(_, _, _, _ ) -> crepdl
    | Ref(_, _, _,absUri, []) ->  
            if List.contains absUri parents then 
                failwith "Loop caused by ref elements"
            let node = readScriptFromUri absUri
            expandRefAndRepertoire (absUri::parents) node
    | Ref(_, _, _, _, _)   -> 
        failwith "should not happen"
