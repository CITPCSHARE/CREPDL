namespace CREPDLUnitTest

open NUnit.Framework
open CREPDL.Basics

[<TestFixture>]
[<Category("Basics")>]
module BasicsTest =

    [<Test>]
    let memoizeTest()  = 
        let memoizedFun =  memoize (function x -> x) 100
        let result  = memoizedFun 3
        Assert.That( 3 = result )

    [<TestCase("1.1", ExpectedResult = 10100)>]
    [<TestCase("1.2", ExpectedResult = 10200)>]
    [<TestCase("11.30", ExpectedResult = 113000)>]
    [<TestCase("9.9.0", ExpectedResult = 90900)>]
    let versionString2IntTest s =
        versionString2Int s

    [<TestCase("http://www.example.com/", "./a.html",  ExpectedResult = "http://www.example.com/a.html")>]
    [<TestCase("http://www.example.com/", "a.html",    ExpectedResult = "http://www.example.com/a.html")>]
    [<TestCase("http://www.example.com/", "../a.html", ExpectedResult = "http://www.example.com/a.html")>]
    [<TestCase("http://www.example.com",  "./a.html",  ExpectedResult = "http://www.example.com/a.html")>]
    [<TestCase("http://www.example.com",  "a.html",    ExpectedResult = "http://www.example.com/a.html")>]
    [<TestCase("http://www.example.com",  "../a.html",    ExpectedResult = "http://www.example.com/a.html")>]
    let absoluteTest baseUri relUri =
        let baseUri = System.Uri baseUri
        (absolute baseUri relUri).AbsoluteUri


    [<TestCase("http://www.example.com",  ExpectedResult = "http://www.example.com/")>] 
    [<TestCase("http://www.example.com/",  ExpectedResult = "http://www.example.com/")>] 
    [<TestCase("c:/d.txt",                 ExpectedResult = "file:///c:/d.txt")>] 
    let createUriTest1 uriStr =
        let uri = createUri uriStr
        uri.AbsoluteUri

    [<TestCase("d.txt",                 ExpectedResult = true)>] 
    let createUriTest2 uriStr =
        let uri = createUri uriStr
        (uri.AbsoluteUri).StartsWith  "file:///"
