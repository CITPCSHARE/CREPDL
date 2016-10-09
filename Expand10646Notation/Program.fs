// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

open System
open System.IO


let parseLine (line: string) =
  let trimedLine = line.Trim()
  match trimedLine.Split([|' '|], 2) with 
  | [|row; rest|] ->
    if row.Length > 2 then seq {yield rest.Replace("-", ",")}
    else
        let values = rest.Split([|' '|])
        seq { for v in values ->
                match v.Split([|'-'|], 2) with 
                |[|rangeStart;rangeEnd|] 
                    -> if rangeStart.Length <> 2 then failwith "should not happen"
                       "0x"+row+rangeStart+","+"0x"+row+rangeEnd
                |[|point|] 
                    -> if point.Length <> 2 then failwith "should not happen" else "0x"+row+point
                | _-> failwith "should not happen"}
  | _ -> failwith "should not happen"

let expandedLines filename =
  let lines = File.ReadLines(filename)
  seq { for line in lines do 
        if not(line.StartsWith(";")) && line.Length > 3 then yield! parseLine line }

[<EntryPoint>]
let main argv = 
    let inputFile = argv.[0]
    let outputputFile = argv.[1]
    use ofs = new FileStream(outputputFile,  FileMode.Create)
    use ofsWriter = new StreamWriter (ofs)
    let lines = expandedLines inputFile
    for line in lines do
        ofsWriter.WriteLine(line)
    0 // return an integer exit code
