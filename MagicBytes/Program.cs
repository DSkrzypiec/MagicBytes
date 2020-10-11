using System;
using System.IO;
using Read.Domain;
using Read.Application;
using CommandLine;

namespace MagicBytes
{
    class Program
    {
        static int Main(string[] args)
        {
            var options = new CmdOptions();
            var parsed = CommandLine.Parser.Default.ParseArguments<CmdOptions>(args)
                .WithParsed(o => Console.WriteLine($"{o.Path}, {o.NumberOfBytes}, {o.Recursive}"));


            /*
            var path = args[0];
            var reader = new BytesReader(8);

            Action<string> fileFunc = (string path) =>
                Console.WriteLine(reader.ReadBytes(path).ToString());

            var walker = new FileWalker(path, true);
            walker.Walk(fileFunc);
            */

            return 0;
        }
    }
}
