using System;
using System.IO;
using Read.Domain;
using Read.Application;
using CommandLine;

namespace MagicBytes
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new CmdOptions();
            var parsed = CommandLine.Parser.Default.ParseArguments<CmdOptions>(args)
                .WithParsed(o => Setup.RunWithOptions(o));
        }
    }
}
