namespace CREPDLUnitTest

open NUnit.Framework
open System.IO
open CREPDL.CharMatcher
open CREPDL.ThreeValuedBoolean

[<TestFixture>]
[<Category("CharMatcher")>]
module CharMatcherTest =  


    [<TestCase("[ab]", "a", "c")>]
    [<TestCase("[\p{IsBasicLatin}]", "b", "あ")>]
    let createRegV1Test reg strGood strBad =
      let regex = createRegV1 reg
      let mg = regex.Match(strGood)
      let mb = regex.Match(strBad)
      Assert.That(mg.Success && mg.Length = strGood.Length)
      Assert.That(not(mb.Success && mb.Length = strBad.Length))

    [<TestCase("ab", "ab", "adbc")>]
    [<TestCase("ab*", "abbb", "adbc")>]
    [<TestCase("ab*c", "abbbbc", "adbc")>]
    [<TestCase("ab*(c|d)", "abbbbbd", "adbc")>]
    let createRegV2TestFalse reg strGood strBad =
      let regex = createRegV2 reg false
      let mg = regex.Match(strGood)
      let mb = regex.Match(strBad)
      Assert.That(mg.Success && mg.Length = strGood.Length)
      Assert.That(not(mb.Success && mb.Length = strBad.Length))


    [<TestCase("\U000216b4|a|b", "\U000216b4", "ac")>]
    [<TestCase("\u3402\U000E0103|a|b", "\u3402\U000E0103", "\u3402a")>]
    let createRegV2TestTrue reg strGood strBad =
      let regex = createRegV2 reg true
      let mg = regex.Match(strGood)
      let mb = regex.Match(strBad)
      Assert.That(mg.Success && mg.Length = strGood.Length)
      Assert.That(not(mb.Success && mb.Length = strBad.Length))

    let CheckStringAgainstCharTestCases =
            [
            "1", Some(createRegV1 "1"), None,  false, 1, 1, True
            "2", Some(createRegV1 "1"), None,  false, 1, 1, Unknown
            "1", None, Some(createRegV1 "1"),  false, 1, 1, Unknown
            "2", None, Some(createRegV1 "1"),  false, 1, 1, False
            "2", Some(createRegV1 "1"), Some(createRegV1 "1"),  true, 1, 1, False
            "2", Some(createRegV1 "1"), Some(createRegV1 "1"),  false, 1, 1, False

            ] |> List.map (fun (s, kr, hr, flag, min, max, res) -> 
                   TestCaseData(s, kr, hr, flag, min, max, res))
        
    [<TestCaseSource("CheckStringAgainstCharTestCases")>]
    let checkStringAgainstCharTest str kr hr flag min max res =
         Assert.That(checkStringAgainstChar str kr hr flag (min, max) = res)