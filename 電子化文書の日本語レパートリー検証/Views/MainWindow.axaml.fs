namespace 電子化文書の日本語レパートリー検証.Views

open Avalonia
open Avalonia.Controls
open Avalonia.Markup.Xaml
open 電子化文書の日本語レパートリー検証.ViewModels

type MainWindow () as this = 
    inherit Window ()
    let mutable epubFileValidateButton:Button = null
    let mutable epubDirectoryValidateButton:Button = null
    let mutable wmlValidateButton:Button = null
    let mutable htmlValidateButton:Button = null

    do this.InitializeComponent()

    member private this.InitializeComponent() =
#if DEBUG
        this.AttachDevTools()
#endif
        AvaloniaXamlLoader.Load(this)
        
        epubFileValidateButton <- this.Find<Button>("ValidateEpubFile")
        epubDirectoryValidateButton <- this.Find<Button>("ValidateEpubDirectory")
        wmlValidateButton <- this.Find<Button>("ValidateDocxFile")
        htmlValidateButton <- this.Find<Button>("ValidateHtmlFile")

        epubFileValidateButton.Click.Subscribe(fun _ -> 
            let dialog = new OpenFileDialog()
            let f1 = new FileDialogFilter(Name = "EPUBファイル")
            f1.Extensions.Add("epub")
            dialog.Filters.Add(f1)
            let f2 = new FileDialogFilter(Name = "全てのファイル")
            f2.Extensions.Add("*")
            dialog.Filters.Add(f2)
            let epubFiles = dialog.ShowAsync(this) |>  Async.AwaitTask |> Async.RunSynchronously 
            let dc = this.DataContext :?> MainWindowViewModel
            dc.Epubfile <- if epubFiles = null then "" else epubFiles.[0]
            dc.EpubDirectory <- ""
            dc.WmlFile <- ""
            dc.HtmlFile <- ""
            dc.Validate()
            ()) |> ignore

        epubDirectoryValidateButton.Click.Subscribe(fun _ -> 
            let dialog = new OpenFolderDialog()
            let epubDirectory = dialog.ShowAsync(this) |>  Async.AwaitTask |> Async.RunSynchronously
            let dc = this.DataContext :?> MainWindowViewModel
            dc.EpubDirectory <- epubDirectory
            dc.Epubfile <- ""
            dc.WmlFile <- ""
            dc.HtmlFile <- ""
            dc.Validate()
            ()) |> ignore

        wmlValidateButton.Click.Subscribe(fun _ -> 
            let dialog = new OpenFileDialog()
            let f1 = new FileDialogFilter(Name = "DOCXファイル")
            f1.Extensions.Add("docx")
            dialog.Filters.Add(f1)
            let f2 = new FileDialogFilter(Name = "全てのファイル")
            f2.Extensions.Add("*")
            dialog.Filters.Add(f2)
            let wmlFiles = dialog.ShowAsync(this) |>  Async.AwaitTask |> Async.RunSynchronously
            let dc = this.DataContext :?> MainWindowViewModel 
            dc.WmlFile <- if wmlFiles = null then "" else wmlFiles.[0]
            dc.Epubfile <- ""
            dc.EpubDirectory <- ""
            dc.HtmlFile <- ""
            dc.Validate()
            ()) |> ignore
        
        htmlValidateButton.Click.Subscribe(fun _ -> 
            let dialog = new OpenFileDialog()
            let f1 = new FileDialogFilter(Name = "HTMLファイル")
            f1.Extensions.Add("html")
            dialog.Filters.Add(f1)
            let f2 = new FileDialogFilter(Name = "全てのファイル")
            f2.Extensions.Add("*")
            dialog.Filters.Add(f2)
            let htmlFiles = dialog.ShowAsync(this) |>  Async.AwaitTask |> Async.RunSynchronously
            let dc = this.DataContext :?> MainWindowViewModel 
            dc.HtmlFile <- if htmlFiles = null then "" else htmlFiles.[0]
            dc.Epubfile <- ""
            dc.EpubDirectory <- ""
            dc.WmlFile <- ""
            dc.Validate()
            ()) |> ignore
