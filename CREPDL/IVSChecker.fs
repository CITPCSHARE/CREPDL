﻿module CREPDL.IVSChecker


open System
open System.Text
open System.IO
open System.Reflection
open Repertoire
open Basics
open ThreeValuedBoolean

type IVSChecker = string -> bool

let IVD_Sequences_file = "IVD_Sequences.txt"

let readIVS (tsr: TextReader) =
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


let getBaseIVSPairs (tripletSeq: seq<int * int * string>) ivsColName  =
    seq { for (b, ivs, str) in tripletSeq do
            if str = ivsColName then yield (b, ivs)
         }
    |> fun x -> 
        if Seq.isEmpty x then failwith ("IVD Collection " + ivsColName + " is not registered.") 
        else Set.ofSeq x

let generateBaseSetPerSelector ivsColName =
    let tr = ((getStreamReaderForEmbeddedResource IVD_Sequences_file) :> TextReader)
    let baseIvsPairs = getBaseIVSPairs (readIVS tr) ivsColName
    let ivsSet = set [ for (_, ivs) in baseIvsPairs -> ivs ]
    [for ivs in ivsSet do
        let baseSet = set [ for (b, x) in baseIvsPairs do
                                            if x = ivs then yield b ]
        yield (ivs, baseSet)]

        
let generateRepertoireFromIVD ivsColName: Repertoire =
    let baseSetPerSelector = generateBaseSetPerSelector ivsColName
    fun (str: string) ->
        let selector = System.Char.ConvertToUtf32(str, str.Length-2)
        let bas = System.Char.ConvertToUtf32(str, 0)
        let baseSet = snd (Seq.find (fun (x, y) -> selector = x)  baseSetPerSelector)
        if baseSet.Contains(bas) then True else False
