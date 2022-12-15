module CREPDL.ReadGraphemeCluster

open System
open System.IO
open System.Globalization

let internal getGraphemeClusterEnumerator (tr: TextReader) =
    seq {
        while tr.Peek() <> -1 do
            let content = tr.ReadToEnd()
            let enumerator = StringInfo.GetTextElementEnumerator(content)
            yield! seq{while enumerator.MoveNext() do yield enumerator.Current :?> String}}