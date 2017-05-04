namespace CREPDLUnitTest

open NUnit.Framework
open CREPDL.Repertoire
open System.IO
open CREPDL.ThreeValuedBoolean

[<TestFixture>]
[<Category("Repertoire")>]
module RepertoireTest =  


    let RepertoireTestCases =
            [
                "0x3000", "　", True
                "0x3000", "あ", False
                "0x3000, 0x3001", "　",  True
                "0x3000, 0x3001", "あ", False
                "0x0020\n0x3000\n0x7FFF", "　", True
                "0x0020\n0x3000\n0x7FFF", "あ", False
                "0xFAAB", "\uFAAB", True
            ] |> List.map (fun (q, n, d) -> TestCaseData(q,n,d))


    [<TestCaseSource("RepertoireTestCases")>]
    let createRepertoireFromTextReaderTest def str tb  =
        let f = createRepertoireFromTextReader (new StringReader(def)) 
        Assert.That(f str, Is.EqualTo(tb))