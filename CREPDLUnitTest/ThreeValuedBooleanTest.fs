namespace CREPDLUnitTest

open NUnit.Framework
open CREPDL.ThreeValuedBoolean

[<TestFixture>]
module ThreeValuedBooleanTest =

    let UnionCases =
            [
                True, True, True
                True, Unknown, True
                True, False, True
                False, True, True
                False, Unknown, Unknown
                False, False, False
                Unknown, True, True
                Unknown, Unknown, Unknown
                Unknown, False, Unknown
            ] |> List.map (fun (q, n, d) -> TestCaseData(box q, box n, box d))

    [<TestCaseSource("UnionCases")>]
    [<Category("ThreeValuedBoolean")>]
    let unionTest (x, y, z) =
        let ly = function() -> (unbox y)
        Assert.AreEqual(union (unbox x) ly, unbox z)

    let IntersectionCases =
            [
                True, True, True
                True, Unknown, Unknown
                True, False, False
                False, True, False
                False, Unknown, False
                False, False, False
                Unknown, True, Unknown
                Unknown, Unknown, Unknown
                Unknown, False, False
            ] |> List.map (fun (q, n, d) -> TestCaseData(box q, box n, box d))

    [<TestCaseSource("IntersectionCases")>]
    [<Category("ThreeValuedBoolean")>]
    let intersectionTest (x, y, z) =
       let ly = function() -> (unbox y)
       Assert.AreEqual(intersection (unbox x) ly,  (unbox z))

    let DifferenceCases =
            [
                True, True, False
                True,  Unknown, Unknown
                True, False, True
                False, True, False
                False, Unknown, False
                False, False, False
                Unknown, True, False
                Unknown, Unknown, Unknown
                Unknown, False, Unknown
            ] |> List.map (fun (q, n, d) -> TestCaseData(box q, box n, box d))

    [<TestCaseSource("DifferenceCases")>]
    [<Category("ThreeValuedBoolean")>]
    let  differenceTest (x , y, z) =
        let ly = function() -> (unbox y)
        Assert.AreEqual(difference (unbox x) ly,  unbox z)
