module RedBlackTree


open NUnit.Framework
open FsUnit
open CREPDL.RBT
open Swensen.Unquote
//
//let cf (x:int) (y:int) =
//    if x < y then -1
//    else if x > y then 1
//    else 0;;
//
//let debug_print  =
//  function 
//  | None -> "Not found" 
//  | Some(y: 'd) -> y.ToString();;
//         
//let t0 = empty_explicit cf cf;;
//
//let t1 = insert 1 t0;;
//let t2 = insert 2 t1;;
//let t3 = insert 3 t2;;
//let t4 = insert 4 t3;;
//let t5 = insert 5 t4;;
//let t6 = insert 6 t5;;
//let t7 = insert 7 t6;;
//let t8 = insert 8 t7;;
//let t9 = insert 9 t8;;
//let t10 = insert 10 t9;;
//let t11 = insert 11 t10;;

[<Test>]
let find1() =
    let cf (x:int) (y:int) =
        if x < y then -1
        else if x > y then 1
        else 0
        
    let t0 = empty_explicit cf cf

    test <@ true @>

//
//debug_print(find 4 t8)
//debug_print(find 5 t8)
//debug_print(find 7 t8)
//debug_print(find -1 t8)
//debug_print(find 23 t8)
//debug_print(find 15 t8)
//
