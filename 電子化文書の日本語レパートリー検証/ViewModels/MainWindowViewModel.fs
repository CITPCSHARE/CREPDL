namespace 電子化文書の日本語レパートリー検証.ViewModels

open ReactiveUI
open 電子化文書の日本語レパートリー検証.Models.Toolkit
open 電子化文書の日本語レパートリー検証.Models.EpubValidator
open 電子化文書の日本語レパートリー検証.Models.HtmlValidator
open 電子化文書の日本語レパートリー検証.Models.WmlValidator

type MainWindowViewModel() =
    inherit ViewModelBase()

    let mutable epubfile = ""
    let mutable epubDirectory = ""
    let mutable htmlFile = ""
    let mutable wmlFile = ""
    let mutable diagnostics = ""
    let validatorStruct = createValidatorStruct()

    member this.Diagnostics
        with get() = 
             diagnostics
        and set(s : string) = 
             ignore <| this.RaiseAndSetIfChanged(&diagnostics, s)

    member this.Epubfile
        with get() = 
             epubfile
        and set(s : string) = 
             ignore <| this.RaiseAndSetIfChanged(&epubfile, s)

    member this.EpubDirectory
        with get() = 
             epubDirectory
        and set(s : string) = 
             ignore <| this.RaiseAndSetIfChanged(&epubDirectory, s)

    member this.HtmlFile
        with get() = 
             htmlFile
        and set(s : string) = 
             ignore <| this.RaiseAndSetIfChanged(&htmlFile, s)
    
    member this.WmlFile
        with get() = 
             wmlFile
        and set(s : string) = 
             ignore <| this.RaiseAndSetIfChanged(&wmlFile, s)
    

    member this.Validate() =
        this.Diagnostics <-
            if epubfile <> "" then validateEpubFile validatorStruct epubfile
            elif epubDirectory <> "" then validateEpubDirectory validatorStruct epubDirectory
            elif htmlFile <> "" then validateHtmlFile validatorStruct htmlFile
            elif wmlFile <> "" then validateWmlFile validatorStruct wmlFile
            else ""
