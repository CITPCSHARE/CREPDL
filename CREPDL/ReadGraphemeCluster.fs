module CREPDL.ReadGraphemeCluster

open System.IO
open Icu

let internal getGraphemeClusterEnumerator (tr: TextReader) =
    seq {
        while tr.Peek() <> -1 do
            let content = tr.ReadToEnd()
            let enumerator =
                BreakIterator.Split(BreakIterator.UBreakIteratorType.CHARACTER, Locale(), content)
            for gc in enumerator do
                yield gc
    }