module CREPDL.ActivePattern

open System;
open System.Xml.Linq;
open System.Text.RegularExpressions;
open System.Text;
open Registry;

open Basics;

type mode = CharacterMode | GraphemeClusterMode;;


let private createRegV1 (regStr: string): Regex =
    if regStr.Length = 1 //Char or WildCardEsc
        || (regStr.StartsWith("[") && regStr.EndsWith("]")) //charClassExpr
        || (regStr.StartsWith("\\") && regStr.Length = 2) //SingleCharEsc or MultiCharEsc
        || (let chReg = new Regex("\\\P{.+}") in chReg.Match(regStr).Success) //catExc or complEsc  "\\P{[\{\}]+}"
        || (let chReg = new Regex("\\\p{.+}") in chReg.Match(regStr).Success) //catExc or complEsc  "\\p{[\{\}]+}"
//        || (let chReg = new Regex("\\\N{.+}") in chReg.Match(regStr).Success) //catExc or complEsc  "\\p{[\{\}]+}"
    then new Regex(regStr)
    else failwith  ("illegal regular expression: " +  regStr);


let createRegV2 (regStr: string) syntaxSugar: Regex =
    new Regex(regStr);

let (|Union|Intersection|Difference|Ref|Repertoire|Char|GraphemeCluster|) (crepdl: XElement):
      Choice<mode option * int option * int option * XElement list, 
             mode option * int option * int option * XElement list, 
             mode option * int option * int option * XElement list, 
             mode option * int option * int option * Uri, 
             mode option * int option * int option * Registry, 
             mode option * int option * int option * Regex option * Regex option, 
             mode option * int option * int option * Regex option * Regex option> =
  let crepdlChildren =
    List.filter (fun (c: XElement) -> 
                    c.Name.NamespaceName.Equals crepdlNamespaceV2) 
                (Seq.toList (crepdl.Elements()))  
  let getAndTrimAttributeValue (name: string): string option =
    match crepdl.Attribute(XNamespace.None + name) with
    | null ->  None
    | x -> Some(x.Value.Trim())
  let minUV = 
    let atv = getAndTrimAttributeValue "minUcsVersion"
    Option.map versionString2Int atv 
  let maxUV = 
    let atv = getAndTrimAttributeValue "maxUcsVersion"
    Option.map versionString2Int atv 
  let mode = 
    let atv = getAndTrimAttributeValue "mode"
    match atv  with 
    | Some("character") -> Some(CharacterMode)
    | Some("graphmeCluster") -> Some(GraphemeClusterMode)
    | Some(_) -> failwith "Illegal value of @mode"
    | None -> None
         
  let hasDisallowedLocalAttribute (allowedAtts: string list) =         
    for at in crepdl.Attributes() do
        if (not at.IsNamespaceDeclaration) &&
           at.Name.NamespaceName.Equals("") &&
           at.Name.LocalName <> "minUcsVersion" && 
           at.Name.LocalName <> "maxUcsVersion" &&
           at.Name.LocalName <> "mode" &&
           (List.forall (fun str -> at.Name.LocalName <> str) allowedAtts)
        then failwith ("An illegal attribute: " + at.Name.LocalName)
              

  match crepdl.Name.LocalName with
    | "union"
      -> hasDisallowedLocalAttribute []
         Union(mode, minUV, maxUV, crepdlChildren)
    | "intersection"
      ->  hasDisallowedLocalAttribute [] 
          Intersection(mode, minUV, maxUV, crepdlChildren)
    | "difference" 
      ->  hasDisallowedLocalAttribute []
          Difference(mode, minUV, maxUV, crepdlChildren)
    | "ref"
      ->  hasDisallowedLocalAttribute ["href"] 
          Ref(mode, minUV, maxUV, 
                match getAndTrimAttributeValue "href" with
                | Some(v) -> absolute (Uri crepdl.BaseUri) v
                | _ -> failwith "@href is missing.")
    | "repertoire" when Seq.length crepdlChildren = 0
      ->  hasDisallowedLocalAttribute ["registry"; "version"; "number"; "name"]
          let version = getAndTrimAttributeValue "version"
          let name = getAndTrimAttributeValue "name"
          let number = getAndTrimAttributeValue "number"
          match (name, number) with 
          | None, None -> failwith "Both @name and @number are missing"
          | _ -> ()
          let registryName = getAndTrimAttributeValue "registry"
          let registry = 
                match registryName with
                | Some("10646") -> ISO10646(version, name, Option.map int number)
                | Some("CLDR") -> CLDR(version, name)
                | Some("IANA") -> IANA(version, name, Option.map int number)
                | Some(x) -> failwith ("undefined registry: " + x)
                | None -> failwith "@registry is missing"
          Repertoire(mode, minUV, maxUV, registry)
    | "char"
      ->  hasDisallowedLocalAttribute [] 
          let (k,h) = 
            match crepdlChildren with
            | [] -> (Some(createRegV1 crepdl.Value), Some(createRegV1 crepdl.Value)) 
            | [kernel] when crepdlChildren.[0].Name.LocalName = "kernel" 
                    -> (Some(createRegV1 crepdlChildren.[0].Value), None)
            | [hull] when crepdlChildren.[0].Name.LocalName = "hull" 
                -> (None, Some(createRegV1 crepdlChildren.[0].Value))
            | [kernel; hull] when crepdlChildren.[0].Name.LocalName = "kernel" 
                        && crepdlChildren.[1].Name.LocalName = "hull" 
                -> (Some(createRegV1 crepdlChildren.[0].Value), Some(createRegV1 crepdlChildren.[1].Value))
            | _ -> failwith "Illegal content of a char element";
          Char(mode, minUV, maxUV, k, h)
    | "gc" | "graphemeCluster"
      ->  hasDisallowedLocalAttribute ["syntaxSugar"] 
          let ssf = 
            match getAndTrimAttributeValue "syntaxSugar" with
            | Some( "true") | None -> true
            | Some("false") -> false
            | _ -> failwith "Illegal value of @syntaxSugar"
          let (k,h) =
            match crepdlChildren with
            | [] -> (Some(createRegV2 crepdl.Value ssf), 
                     Some(createRegV2 crepdl.Value ssf)) 
            | [kernel] when crepdlChildren.[0].Name.LocalName = "kernel" 
                    -> (Some(createRegV2 crepdlChildren.[0].Value ssf), None)
            | [hull] when crepdlChildren.[0].Name.LocalName = "hull" 
                -> (None, Some(createRegV2 crepdlChildren.[0].Value ssf))
            | [kernel; hull] when crepdlChildren.[0].Name.LocalName = "kernel" 
                        && crepdlChildren.[1].Name.LocalName = "hull" 
                -> (Some(createRegV2 crepdlChildren.[0].Value ssf), 
                    Some(createRegV2 crepdlChildren.[1].Value ssf))
            | _ -> failwith "Illegal content of a graphemeCluster element";
          GraphemeCluster(mode, minUV, maxUV, k, h)
    | _ -> failwith ("Illegal element" + crepdl.Name.LocalName);


let getRootMode (crepdl: XElement): mode =
    match crepdl with
    | Union(Some(md),_, _, _) | Intersection(Some(md),_, _,  _) 
    | Difference(Some(md),_, _,  _) | Repertoire(Some(md),_, _, _) 
    | Char(Some(md),_, _, _, _) | GraphemeCluster(Some(md),_, _, _, _)
    | Ref(Some(md),_, _, _)
        -> md
            
    | Union(None,_, _, _) | Intersection(None,_, _, _) 
    | Difference(None,_, _, _) | Repertoire(None,_, _, _) 
    | Char(None,_, _, _, _) 
    | Ref(None,_, _, _) 
        ->   CharacterMode //Default is CharacterMode
    | GraphemeCluster(None,_, _, _, _) 
        ->  GraphemeClusterMode  //Default is GraphemeClusterMode
