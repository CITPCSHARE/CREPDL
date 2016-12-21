module CREPDL.Basics

open System
open System.IO
open System.Reflection

[<Literal>]
let crepdlNamespace = "http://purl.oclc.org/dsdl/crepdl/ns/structure/1.0"

let memoize (f: 'a -> 'b) (size: int) =
    let hashtable = new System.Collections.Generic.Dictionary<'a, 'b>(size)
    fun x -> if hashtable.ContainsKey(x) then hashtable.[x]
             else (let res = f x in hashtable.[x] <- res; res);

let versionString2Int (vstr: string) =
    match vstr.Split('.') with
        | [|s1; s2; s3|] -> (int s1) * 10000 + (int s2) * 100 + (int s3)
        | [|s1; s2|] -> (int s1) * 10000 + (int s2) * 100
        | [|s1|] -> (int s1) * 10000
        | _ -> failwith "incorrect version number"
    
let absolute (baseUri: Uri) (href: string): Uri =
    new Uri(baseUri, href) 
 
let createUri (schemaUri: string) =
    if schemaUri.StartsWith("http:") then Uri schemaUri
    else if schemaUri.Substring(1).StartsWith(":") then Uri ("file://" + schemaUri)
    else Uri ("file://" + System.IO.Directory.GetCurrentDirectory() + "/" + schemaUri)

let getStreamReaderForEmbeddedResource fileName: StreamReader = 
    let asm = Assembly.GetExecutingAssembly()
    let names = asm.GetManifestResourceNames()
    for name in names do
        System.Console.WriteLine(name)
    System.Console.ReadKey() |> ignore
//    let path = Path.GetDirectoryName(asm.Location)
//    let ffn = Path.Combine(path, fileName)
    let ffn = fileName
    new StreamReader(asm.GetManifestResourceStream(ffn))