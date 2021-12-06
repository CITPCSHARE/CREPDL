module CREPDL.IVSChecker


open System
open System.Text
open System.IO
open System.Reflection
open Repertoire
open Basics
open ThreeValuedBoolean

type internal IVSChecker = string -> bool

let internal IVD_Sequences_file = "IVD_Sequences.txt"

let internal readIVS (tsr: TextReader) =
    seq { while ( tsr.Peek() <> -1) do
            let line = tsr.ReadLine()
            if not(line.StartsWith("#")) then
                match line.Split(';')  with
                | [|baseAndIVS; iVSColName; misc|] ->
                    match baseAndIVS.Split(' ') with
                    | [|baseChar; ivs|] -> 
                        yield (int ("0x" + baseChar), int ("0x" + ivs), iVSColName.Trim())
                    | _ -> failwith ("Syntax error in " + IVD_Sequences_file)
                | _ -> failwith ("Syntax error in " + IVD_Sequences_file) }


let internal getBaseIVSPairs (tripletSeq: seq<int * int * string>) ivsColName  =
    let baseIVSPairs = seq { for (b, ivs, str) in tripletSeq do
                     if str = ivsColName then yield (b, ivs) }
    if Seq.isEmpty baseIVSPairs then 
        failwith ("IVD Collection " + ivsColName + " is not registered.") 
    else Set.ofSeq baseIVSPairs

let internal generateBaseSetPerSelector ivsColName =
    let tr = ((getStreamReaderForEmbeddedResource IVD_Sequences_file) :> TextReader)
    let baseIvsPairs = getBaseIVSPairs (readIVS tr) ivsColName
    let ivsSet = set [ for (_, ivs) in baseIvsPairs -> ivs ]
    [for ivs in ivsSet do
        let baseSet = set [ for (b, x) in baseIvsPairs do
                                            if x = ivs then yield b ]
        yield (ivs, baseSet)]

        
let internal generateRepertoireFromIVD ivsColName: Repertoire =
    let baseSetPerSelector = generateBaseSetPerSelector ivsColName
    fun (str: string) ->
        if str.Length < 3 then False
        else 
            let selector = System.Char.ConvertToUtf32(str, str.Length-2)
            if selector >= 0xE0100 && selector <= 0xE0120 then
                let bas = System.Char.ConvertToUtf32(str, 0)
                if baseSetPerSelector 
                    |> List.exists (fun (x,y) -> selector = x && y.Contains(bas))  then True
                else False
            else False

