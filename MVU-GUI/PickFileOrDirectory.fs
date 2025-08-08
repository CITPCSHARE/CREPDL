module 電子化文書の日本語レパートリー検証.PickFileOrDirectory

open Avalonia.Platform.Storage
open Avalonia.Controls
open System.Threading.Tasks

let internal pickFile (window: Window) (title: string)
             (patterns: string list) : Task<string > = 
    task {
        let fileType = FilePickerFileType(title)
        fileType.Patterns <- patterns

        let options = FilePickerOpenOptions(
            Title = title,
            AllowMultiple = false,
            FileTypeFilter = [ fileType ]
        )

        let! result = window.StorageProvider.OpenFilePickerAsync(options)

        return
            result
            |> Seq.tryHead
            |> Option.map (fun file -> file.Path.LocalPath)
            |> function
               | Some(str) -> str
               | None -> ""
    }
    

let internal pickDirectory (window: Window) (title: string) : Task<string> =
    task {
        let options = FolderPickerOpenOptions(
            Title = title,
            AllowMultiple = false
        )

        let! result = window.StorageProvider.OpenFolderPickerAsync(options)

        return
            result
            |> Seq.tryHead
            |> Option.map (fun folder -> folder.Path.LocalPath)
            |> function
               | Some(str) -> str
               | None -> ""
    }
