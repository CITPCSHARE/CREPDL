namespace CREPDLUnitTest


open NUnit.Framework
open System.IO
open CREPDL.ISO10646Collection

[<TestFixture>]
[<Category("ISO10646Collection")>]
module ISO10646CollectionTest =  

    [<TestCase(96, "0x1760, 0x177F")>]
    let createRepertoireFromTextReaderInlineNumTest num content  =
      let tr = generateRepertoireFromISOCollection None (Some(num))
      Assert.That(tr.ReadToEnd(), Is.EqualTo(content))

    [<TestCase("TAGBANWA", "0x1760, 0x177F")>]
    let createRepertoireFromTextReaderInlineNameTest name content  =
      let tr = generateRepertoireFromISOCollection (Some(name)) None 
      Assert.That(tr.ReadToEnd(), Is.EqualTo(content))
      

    [<TestCase(301, "0x000020,0x00007E")>]
    let createRepertoireFromTextReaderOutofLineNumTest num content  =
      let tr = generateRepertoireFromISOCollection None (Some(num))
      Assert.That(tr.ReadToEnd().StartsWith(content))

    [<TestCase("IICORE", "0x034E4")>]
    let createRepertoireFromTextReaderOutofLineNameTest name content  =
      let tr = generateRepertoireFromISOCollection (Some(name)) None 
      Assert.That(tr.ReadToEnd().StartsWith(content))

    [<TestCase("UNICODE 6.3", "<union")>]
    let expandRepertoireCREPDLNameTest name startStr  =
      match expandRepertoireFromISOCollection (Some(name)) None with
      | Some(tr) -> Assert.That(tr.ReadToEnd().StartsWith(startStr))
      | _ -> Assert.Fail()

    [<TestCase(306, "<union")>]
    let expandRepertoireCREPDLNumTest num startStr  =
      match  expandRepertoireFromISOCollection None (Some(num))  with
      | Some(tr) -> Assert.That(tr.ReadToEnd().StartsWith(startStr))
      | _ -> Assert.Fail()
