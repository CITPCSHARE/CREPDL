# CREPDL

Implementation of ISO/IEC 19757-7 (CREPDL) in F#

## Overview

This is a .Net library. It is usable from any .Net programming language such as C#, Visual Basic .Net, and F#.

A rudimentary command-line program for invoking this library is provided.  Another rudimentary command-line program for examining EPUB publications is provided.

Avalonia-based GUI for invoking this library is also provided.

This repository does not contain any examples of CREPDL scripts. See another repository CREPDLScripts for a collection of CREPDL scripts.

## Branches

Use the branch "version2" or "icu-free". The other branches are archaic.

## Programming

Use Visual Studio 2015 (and beyond) for cloning this repository.

Use the CREPDL project in the CREPDL solution. The other projects are for testing, preprocessing, and experiments.

The .Net API for this implementation is described in a [help file](https://github.com/CITPCSHARE/CREPDL/blob/Version2/Help/Documentation.chm).  Use the download button to download the help file.  This help file covers many classes, but you need Validation.Validator and nothing else.

## History

Converted to a repository of CITPC on 2017-05-22.

## Lincse 

The license of CREPDL is MIT License.  License of used libraries are shown below:

- F#, MIT License https://github.com/Microsoft/visualfsharp/blob/master/License.txt
- .Net libraries, .Net License https://github.com/dotnet/core-setup/blob/master/LICENSE.TXT
- HTML Aagility Pack, MIT License https://github.com/zzzprojects/html-agility-pack/blob/master/LICENSE
- icu.net MIT License https://licenses.nuget.org/MIT
- ICU4C https://github.com/sillsdev/icu4c/blob/trunk/LICENSE
  - data Unicode Consritum License 
  - code ICU License
- NewtonSoft.Json MIT License https://licenses.nuget.org/MIT
