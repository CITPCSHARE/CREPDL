namespace CREPDLUnitTest

open NUnit.Framework
open System.IO
open CREPDL
open CREPDL.ReadGraphemeCluster

[<TestFixture>]
[<Category("ReadGraphemeCluster")>]
module ValidationTest =  
    let dir = @"H:\CREPDLScripts\examples\version2\characterMode\"
    let gcdir = @"H:\CREPDLScripts\examples\version2\graphemeClusterMode\"


    let validateString (scriptFileName: string) str  characterMode = 
            let x = System.DateTime.Now
            let validator = 
                if characterMode then  new CREPDLValidator(dir + scriptFileName)
                else new CREPDLValidator(gcdir + scriptFileName)
            let y = System.DateTime.Now
            printfn "%A" (y - x)
            let res = validator.validateString(str)
            printfn "%A" (System.DateTime.Now - y)
            res
    let numberOfCodePoints x = 
        let l = getGraphemeClusterEnumerator (new StringReader(x))
        Seq.length l
            
    [<TestCase("8859-15a.crepdl","abc", true)>]
    [<TestCase("8859-15c.crepdl","abc", true)>]
    [<TestCase("8859-15a.crepdl","abc", true)>]
    [<TestCase("8859-6b.crepdl", "abc", true)>]
    [<TestCase("IICORE.crepdl", "一二三四五征悟父暗漁禁己", true)>]
    [<TestCase("IICORE.crepdl", "\u35BF\u4C81\u4E66\u4EC1\u4F1D\u4FE1\u5074\u5112\u5173\u51C9\u5247\u5356\u53D8\u541B\u5492\u550F\u556E\u5608\u56AD\u5730\u57F8\u58F1\u596D\u5AE9\u5BA4\u5E43\u5F01\u5F82\u6159\u62D0\u7C73\u8DA3\u8E3D\u9328\u9756\u982D\u9F9B", true)>]
    [<TestCase("IICORE.crepdl", "\u35BF\u4E76\u5114\u5267\u5366\u53D9\u542B\u54A2\u5618\u56AE\u5740\u57F9\u58F3\u597D\u5AEA\u5F11\u5F92\u62D3\u7C83\u9348\u984D", true)>]
    [<TestCase("IICORE.crepdl",  "鷦鷲鷴鷸", true)>]
    [<TestCase("IICORE.crepdl", "\U0002070E\U00022EB3\U000269FA\U00027A3E\U0002815D\U00029D98", true)>]
    [<TestCase("jinmei2010.crepdl",  "猪蕪禍淚", true)>]
    [<TestCase("MSARG.crepdl",  "\u36C7\U000E0100", false)>]
    [<TestCase("MSARGRev.crepdl",  "\u36C7\U000E0100", false)>]
    [<TestCase("IVDAdobe-Japan1.crepdl",  "\u34BC\U000E0100\u34DB\U000E0100\u351F\U000E0100\u353E\U000E0100\u355D\U000E0100", false)>]
    let completelyTrue scriptFileName str mode =
        Assert.That(validateString scriptFileName str mode = ([||], [||]))

        
    [<TestCase("ArmenianA.crepdl", "abc", true)>]
    [<TestCase("ArmenianB.crepdl", "abc", true)>]
    [<TestCase("MalayalamA.crepdl", "abc", true)>]
    [<TestCase("MalayalamB.crepdl", "abc", true)>]
    [<TestCase("MalayalamC.crepdl", "abc", true)>]
    [<TestCase("MalayalamD.crepdl",  "abc", true)>]
    [<TestCase("MalayalamE.crepdl", "abc", true)>]
    [<TestCase("IICORE.crepdl", "\u4C83\u4EC2\u4F2D\u4FE2\u5084\u5183\u51CA\u551F\u556F\u5BA8\u5E53\u6179\u8DA6\u8E4D\u9796\u9FAB", true)>]
    [<TestCase("IICORE.crepdl", "\U00029D99", true)>]
    [<TestCase("IVDAdobe-Japan1.crepdl",  "\u36C7\U000E0100", false)>]
    [<TestCase("IVDMoji_Joho.crepdl",  "\u34BC\U000E0100\u34DB\U000E0100\u351F\U000E0100\u353E\U000E0100\u355D\U000E0100", false)>]
    [<TestCase("IVDMoji_Joho.crepdl",  "ab", false)>]
    [<TestCase("IVDMoji_Joho.crepdl",  "\n", false)>]
    [<TestCase("IVDMoji_Joho.crepdl",  "\r", false)>]
    [<TestCase("IVDMoji_Joho.crepdl",  "\r\n", false)>]
    [<TestCase("IVDMoji_Joho.crepdl",  "\u0065\u0301", false)>]
    let completelyFalse scriptFileName str characterMode =
        let unknowns, notIncluded = validateString scriptFileName str characterMode
        Assert.That(unknowns.Length = 0 && notIncluded.Length = numberOfCodePoints str)


    [<TestCase("Kyouiku1a.crepdl", "一二三四五征悟父暗漁禁己" , "", "征悟父暗漁禁己" , true)>]
    [<TestCase("Kyouiku1b.crepdl",  "一二三四五征悟父暗漁禁己"  , "", "征悟父暗漁禁己" , true)>]
    [<TestCase("Kyouiku2a.crepdl", "一二三四五征悟父暗漁禁己"  , "", "一二三四五征悟暗漁禁己" , true)>]
    [<TestCase("Kyouiku2b.crepdl", "一二三四五征悟父暗漁禁己"  , "", "一二三四五征悟暗漁禁己", true )>]
    [<TestCase("Kyouiku1-2.crepdl", "一二三四五征悟父暗漁禁己" , "", "征悟暗漁禁己", true )>]
    [<TestCase("Kyouiku1-3.crepdl", "一二三四五征悟父暗漁禁己"  , "", "征悟漁禁己", true )>]
    [<TestCase("Kyouiku1-4.crepdl", "一二三四五征悟父暗漁禁己" , "", "征悟禁己", true )>]
    [<TestCase("Kyouiku1-5.crepdl", "一二三四五征悟父暗漁禁己" , "", "征悟己", true )>]
    [<TestCase("Kyouiku1-6.crepdl", "一二三四五征悟父暗漁禁己" , "", "征悟", true )>]
    let testValidation scriptFileName str (unknownStr: string) (notIncludedStr: string) characterMode =
        let unknowns, notIncluded = validateString scriptFileName str characterMode
        Assert.That(unknowns.Length = unknownStr.Length && 
                        Array.forall (fun u -> unknownStr.Contains(u)) unknowns)
        Assert.That(notIncluded.Length = notIncludedStr.Length && 
                        Array.forall (fun n -> notIncludedStr.Contains(n)) notIncluded)



    [<TestCase("8859-15b.crepdl","abc", true)>]
    let throwsAnMiBenumError scriptFileName str characterMode =
        let ex = Assert.Catch<System.Exception>(fun () -> validateString scriptFileName str characterMode |> ignore)
        Assert.That(ex.Message.EndsWith("miBenum is not supported"))


    [<TestCase("RefLoop.crepdl","abc", true)>]
    let throwsAnErrorLoop scriptFileName str characterMode=
        let ex = Assert.Catch<System.Exception>(fun () -> validateString scriptFileName str characterMode |> ignore)
        Assert.That(ex.Message.StartsWith("Loop"))

        
    [<TestCase("IVDfoo.crepdl","abc", false    )>]
    let throwsAnErrorIVSCol scriptFileName str characterMode=
        let ex = Assert.Catch<System.Exception>(fun () -> validateString scriptFileName str characterMode |> ignore)
        Assert.That(ex.Message.StartsWith("IVD"))