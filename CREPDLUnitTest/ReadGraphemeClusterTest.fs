namespace CREPDLUnitTest

open NUnit.Framework
open System.IO
open CREPDL.ReadGraphemeCluster

[<TestFixture>]
[<Category("ReadGraphemeCluster")>]
module ReadGraphemeClusterTest =  


    [<TestCase("a", "a")>]
    [<TestCase("\u00C5", "\u00C5")>]
    [<TestCase("\u00C5\u0073\u0074\u0072\u00F6\u006D", //Åström (U+00C5 U+0073 U+0074 U+0072 U+00F6 U+006D)
              "\u00C5 \u0073 \u0074 \u0072 \u00F6 \u006D")>]
    [<TestCase("\u0041\u030A\u0073\u0074\u0072\u006F\u0308\u006D", //Åström (U+0041 U+030A U+0073 U+0074 U+0072 U+006F U+0308 U+006D)
                "\u0041\u030A \u0073 \u0074 \u0072 \u006F\u0308 \u006D")>]
    [<TestCase("\u3402\U000E0103,,あ　ば,a\u3402\U000E0103", "\u3402\U000E0103 , , あ \u3000 ば , a \u3402\U000E0103")>] //㐂󠄃,,あ　ば,a㐂󠄃
    [<TestCase("煉󠄁獄杏寿郎", "煉\U000E0101 獄 杏 寿 郎")>]
    [<TestCase("煉\U000E0101獄", "煉\U000E0101 獄")>]
    [<TestCase("\U0001F468\u200D\U0001F37C", // man feeding baby (emoji)
                "\U0001F468\u200D\U0001F37C")>]
    let readGCTest1 str (splitStr: string)  =
        let l = List.ofArray (splitStr.Split(' '))
        let sr = new StringReader(str)
        let x = getGraphemeClusterEnumerator sr
        let mutable result = []
        for gc in x do result <- gc::result
        Assert.AreEqual(l, List.rev result)
        

