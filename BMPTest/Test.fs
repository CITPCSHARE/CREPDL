
module BMPTest.Test
open System.Text;
open System.Text.RegularExpressions;
open CREPDL.ActivePattern
open System.IO
let syntaxTest() =
    let checkSyntax regStr  =
        try 
            new Regex(regStr) |> ignore
            System.Console.WriteLine ("ok: " + regStr)
        with
        | :? System.ArgumentException -> System.Console.WriteLine("error: " + regStr)
    
    let fileStream = new FileStream("h:/dsdl/charCol/unicodeRegExp.txt", FileMode.Open)
    let sr = new StreamReader (fileStream, Encoding.UTF8)
    while not(sr.EndOfStream) do
        let line = sr.ReadLine()
        if line <> "" then
            checkSyntax line

let bmpRegTest() =

    let checkReg regStr text =
        let reg = new Regex(regStr)
        System.Console.WriteLine ( reg.IsMatch(text))
        
    let checkReg1 regStr text1 text2 =
        let reg = new Regex(regStr)
        System.Console.WriteLine ( reg.IsMatch(text1))
        System.Console.WriteLine ( reg.IsMatch(text2))

    checkReg "^a$" "abc"
    checkReg "^a$" "abc"
    checkReg "^[\U00029D98]$" "\U00029D98"
    checkReg "^[\U0002070E]$" "\uD841"
    checkReg "^[\U0002070E]$" "\uDF0E"
    checkReg "^\U0002070E$" "\U0002070E"
    checkReg "^\U0002070E$" "\uD841\uDF0E"
//    checkReg "[\U0002070E-\U00020710]" "\U0002070E"
//    checkReg "[\U0002070E-\U00020710]" "\U0002070F"
//    checkReg "[\U0002070E-\U00020710]" "\U00020710"
    checkReg "^[\U0002070E\U00020710]$" "\U0002070E"
    checkReg "^[\U0002070E\U00020710]$" "\U0002070F"
    checkReg "^[\U0002070E\U00020710]$" "\U00020710"
    checkReg "^\u8FBA\uE0101$" "\u8FBA\uE0101"
    
    System.Console.ReadKey() |> ignore
    checkReg1 "[:script:Hira:]" "あ" "ア"
    checkReg1 "[:script:Katakana_Or_Hiragana:]" "あ" "亜"
    checkReg1 "[:scx:Kana:]" "ア" "あ" 
    checkReg1 "[:name:KATAKANA-HIRAGANA PROLONGED SOUND MARK:]" "ー" "あ" 
    checkReg1 "[:name:KATAKANA_MIDDLE_DOT:]" "・"  "。" 
    checkReg1 "[:name:COMBINING KATAKANA-HIRAGANA VOICED SOUND MARK:]" "\u3099"  "。" 





[<EntryPoint>]
let main args = 
    bmpRegTest()
 //    syntaxTest()
    0

