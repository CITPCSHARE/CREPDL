namespace CREPDLUnitTest

open NUnit.Framework
open System.IO
open CREPDL.Validation
open CREPDL.ReadGraphemeCluster

[<TestFixture>]
[<Category("ReadGraphemeCluster")>]
module ValidationTest =  
    let dir = @"H:\CREPDLScripts\examples\version2\characterMode\"

    let validateString (scriptFileName: string) str = 
            let x = System.DateTime.Now
            let validator = new Validator(dir + scriptFileName)
            let y = System.DateTime.Now
            printfn "%A" (y - x)
            let res = validator.validateString(str)
            printfn "%A" (System.DateTime.Now - y)
            res
    let numberOfCodePoints x = 
        let l = getGraphemeClusterEnumerator (new StringReader(x))
        Seq.length l
            
    [<TestCase("8859-15a.crepdl","abc")>]
    [<TestCase("8859-15c.crepdl","abc")>]
    [<TestCase("8859-15a.crepdl","abc")>]
    [<TestCase("8859-6b.crepdl", "abc")>]
    [<TestCase("IICORE.crepdl", "一二三四五征悟父暗漁禁己")>]
    [<TestCase("IICORE.crepdl", "\u35BF\u4C81\u4E66\u4EC1\u4F1D\u4FE1\u5074\u5112\u5173\u51C9\u5247\u5356\u53D8\u541B\u5492\u550F\u556E\u5608\u56AD\u5730\u57F8\u58F1\u596D\u5AE9\u5BA4\u5E43\u5F01\u5F82\u6159\u62D0\u7C73\u8DA3\u8E3D\u9328\u9756\u982D\u9F9B")>]
    [<TestCase("IICORE.crepdl", "\u35BF\u4E76\u5114\u5267\u5366\u53D9\u542B\u54A2\u5618\u56AE\u5740\u57F9\u58F3\u597D\u5AEA\u5F11\u5F92\u62D3\u7C83\u9348\u984D")>]
    [<TestCase("IICORE.crepdl",  "鷦鷲鷴鷸")>]
    [<TestCase("IICORE.crepdl", "\U0002070E\U00022EB3\U000269FA\U00027A3E\U0002815D\U00029D98")>]
    [<TestCase("jinmei2010.crepdl",  "猪蕪禍淚")>]
    let completelyTrue scriptFileName str =
        Assert.That(validateString scriptFileName str = ([], []))

        
    [<TestCase("ArmenianA.crepdl", "abc")>]
    [<TestCase("ArmenianB.crepdl", "abc")>]
    [<TestCase("MalayalamA.crepdl", "abc")>]
    [<TestCase("MalayalamB.crepdl", "abc")>]
    [<TestCase("MalayalamC.crepdl", "abc")>]
    [<TestCase("MalayalamD.crepdl",  "abc")>]
    [<TestCase("MalayalamE.crepdl", "abc")>]
    [<TestCase("IICORE.crepdl", "\u4C83\u4EC2\u4F2D\u4FE2\u5084\u5183\u51CA\u551F\u556F\u5BA8\u5E53\u6179\u8DA6\u8E4D\u9796\u9FAB")>]
    [<TestCase("IICORE.crepdl", "\U00029D99")>]
    let completelyFalse scriptFileName str =
        let unknowns, notIncluded = validateString scriptFileName str 
        Assert.That(unknowns.IsEmpty && notIncluded.Length = numberOfCodePoints str)


    [<TestCase("Kyouiku1a.crepdl", "一二三四五征悟父暗漁禁己" , "", "征悟父暗漁禁己" )>]
    [<TestCase("Kyouiku1b.crepdl",  "一二三四五征悟父暗漁禁己"  , "", "征悟父暗漁禁己" )>]
    [<TestCase("Kyouiku2a.crepdl", "一二三四五征悟父暗漁禁己"  , "", "一二三四五征悟暗漁禁己" )>]
    [<TestCase("Kyouiku2b.crepdl", "一二三四五征悟父暗漁禁己"  , "", "一二三四五征悟暗漁禁己" )>]
    [<TestCase("Kyouiku1-2.crepdl", "一二三四五征悟父暗漁禁己" , "", "征悟暗漁禁己" )>]
    [<TestCase("Kyouiku1-3.crepdl", "一二三四五征悟父暗漁禁己"  , "", "征悟漁禁己" )>]
    [<TestCase("Kyouiku1-4.crepdl", "一二三四五征悟父暗漁禁己" , "", "征悟禁己" )>]
    [<TestCase("Kyouiku1-5.crepdl", "一二三四五征悟父暗漁禁己" , "", "征悟己" )>]
    [<TestCase("Kyouiku1-6.crepdl", "一二三四五征悟父暗漁禁己" , "", "征悟" )>]
    let testValidation scriptFileName str (unknownStr: string) (notIncludedStr: string) =
        let unknowns, notIncluded = validateString scriptFileName str 
        Assert.That(unknowns.Length = unknownStr.Length && 
                        List.forall (fun u -> unknownStr.Contains(u)) unknowns)
        Assert.That(notIncluded.Length = notIncludedStr.Length && 
                        List.forall (fun n -> notIncludedStr.Contains(n)) notIncluded)



    [<TestCase("8859-15b.crepdl","abc")>]
    let throwsAnMiBenumError scriptFileName str =
        let ex = Assert.Catch<System.Exception>(fun () -> validateString scriptFileName str |> ignore)
        Assert.That(ex.Message.EndsWith("miBenum is not supported"))


    [<TestCase("RefLoop.crepdl","abc")>]
    let throwsAnError scriptFileName str =
        let ex = Assert.Catch<System.Exception>(fun () -> validateString scriptFileName str |> ignore)
        Assert.That(ex.Message.StartsWith("Loop"))

