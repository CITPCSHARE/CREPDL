namespace CREPDLUnitTest

open NUnit.Framework
open System.IO
open CREPDL.Basics
open CREPDL.ActivePattern
open CREPDL.ThreeValuedBoolean
open CREPDL.Registry
open System.Xml.Linq

[<TestFixture>]
[<Category("ActivePattern")>]
module ActivePatternTest =  

    [<Test>]
    let unionTest() =
        let script = 
            """
                <union maxUcsVersion="7.0" mode="character"
                xmlns="http://purl.oclc.org/dsdl/crepdl/ns/structure/2.0"/>
            """
        let schema = XDocument.Parse(script, LoadOptions.SetBaseUri).Root
        match schema with
        | Union(Some(mode), None, Some(max), children) ->
            Assert.AreEqual(mode, CharacterMode)
            Assert.AreEqual(max, versionString2Int "7.0")
            Assert.That(children.IsEmpty)
        | _ -> Assert.Fail()
            
    [<Test>]
    let differenceTest() =
        let script = 
            """
                <difference minUcsVersion="7.0" mode="graphemeCluster"
                    xmlns="http://purl.oclc.org/dsdl/crepdl/ns/structure/2.0">
                      <ref href="http://www.example.com/foo.crepdl"/>
                 </difference>
            """
        let schema = XDocument.Parse(script, LoadOptions.SetBaseUri).Root
        match schema with
        | Difference(Some(mode),Some(min), None, [child]) ->
            Assert.AreEqual(mode, GraphemeClusterMode)
            Assert.AreEqual(min, versionString2Int "7.0")
            match child with
            | Ref(None, None, None,  absUri, [])
              -> Assert.AreEqual(absUri.ToString(), "http://www.example.com/foo.crepdl")
            | _ -> Assert.Fail()
        | _ -> Assert.Fail()
                    
    [<Test>]
    let refTest1() =
        let script = 
            """
                <ref maxUcsVersion="7.0" mode="graphemeCluster"
                    xmlns="http://purl.oclc.org/dsdl/crepdl/ns/structure/2.0"
                     href="http://www.example.com/foo.crepdl"/>
            """
        let schema = XDocument.Parse(script, LoadOptions.SetBaseUri).Root
        match schema with
        | Ref(Some(mode), None, Some(max), absUri, [])
              -> 
                    Assert.AreEqual(mode, GraphemeClusterMode)
                    Assert.AreEqual(max, versionString2Int "7.0")
                    Assert.AreEqual(absUri.ToString(), "http://www.example.com/foo.crepdl")
        | _ -> Assert.Fail()

    [<Test>]
    let repertoireTest1() =
        let script = 
            """
                <repertoire registry="IANA" name="shift_jis"
                xmlns="http://purl.oclc.org/dsdl/crepdl/ns/structure/2.0"/>
            """
        let schema = XDocument.Parse(script, LoadOptions.SetBaseUri).Root
        match schema with
        | Repertoire(None, None, None, IANA(Some("shift_jis"), None))
            -> Assert.Pass()
        | _ -> Assert.Fail()

    [<Test>]
    let repertoireTest2() =
        let script = 
            """
                <repertoire registry="10646" number="5"
                xmlns="http://purl.oclc.org/dsdl/crepdl/ns/structure/2.0"/>
            """
        let schema = XDocument.Parse(script, LoadOptions.SetBaseUri).Root
        match schema with
        | Repertoire(None, None, None, ISO10646(None, Some(5)))
            -> Assert.Pass()
        | _ -> Assert.Fail()

        
    [<Test>]
    let repertoireTest3() =
        let script = 
            """
                <repertoire registry="CLDR" version="5" name="foo"
                xmlns="http://purl.oclc.org/dsdl/crepdl/ns/structure/2.0"/>
            """
        let schema = XDocument.Parse(script, LoadOptions.SetBaseUri).Root
        match schema with
        | Repertoire(None, None, None, CLDR(Some("5"), Some("foo")))
            -> Assert.Pass()
        | _ -> Assert.Fail()

    [<Test>]
    let charTest1() =
        let script = 
            """
                <char
                xmlns="http://purl.oclc.org/dsdl/crepdl/ns/structure/2.0">[a]</char>
            """
        let schema = XDocument.Parse(script, LoadOptions.SetBaseUri).Root
        match schema with
        | Char(None, None, None, Some(_), Some(_), true)
            -> Assert.Pass()
        | _ -> Assert.Fail()

        
    [<Test>]
    let charTest2() =
        let script = 
            """
                <char 
                xmlns="http://purl.oclc.org/dsdl/crepdl/ns/structure/2.0">
                  <kernel>[a]</kernel>
                </char>
            """
        let schema = XDocument.Parse(script, LoadOptions.SetBaseUri).Root
        match schema with
        | Char(None, None, None, Some(_), None, false)
            -> Assert.Pass()
        | _ -> Assert.Fail()

                
    [<Test>]
    let charTest3() =
        let script = 
            """
                <char
                xmlns="http://purl.oclc.org/dsdl/crepdl/ns/structure/2.0">
                  <hull>[a]</hull>
                </char>
            """
        let schema = XDocument.Parse(script, LoadOptions.SetBaseUri).Root
        match schema with
        | Char(None, None, None, None, Some(_), false)
            -> Assert.Pass()
        | _ -> Assert.Fail()

                
    [<Test>]
    let charTest4() =
        let script = 
            """
                <char
                xmlns="http://purl.oclc.org/dsdl/crepdl/ns/structure/2.0">
                  <kernel>[a]</kernel>
                  <hull>[b]</hull>
                </char>
            """
        let schema = XDocument.Parse(script, LoadOptions.SetBaseUri).Root
        match schema with
        | Char(None, None, None, Some(_), Some(_), false)
            -> Assert.Pass()
        | _ -> Assert.Fail()

        
    [<Test>]
    let charTest5() =
        let script = 
            """
                <char 
                xmlns="http://purl.oclc.org/dsdl/crepdl/ns/structure/2.0">
                  <kernel>[a]</kernel>
                  <hull>[a]</hull>
                </char>
            """
        let schema = XDocument.Parse(script, LoadOptions.SetBaseUri).Root
        match schema with
        | Char(None, None, None, Some(_), Some(_), true)
            -> Assert.Pass()
        | _ -> Assert.Fail()
