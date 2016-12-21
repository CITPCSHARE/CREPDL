module IVSChecker


open System
open System.Text
open System.IO
open System.Reflection

type IVSChecker = string -> bool

let IVD_Sequences_file = "IVD_Sequences.txt"

let readIVS (tsr: StreamReader) =
    seq { while (not tsr.EndOfStream) do
            let line = tsr.ReadLine()
            if not(line.StartsWith("#")) then
                match line.Split(';')  with
                | [|baseAndIVS; iVSColName; misc|] ->
                    match baseAndIVS.Split(' ') with
                    | [|baseChar; ivs|] -> 
                        yield (int ("0x" + baseChar), int ("0x" + ivs), iVSColName.Trim())
                    | _ -> failwith ("Syntax error in " + IVD_Sequences_file)
                | _ -> failwith ("Syntax error in " + IVD_Sequences_file) }



let filterTriplets (tripletSeq: seq<int * int * string>) ivsColName  =
    Seq.filter (fun (_, _, nm) -> ivsColName = nm) tripletSeq
