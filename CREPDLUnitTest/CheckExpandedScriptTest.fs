namespace CREPDLUnitTest


open NUnit.Framework
open CREPDL.CheckExpandedScript
open System
open System.Xml
open System.Xml.Linq

[<TestFixture>]
module CheckExpandedScriptTest =
 
    [<TestCase(@"<union><char>[a]</char></union>", true)>]
    [<TestCase(@"<union><char mode=""character"">[a]</char></union>", true)>]
    [<TestCase(@"<union><char mode=""graphemeCluster"">[a]</char></union>", false)>]
    [<TestCase(@"<union mode=""character""><char>[a]</char></union>", true)>]
    [<TestCase(@"<union mode=""character""><char mode=""character"">[a]</char></union>", true)>]
    [<TestCase(@"<union mode=""character""><char mode=""graphemeCluster"">[a]</char></union>", false)>]
    [<TestCase(@"<union mode=""graphemeCluster""><char>[a]</char></union>", true)>]
    [<TestCase(@"<union mode=""graphemeCluster""><char mode=""character"">[a]</char></union>", false)>]
    [<TestCase(@"<union mode=""graphemeCluster""><char mode=""graphemeCluster"">[a]</char></union>", true)>]
    let checkModeConsistencyTest (str: string) good =
        let nsAdded = str.Replace("<union", @"<union 
                            xmlns=""http://purl.oclc.org/dsdl/crepdl/ns/structure/2.0"" ")
        let doc = XDocument.Parse(nsAdded)
        let f = new TestDelegate(fun () -> 
                                    checkModeConsistency doc.Root)
        if good then Assert.DoesNotThrow(f)
        else 
             Assert.AreEqual(Assert.Throws<Exception>(f ).Message,"Different mode")
