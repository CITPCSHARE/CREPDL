
module CREPDLTest.Test
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
open Kyouiku


let dir = @"H:\CREPDLScripts\examples\"

let startTime = System.DateTime.Now in
let repCol = createRepertoireCollection rbtCollections deweyCollections in

System.Console.WriteLine(System.DateTime.Now - startTime)


System.Console.ReadKey() |> ignore;;

constructAll10646Collections repCol

System.Console.WriteLine "8859-15"

validateString repCol (dir + "8859-15a.crepdl") "abc" System.Console.Out |> writeThreeValuedBoolean
validateString repCol (dir + "8859-15b.crepdl") "abc" System.Console.Out |> writeThreeValuedBoolean
validateString repCol (dir + "8859-15c.crepdl") "abc" System.Console.Out |> writeThreeValuedBoolean

System.Console.WriteLine "8859-6"

validateString repCol (dir + "8859-6a.crepdl") "abc" System.Console.Out |> writeThreeValuedBoolean
validateString repCol (dir + "8859-6b.crepdl") "abc" System.Console.Out |> writeThreeValuedBoolean


System.Console.ReadKey() |> ignore;;
System.Console.WriteLine "Armenian"

validateString repCol (dir + "ArmenianA.crepdl") "abc" System.Console.Out |> writeThreeValuedBoolean
validateString repCol (dir + "ArmenianB.crepdl") "abc" System.Console.Out |> writeThreeValuedBoolean


System.Console.WriteLine "Malayalam"

validateString repCol (dir + "MalayalamA.crepdl") "abc" System.Console.Out |> writeThreeValuedBoolean
validateString repCol (dir + "MalayalamB.crepdl") "abc" System.Console.Out |> writeThreeValuedBoolean
validateString repCol (dir + "MalayalamC.crepdl") "abc" System.Console.Out |> writeThreeValuedBoolean
validateString repCol (dir + "MalayalamD.crepdl")  "abc" System.Console.Out |> writeThreeValuedBoolean
validateString repCol (dir + "MalayalamE.crepdl") "abc" System.Console.Out |> writeThreeValuedBoolean

System.Console.ReadKey() |> ignore;;

testKyouiku repCol dir

System.Console.ReadKey() |> ignore;;


System.Console.WriteLine "IICORE"
System.Console.WriteLine "Should be true"
validateString repCol (dir + "IICORE.crepdl") "一二三四五征悟父暗漁禁己" System.Console.Out |> writeThreeValuedBoolean
validateString repCol (dir + "IICORE.crepdl") "\u35BF\u4C81\u4E66\u4EC1\u4F1D\u4FE1\u5074\u5112\u5173\u51C9\u5247\u5356\u53D8\u541B\u5492\u550F\u556E\u5608\u56AD\u5730\u57F8\u58F1\u596D\u5AE9\u5BA4\u5E43\u5F01\u5F82\u6159\u62D0\u7C73\u8DA3\u8E3D\u9328\u9756\u982D\u9F9B" System.Console.Out |> writeThreeValuedBoolean

validateString repCol (dir + "IICORE.crepdl") "\u35BF\u4E76\u5114\u5267\u5366\u53D9\u542B\u54A2\u5618\u56AE\u5740\u57F9\u58F3\u597D\u5AEA\u5F11\u5F92\u62D3\u7C83\u9348\u984D"  System.Console.Out |> writeThreeValuedBoolean

System.Console.WriteLine "Should be false"
validateString repCol (dir + "IICORE.crepdl") "\u4C83\u4EC2\u4F2D\u4FE2\u5084\u5183\u51CA\u551F\u556F\u5BA8\u5E53\u6179\u8DA6\u8E4D\u9796\u9FAB" System.Console.Out |> writeThreeValuedBoolean


System.Console.ReadKey() |> ignore;;

System.Console.WriteLine "Non-BMP"
validateString repCol (dir + "IICORE.crepdl") "𤸀𤸁𤸂𤸃" System.Console.Out |> writeThreeValuedBoolean


System.Console.ReadKey() |> ignore;;

System.Console.WriteLine "Should be true but ...."
validateString repCol (dir + "IICORE.crepdl") "\U0002070E\U00022EB3\U000269FA\U00027A3E\U0002815D" System.Console.Out |> writeThreeValuedBoolean



System.Console.ReadKey() |> ignore;;
try
    validateString repCol (dir + "RefLoop.crepdl") "" System.Console.Out |> writeThreeValuedBoolean
with
    | Failure msg 
        -> System.Console.WriteLine(msg)
        
System.Console.WriteLine "人名漢字 2010 "
validateString repCol (dir + "jinmei2010.crepdl") "一二三四五征悟父暗漁禁己\u35BE亞" System.Console.Out |> writeThreeValuedBoolean


System.Console.ReadKey() |> ignore;;