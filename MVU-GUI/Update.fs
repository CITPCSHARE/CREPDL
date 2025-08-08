module 電子化文書の日本語レパートリー検証.Update

open Avalonia.Controls
open Model
open Msg
open PickFileOrDirectory
open Elmish
open Toolkit
open WmlValidator
open EpubValidator
open TextValidator
open HtmlValidator

let update (window: Window) (msg: Msg) (model: Model) : Model * Cmd<Msg> =
    let validator = createValidatorStruct()

    match msg with
    // ────────────── ファイル選択コマンド ──────────────
    | SelectEpubFile ->
        let cmd = Cmd.OfTask.perform
                    (fun () -> pickFile window "EPUBファイル" [ "*.epub" ])
                    ()
                    EpubFileSelected
        model, cmd

    | SelectEpubDirectory ->
        let cmd = Cmd.OfTask.perform
                    (fun () -> pickDirectory window "EPUBディレクトリ")
                    ()
                    EpubDirectorySelected
        model, cmd

    | SelectDocxFile ->
        let cmd = Cmd.OfTask.perform
                    (fun () -> pickFile window "Word (docx) ファイル" [ "*.docx" ])
                    ()
                    DocxFileSelected
        model, cmd

    | SelectHtmlFile ->
        let cmd = Cmd.OfTask.perform
                    (fun () -> pickFile window "HTMLファイル" [ "*.html"; "*.htm" ])
                    ()
                    HtmlFileSelected
        model, cmd

    | SelectTextFile ->
        let cmd = Cmd.OfTask.perform
                    (fun () -> pickFile window "Textファイル" [ "*.txt" ])
                    ()
                    TextFileSelected
        model, cmd

    // ────────────── ファイル選択後の検証処理 ──────────────
    | EpubFileSelected path ->
        printfn "EPubFileSelected"
        if path = "" then model, Cmd.none
        else
            let result = validateEpubFile validator path
            { model with Diagnostics = result }, Cmd.none

    | EpubDirectorySelected path ->
        if path = "" then model, Cmd.none
        else
            let result = validateEpubDirectory validator path
            { model with Diagnostics = result }, Cmd.none

    | DocxFileSelected path ->
        if path = "" then model, Cmd.none
        else
            let result = validateWmlFile validator path
            { model with Diagnostics = result }, Cmd.none

    | HtmlFileSelected path ->
        if path = "" then model, Cmd.none
        else
            let result = validateHtmlFile validator path
            { model with Diagnostics = result }, Cmd.none

    | TextFileSelected path ->
        if path = "" then model, Cmd.none
        else
            let result = validateTextFile validator path
            { model with Diagnostics = result }, Cmd.none

    // ────────────── 任意の表示更新 ──────────────
    | SetDiagnostics text ->
        { model with Diagnostics = text }, Cmd.none