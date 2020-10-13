# MagicBytes

## About

This project is about to write simple and specific tool which would go through
some set of files and take their few first bytes.


## Usage

After compilation program is located in `/MagicBytes/bin` catalog under
appropriate configuration and version catalogs. Basic usage is as follows:

```
./MagicBytes/bin/Debug/netcoreapp3.1/magicBytes ~/path/to/catalog/or/file
```

That execution would print `filePath: {bytes}` in case of a single file and in
case of a directory the same but for each file.

This program also supports recursive traversing of all sub catalogs with flag
`-r`. For details checkout `magicBytes --help`.

Few examples are shown in the following screen cast:

[![asciicast](https://asciinema.org/a/xnnz92nIruDYO2KtbhI1ZZdnv.svg)](https://asciinema.org/a/xnnz92nIruDYO2KtbhI1ZZdnv)


## Compilation

Project is written in C#. It can be compiled on Linux using .NET Core or Mono
and on Windows using also .NET Core SDK or Visual Studio. Using .NET Core just
run in repo root catalog:

```
dotnet build
```



