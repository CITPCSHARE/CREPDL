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
    let unionTest (x: obj, y: obj, z: obj) =
        let ly () = unbox<ThreeValuedBoolean> y
        Assert.That(union (unbox<ThreeValuedBoolean> x) ly, Is.EqualTo<ThreeValuedBoolean>(unbox<ThreeValuedBoolean> z))

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
    let intersectionTest (x: obj, y: obj, z: obj) =
       let ly () = unbox<ThreeValuedBoolean> y
       Assert.That(intersection (unbox<ThreeValuedBoolean> x) ly, Is.EqualTo<ThreeValuedBoolean>(unbox<ThreeValuedBoolean> z))

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
    let  differenceTest (x: obj, y: obj, z: obj) =
        let ly () = unbox<ThreeValuedBoolean> y
        Assert.That(difference (unbox<ThreeValuedBoolean> x) ly, Is.EqualTo<ThreeValuedBoolean>(unbox<ThreeValuedBoolean> z))
