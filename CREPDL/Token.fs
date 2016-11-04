module CREPDL.Token


type token = string * int

let getStringFromToken (t: token) = fst t

let getInt32FromToken (t: token) = snd t
