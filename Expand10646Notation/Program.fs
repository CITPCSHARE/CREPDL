// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

open System
open System.IO
open System.Reflection


let parseLine (line: string) =
  let trimedLine = line.Trim()
  match trimedLine.Split([|' '|], 2) with 
  | [|row; rest|] ->
    if row.Length >= 5 then //AA-DD for example
        seq {yield "0x" + rest.Replace("-", ",0x")}
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
  | [| singleton |] ->
    if singleton.Length >= 5 then //AA-DD for example
        seq {yield "0x" + singleton.Replace("-", ",0x")}
    else failwith "should not happen"
  | _ -> failwith "should not happen"

let expandedLines (str: StreamReader) =
    seq{ while not(str.EndOfStream) do
            let line = str.ReadLine()
            if not(line.StartsWith(";")) && line.Length > 3 then yield! parseLine line }


[<EntryPoint>]
let main argv =
    let prepFiles =
        ["281.txt"; "282.txt"; "-200285.txt"; "286.txt"; "288.txt";
        "301.txt"; "302.txt"; "-303.txt"];

    let asm = Assembly.GetExecutingAssembly()
    let path = Path.GetDirectoryName(asm.Location)
    let dir = 
        match path.Split([|@"Expand10646Notation\bin"|],StringSplitOptions.None) with
        | [|x; _|] -> x + @"CREPDL\"
        | _ -> failwith "error"
 
    let help (filename: string) =
        let fn = Path.Combine(path, filename)
        let textStreamReader = 
            new StreamReader(asm.GetManifestResourceStream(filename))

        let outputFile = dir + filename
        use ofs = new FileStream(outputFile,  FileMode.Create)
        use ofsWriter = new StreamWriter (ofs)
        let lines = expandedLines textStreamReader
        for line in lines do
            ofsWriter.WriteLine(line)
               
    List.iter help prepFiles
    0 // return an integer exit code
