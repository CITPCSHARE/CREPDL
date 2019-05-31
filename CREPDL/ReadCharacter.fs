module CREPDL.ReadCharacter

open System;
open System.IO;

let internal getCharacterEnumerator (tr: TextReader) =
    seq { while tr.Peek() <> -1 do
            let character = tr.Read() |> char 
            if Char.IsSurrogate(character) then
                let nextCharacter = tr.Read() |> char
                yield (character.ToString() + nextCharacter.ToString())
            else yield character.ToString() }