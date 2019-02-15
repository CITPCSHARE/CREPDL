module CREPDL.ExpandRefAndRepertoire

open ReadScript
open ActivePattern
open Basics
open ISO10646Collection
open Registry
open System.Xml.Linq

let rec expandRefAndRepertoire (parents: List<System.Uri>) (crepdl: XElement): unit =

    match crepdl with
    | Union(_,_, _, children) 
    | Intersection(_,_, _, children) 
    | Difference(_,_, _, children)
        -> List.iter (expandRefAndRepertoire parents) children
    | Char(_,_, _, _, _, _) 
        -> ()
    | Repertoire(_, _, _, ISO10646(name, number) )
        ->  let tr = expandRepertoireFromISOCollection name number 
            let newRef = new XElement(XNamespace.Get(crepdlNamespaceV2) + "ref")
            let minA = crepdl.Attribute(XNamespace.None + "minUcsVersion")
            let maxA = crepdl.Attribute(XNamespace.None + "maxUcsVersion")
            let modeA = crepdl.Attribute(XNamespace.None + "mode")
            if minA <> null then newRef.Add(minA)
            if maxA <> null then newRef.Add(maxA)
            if modeA <> null then newRef.Add(modeA)
            let node = readScriptFromString (tr.ReadToEnd())
            crepdl.ReplaceWith(newRef)
            newRef.AddFirst(node)
            expandRefAndRepertoire parents node
    | Repertoire(_, _, _, _ ) -> ()
    | Ref(_, _, _,absUri, []) ->  
            if List.contains absUri parents then 
                failwith "Loop caused by ref elements"
            let node = readScriptFromUri absUri
            crepdl.AddFirst(node)
            expandRefAndRepertoire (absUri::parents) node
    | Ref(_, _, _, _, _)   -> 
        failwith "should not happen"
