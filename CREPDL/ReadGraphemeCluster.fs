module CREPDL.ReadGraphemeCluster

open System.IO
open Icu


let getGraphemeClusterEnumerator (tr: TextReader) =
    seq {
        while tr.Peek() <> -1 do
            let line = tr.ReadLine()
            let enumerator =
                BreakIterator.Split(BreakIterator.UBreakIteratorType.CHARACTER, Locale(), line)
            for gc in enumerator do
                let x = gc
                yield gc
    }