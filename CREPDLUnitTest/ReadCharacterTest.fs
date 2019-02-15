namespace CREPDLUnitTest

open NUnit.Framework
open System.IO
open CREPDL.ReadCharacter

[<TestFixture>]
[<Category("ReadCharacter")>]
module ReadCharacterTest =  
    let str = "\U00025771aあbい\U00025771m村t田"
    let l = ["\U00025771"; "a"; "あ"; "b"; "い"; "\U00025771"; "m"; "村"; "t"; "田"]

    [<Test>]
    let readGCTest1() =
        let sr = new StringReader(str)
        let x = getCharacterEnumerator sr
        let mutable result = []
        for c in x do result <- c::result
        Assert.AreEqual(l, List.rev result)
        
    [<Test>]
    let readGCTest2() =
        let sr = new StringReader(str  + str)
        let x = getCharacterEnumerator sr
        let mutable result = []
        for c in x do result <- c::result
        Assert.AreEqual(List.append l l, List.rev result)