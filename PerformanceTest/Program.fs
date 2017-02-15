// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

open CREPDL.Basics
open CREPDL.Repertoire
open CREPDL.RBT

[<Literal>]
let iicoreFilename ="IICORE.txt"

[<EntryPoint>]
let main argv = 
    let sr = CREPDL.Basics.getStreamReaderForEmbeddedResource iicoreFilename
    let rbtIicore = createRBTRepertoire sr

    let sr = CREPDL.Basics.getStreamReaderForEmbeddedResource iicoreFilename
    let deweyIicore = createDeweyRepertoire sr

    let sr = CREPDL.Basics.getStreamReaderForEmbeddedResource iicoreFilename
    let setIicore = createSetRepertoire sr

    for i = 0 to 0x2A000 do 
        let r = rbtIicore i
        let d =  deweyIicore i
        let s = setIicore i
        if r <> d || r <> s then failwith "henda"


    let now = System.DateTime.Now       
    for i = 0 to 0x2A000 do 
        deweyIicore i |> ignore
    System.Console.WriteLine(System.DateTime.Now - now)

    let now = System.DateTime.Now     
    for i = 0 to 0x2A000 do 
        rbtIicore i |> ignore
    System.Console.WriteLine(System.DateTime.Now - now)

    
    let now = System.DateTime.Now     
    for i = 0 to 0x2A000 do 
        setIicore i |> ignore
    System.Console.WriteLine(System.DateTime.Now - now)



      
                
    0 // return an integer exit code