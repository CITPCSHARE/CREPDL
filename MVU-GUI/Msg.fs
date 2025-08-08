module 電子化文書の日本語レパートリー検証.Msg

type Msg =
    | SelectEpubFile
    | SelectEpubDirectory
    | SelectDocxFile
    | SelectHtmlFile
    | SelectTextFile
    | EpubFileSelected of string
    | EpubDirectorySelected of string
    | DocxFileSelected of string
    | HtmlFileSelected of string
    | TextFileSelected of string
    | SetDiagnostics of string