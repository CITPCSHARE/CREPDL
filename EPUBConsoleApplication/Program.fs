open System
open HtmlAgilityPack
open CREPDL.Validation
open System.IO
open System.IO.Compression

let crepdlSource = 
    @"<union xmlns=""http://purl.oclc.org/dsdl/crepdl/ns/structure/2.0"" mode=""graphemeCluster"">
    <repertoire 
      registry=""10646"" number=""371""/>
    <repertoire 
      registry=""10646"" number=""285""/>
    <repertoire 
      registry=""10646"" number=""286""/>
    <char>[\n|\r|\t]|(\r\n)</char>  
    <char>[[ｰﾀﾐ｡ｱﾁﾑ｢ｲﾂﾒ｣ｳﾃﾓ､ｴﾄﾔ･ｵﾅﾕｦｶﾆﾖｧｷﾇﾗｨｸﾈﾘｩｹﾉﾙｪｺﾊﾚｫｻﾋﾛｬｼﾌﾜｭｽﾍﾝｮｾﾎﾞｯｿﾏﾟ]]</char>
    <char>[￠￡]</char>
    <char>[、。「」（），．、！・　：；]</char>
    <char>[１２３４５６７８９０]</char>
    <char>[ＡＢＣＤＥＦＧＨＩＪＫＬＭＮＯＰＱＲＳＴＵＶＷＸＹＺ]</char>
    <char>[ａｂｃｄｅｆｇｈｉｊｋｌｍｎｏｐｑｒｓｔｕｖｗｘｙｚ]</char>
    <char>[&#x2015;&#xFF3C;&#xFF5E;&#xFFE2;&#xFF0D;]</char>
    <char>[『』”＃＄％＆’＞＜〜−〜｜？αβ＾？●〜…＋←→―]</char>
    <char>[￥／\‐〒◎○〇■△×＠＊↓［］〔〕《》±≠＝≒〈〉−※★“‘【】〓]</char>
    </union>"



let scanZip (filePath: string) (validator: Validator) = 
    let zipFile = ZipFile.OpenRead(filePath)
    for entry in zipFile.Entries do
        if entry.Name.EndsWith(".xhtml") 
            || entry.Name.EndsWith(".html") 
            || entry.Name.EndsWith(".htm") then

            let mutable unknowns = set []
            let mutable notIncluded = set []
            let htmlDocument = new HtmlDocument()
            htmlDocument.Load(entry.Open(), System.Text.Encoding.UTF8)
            printfn "Checking File name: %s" entry.FullName
            for node in htmlDocument.DocumentNode.SelectNodes("//*/text()") do
                let (unknowns1, notIncluded1) = validator.validateTextStream(new StringReader(node.InnerText))
                unknowns <- Set.union unknowns (Set.ofArray(unknowns1))
                notIncluded <- Set.union notIncluded (Set.ofArray(notIncluded1))
            if unknowns.Count <> 0 then
                System.Console.WriteLine("Unknowns:")
            for u in unknowns do
                System.Console.WriteLine(u)
            if notIncluded.Count <> 0 then
                System.Console.WriteLine("Not Included:")
            for n in notIncluded do
                System.Console.WriteLine(n)


[<EntryPoint>]
let main argv = 
    Console.OutputEncoding <- System.Text.Encoding.UTF8;
    match argv with 
    | [|epubFileName; crepdlFileName |] -> 
        let validator = new Validator(new StreamReader(crepdlFileName))
        scanZip epubFileName validator
    | [|epubFileName|] -> 
        let validator = new Validator(new StringReader(crepdlSource))
        scanZip epubFileName validator
    | _ -> Console.WriteLine("Specify an EPUB file name")
    0 // return an integer exit code
