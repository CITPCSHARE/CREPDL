namespace CREPDLUnitTest

open NUnit.Framework
open System.IO
open CREPDL.CharMatcher
open CREPDL.ThreeValuedBoolean

[<TestFixture>]
[<Category("CharMatcher")>]
module CharMatcherTest =  


    [<TestCase("[ab]", "a", "c")>]
    [<TestCase(@"[\x00-\x7F]", "b", "あ")>]
    [<TestCase("\p{IsHiragana}", "あ", "ア")>]
    [<TestCase("\p{IsKatakana}", "ア", "あ")>]
    let createRegV1Test reg strGood strBad =
      let regex = createReg reg
      let mg = regex.Match(strGood)
      let mb = regex.Match(strBad)
      Assert.That(mg.Success && mg.Length = strGood.Length)
      Assert.That(not(mb.Success && mb.Length = strBad.Length))

      
    [<TestCase("\p{sc=Hira}")>]
    [<TestCase("\p{sc=Kana}")>]
    [<TestCase("\p{IsHenoHenoMoheji}")>]
    [<TestCase("(a")>]
    [<TestCase("b)")>]
    let failToCreateRegV1Test reg  =
      let result =
          Assert.Throws<System.ArgumentException>( new TestDelegate (fun() -> createReg reg |> ignore))
      TestContext.Out.WriteLine(result)
      
    
    [<TestCase("[ab]", "a", "c")>]
    [<TestCase(@"[\x00-\x7F]", "b", "あ")>]
    [<TestCase("\p{sc=Hira}", "あ", "ア")>]
    [<TestCase("\p{sc=Kana}", "ア", "あ")>]
    let createIcuRegV1Test reg (strGood: string) (strBad: string) =
      let regexMatcher = createRegexMatcher reg
      Assert.True(regexMatcher.Matches(strGood))
      Assert.False(regexMatcher.Matches(strBad))


    [<TestCase("(a")>]
    [<TestCase("b)")>]
    let failToCreateIcuRegV1Test reg  =
      let result =
          Assert.Throws<System.Exception>( new TestDelegate (fun() -> createRegexMatcher reg |> ignore))
      TestContext.Out.WriteLine(result)
    
    [<TestCase("\p{IsHiragana}")>]
    [<TestCase("\p{IsKatakana}")>]
    [<TestCase("\p{IsHenoHenoMoheji}")>]
    let failToCreateIcuRegV1TestArgumentException reg  =
      let result =
          Assert.Throws<System.ArgumentException>( new TestDelegate (fun() -> createRegexMatcher reg |> ignore))
      TestContext.Out.WriteLine(result)

    [<TestCase("ab", "ab", "adbc")>]
    [<TestCase("ab*", "abbb", "adbc")>]
    [<TestCase("ab*c", "abbbbc", "adbc")>]
    [<TestCase("ab*(c|d)", "abbbbbd", "adbc")>]
    let createRegV2TestFalse reg strGood strBad =
      let regex = createReg reg 
      let mg = regex.Match(strGood)
      let mb = regex.Match(strBad)
      Assert.That(mg.Success && mg.Length = strGood.Length)
      Assert.That(not(mb.Success && mb.Length = strBad.Length))


    [<TestCase("ab", "ab", "adbc")>]
    [<TestCase("ab*", "abbb", "adbc")>]
    [<TestCase("ab*c", "abbbbc", "adbc")>]
    [<TestCase("ab*(c|d)", "abbbbbd", "adbc")>]
    let createIcuRegV2TestFalse reg (strGood: string) (strBad: string) =
      let regexMatcher = createRegexMatcher reg
      Assert.True(regexMatcher.Matches(strGood))
      Assert.False(regexMatcher.Matches(strBad))


    [<TestCase("\U000216b4|a|b", "\U000216b4", "ac")>]
    [<TestCase("\u3402\U000E0103|a|b", "\u3402\U000E0103", "\u3402a")>]
    let createRegV2TestTrue reg strGood strBad =
      let regex = createReg reg 
      let mg = regex.Match(strGood)
      let mb = regex.Match(strBad)
      Assert.That(mg.Success && mg.Length = strGood.Length)
      Assert.That(not(mb.Success && mb.Length = strBad.Length))

    [<TestCase("\U000216b4|a|b", "\U000216b4", "ac")>]
    [<TestCase("\u3402\U000E0103|a|b", "\u3402\U000E0103", "\u3402a")>]
    let createIcuRegV2TestTrue reg (strGood: string) (strBad: string) =
      let regexMatcher = createRegexMatcher reg
      Assert.True(regexMatcher.Matches(strGood))
      Assert.False(regexMatcher.Matches(strBad))

    let CheckStringAgainstCharTestCases =
            [
            "1", Some(createRegexMatcher "1"), None,  false, 1, 1, True
            "2", Some(createRegexMatcher "1"), None,  false, 1, 1, Unknown
            "1", None, Some(createRegexMatcher "1"),  false, 1, 1, Unknown
            "2", None, Some(createRegexMatcher "1"),  false, 1, 1, False
            "2", Some(createRegexMatcher "1"), Some(createRegexMatcher "1"),  true, 1, 1, False
            "2", Some(createRegexMatcher "1"), Some(createRegexMatcher "1"),  false, 1, 1, False

            ] |> List.map (fun (s, kr, hr, flag, min, max, res) -> 
                   TestCaseData(s, kr, hr, flag, min, max, res))
        
    [<TestCaseSource("CheckStringAgainstCharTestCases")>]
    let checkStringAgainstCharTest str kr hr flag min max res =
         Assert.That(checkStringAgainstChar str kr hr flag (min, max), Is.EqualTo(res))