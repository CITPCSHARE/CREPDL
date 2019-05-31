// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

open System
open System.IO
open System.Reflection

let private parseValue (prefix:string) (row: string) (v: string) =
    match v.Split([|'-'|], 2) with 
    |[|rangeStart;rangeEnd|] 
        -> if rangeStart.Length <> 2 || rangeEnd.Length <> 2  
                then failwith ("should not happen: " + v);
           (int ("0x" + row), "0x"+prefix+row+rangeStart+","+"0x"+prefix+row+rangeEnd)
    |[|point|] 
        -> if point.Length <> 2 then failwith  ("should not happen: " + v)
           else (int ("0x" + row), "0x"+prefix+row+point)
    | _-> failwith  ("should not happen: " + v)

let private parseLineHelp (prefix: string) (line: string) =
  match line.Split([|' '|], 2) with 
  | [|row; rest|] ->
    let trimmedRest = rest.Trim()
    if row.Contains("-")  then //AA-DD for example
        if trimmedRest.Contains(" ") then failwith ("should not happen: " + line)
        seq {yield (0, "0x" + prefix + trimmedRest.Replace("-", ", 0x" + prefix))}
    else
        let values = trimmedRest.Split([|' '|], StringSplitOptions.RemoveEmptyEntries)
        seq { for v in values ->
                parseValue prefix row v}
  | _ -> failwith  ("should not happen: " + line)

let private getRow (prefix: string)  (line:string) = 
  match line.Split([|' '; '-'|], 2) with 
  | [|row; rest|] -> int ("0x" + prefix + row)
  | _ -> failwith ("should not happen: " + line)

let private parseLine (prefix: string) (line: string): seq<string> =
    let parsedLine = parseLineHelp prefix line
    let rec check prev (l: list<int*string >) =
        match l with
        | [] -> ()
        | (hi, hs)::tail -> if prev <= hi then check hi tail
                            else failwith ("should not happen: " + line)
    check -1 (Seq.toList parsedLine)
    Seq.map snd parsedLine

let private expandedLines (str: StreamReader) =
    let mutable planePrefix = ""
    let mutable previousRow = -1
    seq{ while not(str.EndOfStream) do
            let line = str.ReadLine().Trim()
            if line.StartsWith(";") || line.Length = 0 then () 
            elif line.StartsWith("Plane ") then
                planePrefix <- line.Substring(6)
            else 
                let nextRow = getRow planePrefix line
                if nextRow <= previousRow then failwith ("should not happen: " + line)
                else previousRow <- nextRow
                yield! parseLine planePrefix line }


[<EntryPoint>]
let main argv =
    let prepFiles =
        ["281.txt"; "282.txt"; "-200285.txt"; "286.txt"; "288.txt";
        "301.txt"; "302.txt"; "-303.txt"; "-304.txt"; "-306.txt"; 
        "-307.txt"; "308.txt"; "309.txt"; "310.txt"; "311.txt"; "314.txt"; "-340.txt"; "-287.txt"];

    let asm = Assembly.GetExecutingAssembly()
    let path = Path.GetDirectoryName(asm.Location)
    let dir = 
        match path.Split([|@"Expand10646Notation\bin"|],StringSplitOptions.None) with
        | [|x; _|] -> x + @"CREPDL\"
        | _ -> failwith "error"
 
    let help (filename: string) =
        System.Console.WriteLine(filename)
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
