module CREPDL.ActivePattern

open System;
open System.IO;
open System.Xml.Linq;
open System.Text.RegularExpressions;
open System.Text;

open Repertoire;

open Basics;
let createReg (regStr: string): Regex =
    if regStr.Length = 1 //Char or WildCardEsc
        || (regStr.StartsWith("[") && regStr.EndsWith("]")) //charClassExpr
        || (regStr.StartsWith("\\") && regStr.Length = 2) //SingleCharEsc or MultiCharEsc
        || (let chReg = new Regex("\\\P{.+}") in chReg.Match(regStr).Success) //catExc or complEsc  "\\P{[\{\}]+}"
        || (let chReg = new Regex("\\\p{.+}") in chReg.Match(regStr).Success) //catExc or complEsc  "\\p{[\{\}]+}"
    then new Regex(regStr)
    else failwith  ("illegal regular expression: " +  regStr);

let (|Union|Intersection|Difference|Ref|Repertoire|Char|Illegal|) (crepdl: XElement):
      Choice<int option * int option * XElement list, 
             int option * int option * XElement list, 
             int option * int option * XElement list, 
             int option * int option * Uri, 
             int option * int option * Registry, 
             int option * int option * Regex option * Regex option, 
             unit> =
  let crepdlChildren =
    List.filter (fun (c: XElement) -> c.Name.NamespaceName.Equals crepdlNamespace) 
                (Seq.toList (crepdl.Elements()))  
  let getAndTrimAttributeValue (name: string): string option =
    let at = crepdl.Attribute(XNamespace.None + name)
    if at = null then None else Some(at.Value.Trim())
  let minUV = 
    let atv = getAndTrimAttributeValue "minUcsVersion"
    Option.map versionString2Int atv 
  let maxUV = 
    let atv = getAndTrimAttributeValue "maxUcsVersion"
    Option.map versionString2Int atv 
         
  let hasDisallowedLocalAttribute (allowedAtts: string list) =             
    for at in crepdl.Attributes() do
        if (not at.IsNamespaceDeclaration) &&
           at.Name.NamespaceName.Equals("") &&
           at.Name.LocalName <> "minUcsVersion" && 
           at.Name.LocalName <> "maxUcsVersion" &&
           (List.forall (fun str -> at.Name.LocalName <> str) allowedAtts)
        then failwith ("An illegal attribute: " + at.Name.LocalName)
              

  match crepdl.Name.LocalName with
    | "union"
      -> hasDisallowedLocalAttribute []
         Union(minUV, maxUV, crepdlChildren)
    | "intersection"
      ->  hasDisallowedLocalAttribute [] 
          Intersection(minUV, maxUV, crepdlChildren)
    | "difference" 
      ->  hasDisallowedLocalAttribute []
          Difference(minUV, maxUV, crepdlChildren)
    | "ref"
      ->  hasDisallowedLocalAttribute ["href"] 
          Ref(minUV, maxUV,  
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
                | Some(x) -> UNDEFINED(x)
                | None -> failwith "@registry is missing"
          Repertoire(minUV, maxUV, registry)
    | "char"
      ->  hasDisallowedLocalAttribute [] 
          let (k,h) = match crepdlChildren with
                            | [] -> (Some(createReg crepdl.Value), Some(createReg crepdl.Value)) 
                            | [kernel] when crepdlChildren.[0].Name.LocalName = "kernel" 
                                 -> (Some(createReg crepdlChildren.[0].Value), None)
                            | [hull] when crepdlChildren.[0].Name.LocalName = "hull" 
                               -> (None, Some(createReg crepdlChildren.[0].Value))
                            | [kernel; hull] when crepdlChildren.[0].Name.LocalName = "kernel" 
                                      && crepdlChildren.[1].Name.LocalName = "hull" 
                                -> (Some(createReg crepdlChildren.[0].Value), Some(createReg crepdlChildren.[1].Value))
                            | _ -> failwith "Illegal content of a char element";
          Char(minUV, maxUV, k, h)
    | _ -> failwith ("Illegal element" + crepdl.Name.LocalName);
