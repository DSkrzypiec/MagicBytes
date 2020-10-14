using System;
using System.Collections.Generic;
using CommandLine;
using CommandLine.Text;

namespace MagicBytes
{
    public class CmdOptions
    {
        [Value(0, Required = true,
            HelpText = "Path to a file or a directory")]
        public string Path { get; set; }

        [Option('r', "recursive", Required = false,
                HelpText = "Recursion for sub catalogs")]
        public bool Recursive { get; set; }

        [Option('d',"max_depth", Required = false, Default = ushort.MaxValue,
                HelpText = "Max depth level for recursion")]
        public int MaxDepth { get; set; }

        [Option('n', "num_bytes", Required = false,
                HelpText = "Number of first bytes to be read", Default = 8)]
        public int NumberOfBytes { get; set; }

        [Option('s', "separator", Required = false, Default = ": ",
                HelpText = "Separator in output between file path and sequence of bytes")]
        public string Separator { get; set; }

        [Option('b', "byte_separator", Required = false, Default = " ",
                HelpText = "Separator between bytes in byte sequence")]
        public string BytesSeparator { get; set; }


        [Usage(ApplicationAlias = "magicBytes")]
        public static IEnumerable<Example> Examples
        {
            get
            {
                return new List<Example>() {
                    new Example("Basic usage", new CmdOptions{ Path = "~/path/to/dir" }),
                    new Example("Single file", new CmdOptions{ Path = "/path/to/file.ext" }),
                    new Example("All files", new CmdOptions
                        {
                            Path = "~/path/to/dir",
                            Recursive = true,
                            NumberOfBytes = 16
                        })
                };
            }
        }
    }
}
