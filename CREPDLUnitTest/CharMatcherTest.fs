namespace CREPDLUnitTest

open NUnit.Framework
open System.IO
open CREPDL.CharMatcher
open CREPDL.ThreeValuedBoolean
open System.Text.RegularExpressions

[<TestFixture>]
[<Category("CharMatcher")>]
module CharMatcherTest =  


    [<TestCase("[ab]", "a", "c")>]
    [<TestCase(@"[\x00-\x7F]", "b", "あ")>]
    [<TestCase("\p{IsHiragana}", "あ", "ア")>]
    [<TestCase("\p{IsKatakana}", "ア", "あ")>]
    let createRegV1Test reg strGood strBad =
      let regex = createReg reg
      let mg = Regex.Match(strGood, regex)
      let mb = Regex.Match(strBad, regex)
      Assert.That(mg.Success && mg.Length = strGood.Length)
      Assert.That(not(mb.Success && mb.Length = strBad.Length))

      
    [<TestCase("\p{sc=Hira}")>]
    [<TestCase("\p{sc=Kana}")>]
    [<TestCase("\p{IsHenoHenoMoheji}")>]
    [<TestCase("(a")>]
    [<TestCase("b)")>]
    let failToCreateRegV1Test reg  =
      let result =
          Assert.Throws<System.Text.RegularExpressions.RegexParseException>( new TestDelegate (fun() -> 
          Regex.IsMatch("", createReg reg) |> ignore))
      TestContext.Out.WriteLine(result)
      


    [<TestCase("ab", "ab", "adbc")>]
    [<TestCase("ab*", "abbb", "adbc")>]
    [<TestCase("ab*c", "abbbbc", "adbc")>]
    [<TestCase("ab*(c|d)", "abbbbbd", "adbc")>]
    let createRegV2TestFalse reg strGood strBad =
      let regex = createReg reg 
      let mg = Regex.Match(strGood, regex)
      let mb = Regex.Match(strBad, regex)
      Assert.That(mg.Success && mg.Length = strGood.Length)
      Assert.That(not(mb.Success && mb.Length = strBad.Length))


    [<TestCase("\U000216b4|a|b", "\U000216b4", "ac")>]
    [<TestCase("\u3402\U000E0103|a|b", "\u3402\U000E0103", "\u3402a")>]
    let createRegV2TestTrue reg strGood strBad =
      let regex = createReg reg 
      let mg = Regex.Match(strGood, regex)
      let mb = Regex.Match(strBad, regex)
      Assert.That(mg.Success && mg.Length = strGood.Length)
      Assert.That(not(mb.Success && mb.Length = strBad.Length))

