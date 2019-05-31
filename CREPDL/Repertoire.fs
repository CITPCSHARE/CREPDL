module CREPDL.Repertoire

open System
open System.IO
open ThreeValuedBoolean

type internal Repertoire = string -> ThreeValuedBoolean

let private split (line: string) =
    match line.Split(',') with
    | [| s; e |] -> (int s, int e)
    | [| x |] -> (int x, int x)
    | _ -> failwith ("invalid line: " + line) 


let private charList (tr:TextReader) =
    seq { while not( tr.Peek() = -1) do
             let line = tr.ReadLine()
             yield!
                 let (s, e) = split line in [s .. e]  };;

let internal createRepertoireFromTextReader (tr: TextReader): Repertoire =
    let allCodePoints = Set.ofSeq (Seq.map (fun x -> Char.ConvertFromUtf32 x) (charList tr))
    let checkString (s: string) = 
        if allCodePoints.Contains s then True
        else False
    checkString
