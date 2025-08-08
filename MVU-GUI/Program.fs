module 電子化文書の日本語レパートリー検証.Program

open System
open Avalonia
open Avalonia.Controls.ApplicationLifetimes
open Avalonia.FuncUI.Hosts
open Elmish
open Avalonia.Platform
open Avalonia.Controls
open Avalonia.FuncUI.Elmish
open Model
open Update
open View

type internal App() =
    inherit Application()
    override this.Initialize() = this.Styles.Add(Avalonia.Themes.Fluent.FluentTheme())

    override this.OnFrameworkInitializationCompleted() =
        match this.ApplicationLifetime with
        | :? IClassicDesktopStyleApplicationLifetime as desktop ->
            let mainWindow = MainWindow()
            
            let uri = System.Uri("avares://MVU-GUI/Assets/mumoji.ico")
            use stream = AssetLoader.Open(uri)
            mainWindow.Icon <- new WindowIcon(stream)
            
            desktop.MainWindow <- mainWindow
        | _ -> ()

[<STAThread>]
[<EntryPoint>]
let internal main args =
    AppBuilder
        .Configure<App>()
        .UsePlatformDetect()
        .LogToTrace()
        .StartWithClassicDesktopLifetime(args)