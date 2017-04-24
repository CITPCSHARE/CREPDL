module CREPDLUnitTest.Basics

open NUnit.Framework
open FsUnit
open CREPDL.Basics
open Swensen.Unquote

[<Test>]
let memoizeTest() = 
    let memoizedFun =  memoize (function x -> x) 3
    let result = memoizedFun 3
    System.Console.WriteLine(result)
    test <@ result = 3 @>


[<Test>]
let versionString2Int1 () =
    test <@ versionString2Int "1.1" = 10100 @>

[<Test>]
let versionString2Int2 () =
    test <@ versionString2Int "1.2" = 10200 @>

    
[<Test>]
let versionString2Int3 () =
    test <@ versionString2Int "11.30" = 113000 @>

    
[<Test>]
let versionString2Int4 () =
    test <@ versionString2Int "9.9.0" = 90900 @>
    
let baseUri1 = new System.Uri("http://www.example.com/")

[<Test>]
let absolute1() =
    let resolvedUri = absolute baseUri1 "./a.html"
    let name = resolvedUri.AbsoluteUri
    test <@ name = "http://www.example.com/a.html" @>

[<Test>]   
let absolute2() =
    let resolvedUri = absolute baseUri1 "a.html"
    let name = resolvedUri.AbsoluteUri
    test <@ name = "http://www.example.com/a.html" @>

[<Test>]   
let absolute3() =
    let resolvedUri = absolute baseUri1 "../a.html"
    let name = resolvedUri.AbsoluteUri
    test <@ name = "http://www.example.com/a.html" @>

let baseUri2 = new System.Uri("http://www.example.com")

[<Test>]
let absolute4() =
    let resolvedUri = absolute baseUri2 "./a.html"
    let name = resolvedUri.AbsoluteUri
    test <@ name = "http://www.example.com/a.html" @>

[<Test>]   
let absolute5() =
    let resolvedUri = absolute baseUri2 "a.html"
    let name = resolvedUri.AbsoluteUri
    test <@ name = "http://www.example.com/a.html" @>

[<Test>]   
let absolute6() =
    let resolvedUri = absolute baseUri2 "../a.html"
    let name = resolvedUri.AbsoluteUri
    test <@ name = "http://www.example.com/a.html" @>

[<Test>]   
let createUri1 () =
    let uri = createUri "http://www.example.com" 
    test <@ uri.AbsoluteUri = "http://www.example.com/"  @>

[<Test>]   
let createUri2 () =
    let uri = createUri "http://www.example.com/" 
    test <@ uri.AbsoluteUri = "http://www.example.com/"  @>

[<Test>]   
let createUri3 () =
    let uri = createUri "c:/d.txt" 
    test <@ uri.AbsoluteUri = "file:///c:/d.txt"  @>

[<Test>]   
let createUri4 () =
    let uri = createUri "d.txt" 
    uri.AbsoluteUri |> should startWith "file:///"
    