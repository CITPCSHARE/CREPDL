module CREPDL.Basics

open System
open System.IO
open System.Reflection

[<Literal>]
let crepdlNamespaceV2 = "http://purl.oclc.org/dsdl/crepdl/ns/structure/2.0"

type internal mode = CharacterMode | GraphemeClusterMode;;

let internal memoize (f: 'a -> 'b) (size: int) =
    let hashtable = new System.Collections.Generic.Dictionary<'a, 'b>(size)
    fun x -> if hashtable.ContainsKey(x) then hashtable.[x]
             else (let res = f x in hashtable.[x] <- res; res);

let internal versionString2Int (vstr: string) =
    match vstr.Split('.') with
        | [|s1; s2; s3|] -> (int s1) * 10000 + (int s2) * 100 + (int s3)
        | [|s1; s2|] -> (int s1) * 10000 + (int s2) * 100
        | [|s1|] -> (int s1) * 10000
        | _ -> failwith "incorrect version number"
    
let internal absolute (baseUri: Uri) (href: string): Uri =
    new Uri(baseUri, href) 
 
let internal createUri (schemaUri: string) =
    if schemaUri.StartsWith("http:") then Uri schemaUri
    else if schemaUri.Substring(1).StartsWith(":") then Uri ("file://" + schemaUri)
    else Uri ("file://" + Directory.GetCurrentDirectory() + "/" + schemaUri)

let internal getStreamReaderForEmbeddedResource fileName: StreamReader = 
    let asm = Assembly.GetExecutingAssembly()
    let strm = asm.GetManifestResourceStream("CREPDL." + fileName)
    new StreamReader(strm)

