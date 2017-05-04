module CREPDL.CheckExpandedScript
open System;
open System.IO;
open System.Xml.Linq;

open Basics
open ActivePattern

let getRootMode (crepdl: XElement): mode =
    match crepdl with
    | Union(Some(md),_, _, _) | Intersection(Some(md),_, _,  _) 
    | Difference(Some(md),_, _,  _) | Repertoire(Some(md),_, _, _) 
    | Char(Some(md),_, _, _, _, _) | GraphemeCluster(Some(md),_, _, _, _, _)
    | Ref(Some(md),_, _, _, _)
        -> md
            
    | Union(None,_, _, _) | Intersection(None,_, _, _) 
    | Difference(None,_, _, _) | Repertoire(None,_, _, _) 
    | Char(None,_, _, _, _, _) 
    | Ref(None,_, _, _, _) 
        ->   CharacterMode //Default is CharacterMode
    | GraphemeCluster(None,_, _, _, _, _) 
        ->  GraphemeClusterMode  //Default is GraphemeClusterMode

let checkModeConsistency (crepdl: XElement): unit =
    let rec help (parentMode: mode) (crepdl: XElement): unit =
        match crepdl with
        | Union(Some(md),_, _, children) 
        | Intersection(Some(md),_, _, children) 
        | Difference(Some(md),_, _, children)
        | Ref(Some(md), _, _,_, children)    
            -> if parentMode = md then
                    List.iter (help md) children
                else failwith  "Different mode";
        | Union(None,_, _, children) 
        | Intersection(None,_, _, children) 
        | Difference(None,_, _, children)
        | Ref(None, _, _,_, children)
            -> List.iter (help parentMode) children

        | Repertoire(Some(md),_, _, _) 
        | Char(Some(md), _, _,  _, _, _) 
            -> if parentMode <> md then failwith "Different mode"
        | Repertoire(None,_, _, _)
        | Char(None,_, _, _, _, _) 
            ->  ()
                 
        | GraphemeCluster(Some(md),_, _, _, _, _) 
            -> if parentMode <> md then
                    failwith "Different mode"
                elif md = CharacterMode then
                    failwith "GraphemeCluster is unusable in the character mode"
        | GraphemeCluster(None,_, _, _, _, _)
            ->  if parentMode = CharacterMode then
                    failwith "GraphemeCluster is unusable in the character mode"
 
    help (getRootMode crepdl) crepdl;;