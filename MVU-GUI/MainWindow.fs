namespace 電子化文書の日本語レパートリー検証

open System
open Avalonia
open Avalonia.Controls.ApplicationLifetimes
open Avalonia.FuncUI.Hosts
open Elmish
open Avalonia.Platform
open Avalonia.Controls
open Avalonia.FuncUI.Elmish
open 電子化文書の日本語レパートリー検証.Model
open 電子化文書の日本語レパートリー検証.Update
open 電子化文書の日本語レパートリー検証.View

type MainWindow() as this =
    inherit HostWindow()

    do
        base.Title <- "電子化文書の日本語レパートリー検証"
        base.Width <- 640.0
        base.Height <- 540.0
     //   base.Icon <- WindowIcon("/Assets/mumoji.ico")

        // Elmishプログラムの起動
        Elmish.Program.mkProgram
            (fun () -> initModel, Cmd.none)
            (update this)   // ← Windowインスタンスを渡す
            view
        |> Program.withHost this
        |> Program.withConsoleTrace
        |> Program.withErrorHandler (fun (_, ex) -> printfn "%s" ex.Message)
        |> Program.runWithAvaloniaSyncDispatch ()