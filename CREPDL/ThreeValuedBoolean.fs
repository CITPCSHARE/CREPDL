module  CREPDL.ThreeValuedBoolean

type internal ThreeValuedBoolean =
  | True
  | False
  | Unknown 

let internal union tvb tvbf =
    match tvb with
    | True -> True
    | False -> tvbf ()
    | Unknown when tvbf () = True -> True 
    | _ -> Unknown

let internal intersection tvb tvbf =
    match tvb with
    | False -> False
    | True -> tvbf ()
    | Unknown when tvbf () = False -> False 
    | _ -> Unknown
  

let internal difference tvb tvbf =
    match tvb with
    | False -> False
    | _ ->
        match tvbf() with
        | True -> False
        | False -> tvb
        | Unknown -> Unknown


let internal writeThreeValuedBoolean (tfu: ThreeValuedBoolean) =
    System.Console.WriteLine 
      (match tfu with True -> "True" | False -> "False" | Unknown -> "Unknown")