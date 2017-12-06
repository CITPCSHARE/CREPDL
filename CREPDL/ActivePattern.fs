module CREPDL.ActivePattern

open System;
open System.Xml.Linq;
open System.Text.RegularExpressions;
open System.Text;
open Registry;
open CharMatcher
open Icu

open Basics;

    

let (|Union|Intersection|Difference|Ref|Repertoire|Char|) (crepdl: XElement):
      Choice<mode option * int option * int option * XElement list, 
             mode option * int option * int option * XElement list, 
             mode option * int option * int option * XElement list, 
             mode option * int option * int option * Uri * XElement list, 
             mode option * int option * int option * Registry , 
             mode option * int option * int option * RegexMatcher option * RegexMatcher option * bool> =

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
    | Some("graphemeCluster") -> Some(GraphemeClusterMode)
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
          let absUri = 
                match getAndTrimAttributeValue "href" with
                | Some(v) -> 
                    let b = crepdl.BaseUri
                    if b = "" then Uri(v)                    
                    else absolute (Uri b) v
                | _ -> failwith "@href is missing." 
          Ref(mode, minUV, maxUV,  absUri, 
               crepdlChildren)
    | "repertoire" when Seq.length crepdlChildren = 0
      ->  hasDisallowedLocalAttribute ["registry"; "version"; "number"; "name"]
          let name = getAndTrimAttributeValue "name"
          let number = getAndTrimAttributeValue "number"
          match (name, number) with 
          | None, None -> failwith "Both @name and @number are missing"
          | _ -> ()
          let registryName = getAndTrimAttributeValue "registry"
          let registry = 
                match registryName with
                | Some("10646") -> ISO10646(name, Option.map int number)
                | Some("CLDR") -> CLDR(getAndTrimAttributeValue "version", name)
                | Some("IANA") -> IANA(name, Option.map int number)
                | Some("IVD") -> if name<>None then IVD(name.Value) else failwith "@name is missing"
                | Some(x) -> failwith ("undefined registry: " + x)
                | None -> failwith "@registry is missing"
          Repertoire(mode, minUV, maxUV, registry)
    | "char"
      ->  hasDisallowedLocalAttribute [] 
          let (k,h, flag) = 
            match crepdlChildren with
            | [] -> (Some(createRegexMatcher crepdl.Value), Some(createRegexMatcher crepdl.Value), true) 
            | [kernel] when crepdlChildren.[0].Name.LocalName = "kernel" 
                    -> (Some(createRegexMatcher crepdlChildren.[0].Value), None,false)
            | [hull] when crepdlChildren.[0].Name.LocalName = "hull" 
                -> (None, Some(createRegexMatcher crepdlChildren.[0].Value),false)
            | [kernel; hull] when crepdlChildren.[0].Name.LocalName = "kernel" 
                        && crepdlChildren.[1].Name.LocalName = "hull" 
                -> (Some(createRegexMatcher crepdlChildren.[0].Value), 
                    Some(createRegexMatcher crepdlChildren.[1].Value),
                    crepdlChildren.[0].Value = crepdlChildren.[1].Value)
            | _ -> failwith "Illegal content of a char element";
          Char(mode, minUV, maxUV, k, h, flag)
    | _ -> failwith ("Illegal element" + crepdl.Name.LocalName);


