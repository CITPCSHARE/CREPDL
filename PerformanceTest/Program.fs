// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

open CREPDL.Basics
open CREPDL.Repertoire
open CREPDL.RBT
open CREPDL.ISO10646Collection
open System
open System.IO
open System.Runtime;
open System.Threading;




let performanceTest (colName: string) =


    System.Console.WriteLine(colName)

    let (_,_,fileName) = List.find (fun (_, y, _) -> colName = y) outOfLineCollections

    let sr = CREPDL.Basics.getStreamReaderForEmbeddedResource fileName
    let rbtIicore = createRBTRepertoire (lazy (sr :> TextReader))

    let sr = CREPDL.Basics.getStreamReaderForEmbeddedResource fileName
    let deweyIicore = createDeweyRepertoire (lazy (sr :> TextReader))

    let sr = CREPDL.Basics.getStreamReaderForEmbeddedResource fileName
    let setIicore = createSetRepertoire (lazy (sr :> TextReader))

    for i = 0 to 0x2A000 do 
        let r = rbtIicore i
        let d =  deweyIicore i
        let s = setIicore i
        if r <> d || r <> s then failwith "henda"  

    let now = System.DateTime.Now       
    for i = 0 to 0x2A000 do 
        deweyIicore i |> ignore
    System.Console.WriteLine(System.DateTime.Now - now)
    System.Console.WriteLine(System.GC.GetTotalMemory(false)) 

//
    let now = System.DateTime.Now     
    for i = 0 to 0x2A000 do 
        rbtIicore i |> ignore
    System.Console.WriteLine(System.DateTime.Now - now)
    System.Console.WriteLine(System.GC.GetTotalMemory(false)) 

//    
    let now = System.DateTime.Now     
    for i = 0 to 0x2A000 do 
        setIicore i |> ignore
    System.Console.WriteLine(System.DateTime.Now - now)
    System.Console.WriteLine(System.GC.GetTotalMemory(false)) 


[<EntryPoint>]
let main argv = 
    performanceTest  "MES-1"
    performanceTest "MULTILINGUAL LATIN SUBSET"
    performanceTest "BMP-AMD.7"
    performanceTest "UNICODE 5.1"
    performanceTest "IICORE"
    performanceTest "JIS2004 IDEOGRAPHICS EXTENSION"
      
    0 // return an integer exit code