module CREPDL.RBT

//Rewrite of Okasaki's algorithm in F#
//See http://www.eecs.usma.edu/webs/people/okasaki/jfp99.ps

//Type definitions are borrowed from Don Syme's post, available at
//http://cs.hubfs.net/forums/thread/73.aspx

type comparer<'d> = 'd -> 'd -> int
type memberChecker<'d, 'v> = 'd -> 'v -> int 

//I need these two functions, since I have to store integer ranges in red-black
//trees and later test if a given integer is included by some stored range.

type color = R | B
type tree<'d, 'v>  =
    { comparisonFunc: comparer<'d>; 
      membershipFunc: memberChecker<'d, 'v>;
      top: node<'d> }
and node<'d> = E | T of color * node<'d> * 'd * node<'d>

let empty_explicit cf mf = 
    { comparisonFunc = cf; membershipFunc = mf; top=E }

let find (v: 'v)  (tree: tree<'d, 'v>): 'd option =
    match tree with 
    {comparisonFunc = _; membershipFunc = mf; top = top} ->
        let rec findHelp =
            function 
            | E -> None
            | T(color, a, x, b) ->
                let res = mf x v
                if res > 0 then findHelp a
                else if res < 0 then findHelp b
                else Some(x)
        findHelp top
        
let insert (x: 'd) (tree: tree<'d, 'v>): tree<'d, 'v> =
    match tree with
    {comparisonFunc = cf; membershipFunc = mf; top = top} -> 
        let balance =
            function
            | (B, T(R, T(R, a, x, b), y, c), z, d)
            | (B, T(R, a, x, T(R, b, y, c)), z, d)
            | (B, a, x, T(R, T(R, b, y, c), z, d))
            | (B, a, x, T(R, b, y, T(R, c, z, d))) ->
                T(R, T(B, a, x, b), y, T(B, c, z, d))
            | (color, a, x, b) -> T(color, a, x, b)
            
        let insertHelp node =
            let rec ins  =
                function
                | E -> T(R, E, x, E)
                | T(color, a, y, b) ->
                    let res = cf x y
                    if res < 0 then balance (color, (ins a), y, b)
                    else if res > 0 then balance (color, a, y, (ins b)) 
                    else T(color, a, y, b)
            let makeBlack  =
                function
                | E -> failwith "shouldn't happen" 
                | T(_,a, y, b) -> T(B, a, y, b)
            makeBlack (ins node)
        {comparisonFunc = cf; 
         membershipFunc = mf; 
         top = insertHelp top}

let height  (t: tree<'d, 'v>) =
    let rec height_node nd =
         match nd with
             | E -> 0
             | T(_, n1, d, n2) -> 1 + max (height_node n1)  (height_node n2) 
    match t with 
    | {comparisonFunc = _; membershipFunc = _; top = topNode}
        -> height_node topNode

let print_rbt_tree (t: tree<'d, 'v>) (tw: System.IO.TextWriter)=
    let help indent = 
        for i = 0 to indent do
            tw.Write(" ")
    let rec print_rbt_node (nd: node<'d>) indent =
         match nd with
             | E -> help indent;tw.Write("()")
             | T(_, n1, d, n2) -> 
                help indent;tw.WriteLine("(")
                print_rbt_node (n1) (indent + 2)
                help indent;tw.WriteLine(d)
                print_rbt_node (n2) (indent + 2)
                help indent;tw.WriteLine(")")
    match t with 
    | {comparisonFunc = _; membershipFunc = _; top= topNode}
        -> print_rbt_node topNode 0

//let cf (x:int) (y:int) =
//    if x < y then -1
//    else if x > y then 1
//    else 0;;
//
//let debug_print  =
//  function 
//  | None -> System.Console.WriteLine "Not found" 
//  | Some(y: 'd) -> System.Console.WriteLine(y)
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
//
//debug_print(find 4 t8)
//debug_print(find 5 t8)
//debug_print(find 7 t8)
//debug_print(find -1 t8)
//debug_print(find 23 t8)
//debug_print(find 15 t8)
//
//
//System.Console.ReadKey() |> ignore;;