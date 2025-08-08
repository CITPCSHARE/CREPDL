module 電子化文書の日本語レパートリー検証.View

open Avalonia.Controls
open Avalonia.FuncUI.DSL
open Avalonia.Layout
open Avalonia.FuncUI.Types
open Model
open Msg
open Update
open Avalonia.Controls.Primitives
open Avalonia.Media

let view (model: Model) (dispatch: Msg -> unit) : IView =
    DockPanel.create [
        DockPanel.children [

            StackPanel.create [
                StackPanel.orientation Orientation.Horizontal
                StackPanel.spacing 1.0
                StackPanel.width 630.0
                StackPanel.height 520.0

                StackPanel.children [

                    // 左側のボタン群
                    StackPanel.create [
                        StackPanel.orientation Orientation.Vertical
                        StackPanel.spacing 8.0
                        StackPanel.margin (20.0, 10.0, 10.0, 10.0)
                        StackPanel.width 250.0

                        StackPanel.children [

                            Button.create [
                                Button.content "_EPUBファイルの検証"
                                Button.onClick (fun _ -> dispatch SelectEpubFile)
                            ]

                            Button.create [
                                Button.content "EPUB _Directoryの検証"
                                Button.onClick (fun _ -> dispatch SelectEpubDirectory)
                            ]

                            Button.create [
                                Button.content "_Word (docx)ファイルの検証"
                                Button.onClick (fun _ -> dispatch SelectDocxFile)
                            ]

                            Button.create [
                                Button.content "_HTMLファイルの検証"
                                Button.onClick (fun _ -> dispatch SelectHtmlFile)
                            ]

                            Button.create [
                                Button.content "_Textファイルの検証"
                                Button.onClick (fun _ -> dispatch SelectTextFile)
                            ]
                        ]
                    ]

                    // 右側の診断結果表示
                    StackPanel.create [
                        StackPanel.orientation Orientation.Vertical
                        StackPanel.spacing 8.0
                        StackPanel.margin (20.0, 10.0, 10.0, 10.0)

                        StackPanel.children [

                            Border.create [
                                Border.borderThickness 1.0
                                Border.borderBrush "Gray"
                                Border.child (
                                    ScrollViewer.create [
                                        ScrollViewer.height 500.0
                                        ScrollViewer.width 300.0
                                        ScrollViewer.verticalScrollBarVisibility ScrollBarVisibility.Visible
                                        ScrollViewer.horizontalScrollBarVisibility ScrollBarVisibility.Visible

                                        ScrollViewer.content (
                                            TextBlock.create [
                                                TextBlock.text model.Diagnostics
                                                TextBlock.fontFamily "Arial Unicode MS"
                                                TextBlock.margin (20.0,10.0,20.0,10.0)
                                                TextBlock.textAlignment TextAlignment.Left
                                            ]
                                        )
                                    ]
                                )
                            ]
                        ]
                    ]
                ]
            ]
        ]
    ]