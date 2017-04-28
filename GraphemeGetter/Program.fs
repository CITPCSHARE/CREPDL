// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

open System.IO
open Icu;

let deSyntaxSugar str =
    let iter = BreakIterator.Split(BreakIterator.UBreakIteratorType.CHARACTER, Locale(), str)
    let mutable reverseList = []
    for gc in iter do
        if gc.Length = 1 then
            reverseList <- gc::reverseList
        else 
            reverseList <- ("(" + gc + ")")::reverseList
    List.fold (fun soFar y -> y+soFar) "" reverseList
        
[<EntryPoint>]
let main argv = 
    printfn "%A" argv
    let firsttext = BreakIterator.Split(BreakIterator.UBreakIteratorType.CHARACTER, Locale(), "\u3402\U000E0103,,あ　ば ,a")
    for s in firsttext do
        System.Console.WriteLine(s)
    System.Console.WriteLine(deSyntaxSugar "aあ\u3402\U000E0103\U0002000B")
    System.Console.WriteLine(deSyntaxSugar "a + b*^c|d[a,4] ")
    0 // return an integer exit code
