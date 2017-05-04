namespace CREPDLUnitTest

open NUnit.Framework
open System.IO
open CREPDL.ReadGraphemeCluster

[<TestFixture>]
[<Category("ReadGraphemeCluster")>]
module ReadGraphemeClusterTest =  


    let str = "\u3402\U000E0103,,あ　ば ,a"
    let l = ["\u3402\U000E0103"; ","; ","; "あ"; "　"; "ば"; " "; ","; "a"]

    [<Test>]
    let readGCTest1() =
        let sr = new StringReader(str)
        let x = getGraphemeClusterEnumerator sr
        let mutable result = []
        for gc in x do result <- gc::result
        Assert.AreEqual(l, List.rev result)

    [<Test>]
    let readGCTest2() =
        let sr = new StringReader(str + "\n" + str)
        let x = getGraphemeClusterEnumerator sr
        let mutable result = []
        for gc in x do result <- gc::result
        Assert.AreEqual(List.append l l, List.rev result)

