namespace CREPDLUnitTest

open NUnit.Framework
open CREPDL.ThreeValuedBoolean

[<TestFixture>]
module ThreeValuedBooleanTest =

    let UnionCases =
            [
                True, (function () -> True), True
                True, (function () -> Unknown), True
                True, (function () -> False), True
                False, (function () -> True), True
                False, (function () -> Unknown), Unknown
                False, (function () -> False), False
                Unknown, (function () -> True), True
                Unknown, (function () -> Unknown), Unknown
                Unknown, (function () -> False), Unknown
            ] |> List.map (fun (q, n, d) -> TestCaseData(q,n,d))

    [<TestCaseSource("UnionCases")>]
    [<Category("ThreeValuedBoolean")>]
    let internal unionTest (x, (y: unit -> ThreeValuedBoolean), z: ThreeValuedBoolean) =
       Assert.AreEqual(union x y,  z)

    let IntersectionCases =
            [
                True, (function () -> True), True
                True, (function () -> Unknown), Unknown
                True, (function () -> False), False
                False, (function () -> True), False
                False, (function () -> Unknown), False
                False, (function () -> False), False
                Unknown, (function () -> True), Unknown
                Unknown, (function () -> Unknown), Unknown
                Unknown, (function () -> False), False
            ] |> List.map (fun (q, n, d) -> TestCaseData(q,n,d))

    [<TestCaseSource("IntersectionCases")>]
    [<Category("ThreeValuedBoolean")>]
    let internal intersectionTest (x, (y: unit -> ThreeValuedBoolean), z: ThreeValuedBoolean) =
       Assert.AreEqual(intersection x y,  z)

    let DifferenceCases =
            [
                True, (function () -> True), False
                True, (function () -> Unknown), Unknown
                True, (function () -> False), True
                False, (function () -> True), False
                False, (function () -> Unknown), False
                False, (function () -> False), False
                Unknown, (function () -> True), False
                Unknown, (function () -> Unknown), Unknown
                Unknown, (function () -> False), Unknown
            ] |> List.map (fun (q, n, d) -> TestCaseData(q,n,d))

    [<TestCaseSource("DifferenceCases")>]
    [<Category("ThreeValuedBoolean")>]
    let internal differenceTest (x, (y: unit -> ThreeValuedBoolean), z: ThreeValuedBoolean) =
        Assert.AreEqual(difference x y,  z)
