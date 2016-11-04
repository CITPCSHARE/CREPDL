module CREPDL.SurrogateAwareTextReader

open System;
open System.IO;
open System.Net
open System.Text;

let private surrogate2real (high: int16) (low: int16) =
    let w = (int32 high &&& 0x03C0) >>> 6
    let x1 = (int32 high &&& 0x003F)
    let x2 = (int32 low &&& 0x03FF)
    let u = w + 1
    (u <<< 16) ||| (x1 <<< 10) ||| x2

let readChar (tr: TextReader) =
    let ch = tr.Read()
    let character = char ch
    if Char.IsSurrogate(character) then
        let nextCh = tr.Read()
        (ch.ToString() + nextCh.ToString(), surrogate2real (int16 ch) (int16 nextCh))
    else ((char ch).ToString(), int32 ch)

    

//System.Console.WriteLine((surrogate2real 0xD800s 0xDC00s).ToString("X"))
//System.Console.WriteLine((surrogate2real 0xD800s 0xDC01s).ToString("X"))
//System.Console.WriteLine((surrogate2real 0xD800s 0xDC02s).ToString("X"))
//System.Console.WriteLine((surrogate2real 0xD800s 0xDFFDs).ToString("X"))
//System.Console.WriteLine((surrogate2real 0xD800s 0xDFFEs).ToString("X"))
//System.Console.WriteLine((surrogate2real 0xD800s 0xDFFFs).ToString("X"))
//System.Console.WriteLine((surrogate2real 0xD801s 0xDC00s).ToString("X"))
//System.Console.WriteLine((surrogate2real 0xD801s 0xDC01s).ToString("X"))
//System.Console.WriteLine((surrogate2real 0xD801s 0xDC02s).ToString("X"))
//System.Console.WriteLine((surrogate2real 0xD801s 0xDFFDs).ToString("X"))
//System.Console.WriteLine((surrogate2real 0xD801s 0xDFFEs).ToString("X"))
//System.Console.WriteLine((surrogate2real 0xD801s 0xDFFFs).ToString("X"))
//System.Console.WriteLine((surrogate2real 0xD802s 0xDC00s).ToString("X"))
//System.Console.WriteLine((surrogate2real 0xDBFFs 0xDC00s).ToString("X"))
//System.Console.WriteLine((surrogate2real 0xDBFFs 0xDC01s).ToString("X"))
//System.Console.WriteLine((surrogate2real 0xDBFFs 0xDFFEs).ToString("X"))
//System.Console.WriteLine((surrogate2real 0xDBFFs 0xDFFFs).ToString("X"))