module CREPDL.Console

open ISO10646Collection
open ThreeValuedBoolean
open Validation
open System.IO
open System.Text


let printCharacter (str: string) =
    printf "%s (" str
    for i = 0 to str.Length - 1 do
            let v = str.Chars i |> int
            v.ToString("x4") |>
                if i = str.Length - 1 then
                 printf "U+%s" 
                else printf "%s, "
    printfn ")"

[<EntryPoint>]
let main args =
    System.Console.OutputEncoding <- System.Text.Encoding.UTF8;
    let startTime = System.DateTime.Now in
    System.Console.WriteLine(System.DateTime.Now - startTime)
    let returnCode = 
      try
        match args with
            | [|crepdlFile; textFile|]
            | [|crepdlFile; textFile; _|]
              ->  let validator = new Validator(crepdlFile)
                  let encoding =
                    if args.Length = 3 then Encoding.GetEncoding(args.[2])
                    else Encoding.UTF8
                  let (unknowns, notIncluded) = validator.validateTextStream(new StreamReader(textFile, encoding ))
                  System.Console.WriteLine("Unknowns:")
                  if unknowns.Length <> 0 then
                      System.Console.WriteLine("Unknowns:")
                  for u in unknowns do
                      printCharacter u
                  if notIncluded.Length <> 0 then
                      System.Console.WriteLine("Not Included:")
                  for n in notIncluded do
                      printCharacter n
                  0
            | _ -> System.Console.WriteLine "Specify a CREPDL file and a text file"
                   1
       with
            | Failure msg 
                -> System.Console.WriteLine(msg)
                   1
            | :?  System.IO.FileNotFoundException 
               -> System.Console.WriteLine "File not found"
                  1

    System.Console.WriteLine(System.DateTime.Now - startTime)
    returnCode

