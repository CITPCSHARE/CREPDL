module CREPDL.CheckExpandedScript
open System;
open System.IO;
open System.Xml.Linq;

open Basics
open ActivePattern

let internal getRootMode (crepdl: XElement): mode =
    match crepdl with
    | Union(Some(md),_, _, _) | Intersection(Some(md),_, _,  _) 
    | Difference(Some(md),_, _,  _) | Repertoire(Some(md),_, _, _) 
    | Char(Some(md),_, _, _, _, _) 
    | Ref(Some(md),_, _, _, _)
        -> md
            
    | Union(None,_, _, _) | Intersection(None,_, _, _) 
    | Difference(None,_, _, _) | Repertoire(None,_, _, _) 
    | Char(None,_, _, _, _, _) 
    | Ref(None,_, _, _, _) 
        ->   CharacterMode //Default is CharacterMode

