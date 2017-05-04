// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

open System.Xml
open System.Xml.Linq
[<EntryPoint>]
let main argv = 
    let doc1 =  XDocument.Parse( @"<foo><ref/></foo>", LoadOptions.SetBaseUri)
    let doc2 =  XDocument.Parse( @"<bar/>", LoadOptions.SetBaseUri)
    let ref = doc1.Root.Element(XNamespace.None + "ref")
    ref.ReplaceWith(doc2.Root)
    System.Console.WriteLine(doc1.ToString())
    0 // return an integer exit code
