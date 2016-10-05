module CREPDL.Dewey


[<Literal>]
//Ux10FFFF  = 2097152 - 1
let Size = 2048 //Size of an array for each Range
let Count = 2 // (Size^^Count > 2097152)
let Shift = 11 // (2^Shift = Size)
//let Size = 1024 //Size of an array for each Range
//let Count = 3 // (Size^^Count > 2097152)
//let Shift = 10 // (2^Shift = Size)
//let Size = 512 //Size of an array for each Range
//let Count = 3 // (Size^^Count > 2097152)
//let Shift = 9 // (2^Shift = Size)
//let Size = 256 //Size of an array for each Range
//let Count = 3 // (Size^^Count > 2097152)
//let Shift = 8 // (2^Shift = Size)
//let Size = 128 //Size of an array for each Range
//let Count = 3 // (Size^^Count > 2097152)
//let Shift = 7 // (2^Shift = Size)
//let Size = 64 //Size of an array for each Range
//let Count = 4 // (Size^^Count > 2097152)
//let Shift = 6 // (2^Shift = Size)
//let Size = 32 //Size of an array for each Range
//let Count = 5 // (Size^^Count > 2097152)
//let Shift = 5 // (2^Shift = Size)
//let Size = 16 //Size of an array for each Range
//let Count = 6 // (Size^^Count > 2097152)
//let Shift = 4 // (2^Shift = Size)
//let Size = 8 //Size of an array for each Range
//let Count = 7 // (Size^^Count > 2097152)
//let Shift = 3 // (2^Shift = Size)
//let Size = 4 //Size of an array for each Range
//let Count = 11 // (Size^^Count > 2097152)
//let Shift = 2 // (2^Shift = Size)
//let Size = 2 //Size of an array for each Range
//let Count = 21 // (Size^^Count > 2097152)
//let Shift = 1 // (2^Shift = Size)


type RangeOrPoint =
    NotAllocated //Neither a range nor a point
    | Point 
    | Range of RangeOrPoint []
    
let codeValue2RangeList (codeValue: int) =
    let rec help codeValue c  =
        if c = 0 then
            []
        else
            (codeValue%Size)::(help (codeValue >>> Shift) (c - 1))
    List.rev (help codeValue Count)

let rec addPoint pOrP pointList =
        match (pOrP, pointList) with
        | (NotAllocated, []) ->  Point
        | (NotAllocated, head::tail) -> 
            let newlyAllocatedPlane= Range (Array.create Size NotAllocated)
            addPoint newlyAllocatedPlane pointList
        | (Point, []) -> pOrP
        | (Point, head::tail) -> failwith "A point exists as an acestor"
        | (Range(_), []) -> failwith "A range exists as a leaf"
        | (Range(nextPOrP), head::tail) -> 
            nextPOrP.[head] <- addPoint nextPOrP.[head] tail;
            pOrP
//            Range [| for i in 0..(Size-1) do 
//                        if i = head then yield addPoint nextPOrP.[head] tail
//                        else yield nextPOrP.[i] |]
        
let rec checkPoint pOrP pointList =
    match (pOrP, pointList) with
    | (NotAllocated, _) -> false
    | (Point, []) -> true
    | (Point, _) -> false
    | (Range(_), []) -> false
    | (Range(nextPOrP), head::tail) -> 
        checkPoint nextPOrP.[head] tail

let checkShiftSizeCount () =
    if  abs(2.0 ** (float Shift) - float Size) > 0.001 then failwith "2^Shift != Size"
    else if (float Size) ** (float Count) < float 2097152 || 
            (float Size) ** (float Count - 1.0) > float 2097152 then failwith "Size ** Count is inappropriate"
    else ();