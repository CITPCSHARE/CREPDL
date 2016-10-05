
module BMPTest.Test
open System.Text;
open System.Text.RegularExpressions;
open CREPDL.ActivePattern


let bmpRegTest() =

    let checkReg regStr text =
        let reg = new Regex(regStr)
        reg.IsMatch(text)
    System.Console.WriteLine ( checkReg "^a$" "a")
    System.Console.WriteLine ( checkReg "^a$" "abc")
    System.Console.WriteLine ( checkReg "^[\U00029D98]$" "\U00029D98")
    System.Console.WriteLine ( checkReg "^[\U0002070E]$" "\uD841")
    System.Console.WriteLine ( checkReg "^[\U0002070E]$" "\uDF0E")
    System.Console.WriteLine ( checkReg "^\U0002070E$" "\U0002070E")
    System.Console.WriteLine ( checkReg "^\U0002070E$" "\uD841\uDF0E")
//    System.Console.WriteLine ( checkReg "[\U0002070E-\U00020710]" "\U0002070E")
//    System.Console.WriteLine ( checkReg "[\U0002070E-\U00020710]" "\U0002070F")
//    System.Console.WriteLine ( checkReg "[\U0002070E-\U00020710]" "\U00020710")
    System.Console.WriteLine ( checkReg "^[\U0002070E\U00020710]$" "\U0002070E")
    System.Console.WriteLine ( checkReg "^[\U0002070E\U00020710]$" "\U0002070F")
    System.Console.WriteLine ( checkReg "^[\U0002070E\U00020710]$" "\U00020710")
    
    System.Console.WriteLine ( checkReg "^\u8FBA\uE0101$" "\u8FBA\uE0101")


[<EntryPoint>]
let main args = 
    bmpRegTest()
    System.Console.ReadKey() |> ignore
    0

