open System
open System.IO
open System.Reflection

let createInputStreamReader () =
    let derivedAgeFileName = "DerivedAgePreprocessor.DerivedAge.txt"
    let asm = Assembly.GetExecutingAssembly()
    let l = asm.GetManifestResourceNames()
    let strm = asm.GetManifestResourceStream(derivedAgeFileName)
    new StreamReader(strm);;

let createOutputStreamWriter (age: string) =
    let asm = Assembly.GetExecutingAssembly()
    let path = Path.GetDirectoryName(asm.Location)
    let outDir = 
        match path.Split([|@"DerivedAgePreprocessor\bin"|],StringSplitOptions.None) with
        | [|x; _|] -> x + @"CREPDL\"
        | _ -> failwith "error"
    let outputFileName = outDir + "Age" + (age.Replace(".", "-")) + ".txt"
    let ofs = new FileStream(outputFileName,  FileMode.Create)
    ofs;;
   // new StreamWriter (ofs);;

 let createDescriptors (sr: StreamReader)  =
    [ while not (sr.EndOfStream) do
            let line = sr.ReadLine().Trim()
            if line.StartsWith("#") |> not && line.Length > 1 then 
               let choppedLine = line.Remove(line.IndexOf("#"))
               match choppedLine.Split([|".."; ";"; "#"|], StringSplitOptions.None) with
               | [|st; ed; age|] -> yield ("0x" + st.Trim() + ",0x" + ed.Trim(), age.Trim())
               | [|st; age|]    -> yield ("0x" + st.Trim(), age.Trim())
               | _ -> failwith "unusual line" ];;


[<EntryPoint>]
let main argv =
    let descriptors = createDescriptors (createInputStreamReader ())
    for  (desc, age) in descriptors do 
        printfn "%s %s" desc age
        
    let ages = ["1.1"; "2.0"; "2.1"; "3.0"; "3.1"; "3.2"; "4.0"; "4.1"; "5.0"; "5.1";
                "5.2"; "6.0"; "6.1"; "6.2"; "6.3"; "7.0"; "8.0"; "9.0"; "10.0";
                "11.0"; "12.0"; "12.1"]
    for age in ages do
        use ofs = createOutputStreamWriter age
        use writer = new StreamWriter (ofs)
        for (desc,ag) in descriptors do
            if ag = age then
               writer.WriteLine(desc)
    1