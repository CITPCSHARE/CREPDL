// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

open CREPDL.Basics
open CREPDL.Repertoire
open CREPDL.RBT

[<Literal>]
let iicoreFilename ="IICORE.txt"

[<EntryPoint>]
let main argv = 
    let stream = CREPDL.Basics.getStreamReaderForEmbeddedResource iicoreFilename
//    let str = stream.ReadToEnd()
//    let stream = CREPDL.Basics.getStreamReaderForEmbeddedResource iicoreFilename
    
//    let rbtIicore = createRBTRepertoire str
    let deweyIicore = createDeweyRepertoire stream
//    let mutable count = 0
//    for i = 0 to 0x2A000 do 
//        let r = rbtIicore i
//        let d =  deweyIicore i
//        if r <> d && count < 100 then 
//            count <- count + 1
//            System.Console.WriteLine( System.Convert.ToString(i, 16))


    let now = System.DateTime.Now       
    for i = 0 to 0x2A000 do 
        deweyIicore i |> ignore
    System.Console.WriteLine(System.DateTime.Now - now)

//    let now = System.DateTime.Now     
//    for i = 0 to 0x2A000 do 
//        rbtIicore i |> ignore
//    System.Console.WriteLine(System.DateTime.Now - now)



      
                
    0 // return an integer exit code