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

        [Option('n', "num_bytes", Required = false,
                HelpText = "Number of first bytes to be read", Default = 8)]
        public int NumberOfBytes { get; set; }


        [Usage(ApplicationAlias = "magicBytes")]
        public static IEnumerable<Example> Examples
        {
            get
            {
                return new List<Example>() {
                    new Example("Basic usage", new CmdOptions{ Path = "~/path/to/dir" })
                };
            }
        }
    }
}