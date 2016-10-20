module CREPDLTest.Kyouiku

open System
open CREPDL.Basics
open CREPDL.Validation
open CREPDL.Repertoire
open CREPDL.RepertoireCollection
open CREPDL.ISO10646Collection
open CREPDL.ThreeValuedBoolean
open CREPDL.ReadingCREPDL
open CREPDL.TopLevelValidation
open ConstructAllCollections

let testKyouiku repCol dir =
    System.Console.WriteLine "教育漢字一年生"
    validateString repCol (dir + "Kyouiku1a.crepdl") "一二三四五征悟父暗漁禁己" System.Console.Out |> writeThreeValuedBoolean
    validateString repCol (dir + "Kyouiku1b.crepdl")  "一二三四五征悟父暗漁禁己" System.Console.Out |> writeThreeValuedBoolean
    System.Console.WriteLine "教育漢字二年生"
    validateString repCol (dir + "Kyouiku2a.crepdl") "一二三四五征悟父暗漁禁己" System.Console.Out |> writeThreeValuedBoolean
    validateString repCol (dir + "Kyouiku2b.crepdl") "一二三四五征悟父暗漁禁己" System.Console.Out |> writeThreeValuedBoolean
    System.Console.WriteLine "教育漢字一二年生"
    validateString repCol (dir + "Kyouiku1-2.crepdl") "一二三四五征悟父暗漁禁己" System.Console.Out |> writeThreeValuedBoolean
    System.Console.WriteLine "教育漢字一二三年生"
    validateString repCol (dir + "Kyouiku1-3.crepdl") "一二三四五征悟父暗漁禁己" System.Console.Out |> writeThreeValuedBoolean
    System.Console.WriteLine "教育漢字一二三四年生"
    validateString repCol (dir + "Kyouiku1-4.crepdl") "一二三四五征悟父暗漁禁己" System.Console.Out |> writeThreeValuedBoolean
    System.Console.WriteLine "教育漢字一二三四五年生"
    validateString repCol (dir + "Kyouiku1-5.crepdl") "一二三四五征悟父暗漁禁己" System.Console.Out |> writeThreeValuedBoolean
    System.Console.WriteLine "教育漢字一二三四五六年生"
    validateString repCol (dir + "Kyouiku1-6.crepdl") "一二三四五征悟父暗漁禁己" System.Console.Out |> writeThreeValuedBoolean
