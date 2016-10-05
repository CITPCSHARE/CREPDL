//This program examines which grapheme cluster is successfully recognized.

module GraphemeTest.GraphemeTest

open  System.Globalization

let testList = [
                    ("combining character sequences", "\u0067\u0308a");
                    ("Hangul syllables such as gag", "\u1100\u1161\u11a8a");
                    ("IVS" ,"\u342C\U000E0102a");
                    ("IVS" ,"\u342E\U000E0101a");
                    ("IVS" ,  "\u348A\U000E0100a");
                    ("IVS" , "\u348A\U000E0101a");
                    ("IVS non-BMP" , "\U0002B81D\U000E0100a");
                    ("IVS non-BMP" , "\U0002B817\U000E0100a");
                    ("Tamil ni", "\u0BA8\u0BBFa");
                    ("Thai kam", "\u0E01\u0E33a");
                    ("Devanagari ssi", "\u0937\u093Fa");
                    ("Slovak ch digraph", "\u0063\u0068a");
                    ("sequence with letter modifier", "\u006B\u02B7a");
                    ("Devanagari kshi", "\u0915\u094D\u0937\u093Fa")
]
        
let test pairList =
    let test1 (label:string) str =
        System.Console.WriteLine(label)
        let enum =  StringInfo.GetTextElementEnumerator str
        while (enum.MoveNext()) do
            let next = enum.GetTextElement()
            System.Console.WriteLine(next)
    List.iter (function (x,y) -> test1 x y) pairList

    
[<EntryPoint>]
let main args = 
    test testList
    System.Console.ReadKey() |> ignore
    0

