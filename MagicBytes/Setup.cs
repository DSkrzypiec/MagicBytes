using System;
using System.IO;
using Read.Domain;
using Read.Application;
using CommandLine;

namespace MagicBytes
{
    public static class Setup
    {
        public static void RunWithOptions(CmdOptions options)
        {
            var validator = new CmdOptionsValidator(options);
            validator.Validate();

            var bytesReader = new BytesReader(options.NumberOfBytes);

            var attr = File.GetAttributes(options.Path);
            if (!attr.HasFlag(FileAttributes.Directory)) {
                RunForSingleFile(bytesReader, options.Path);
                return;
            }

            var fileWalker = new FileWalker(options.Path, options.Recursive);
            var runner = new Runner(bytesReader, fileWalker);

            runner.Run();
        }

        private static void RunForSingleFile(IBytesReader bytesReader, string path)
        {
            Console.WriteLine(bytesReader.ReadBytes(path).ToString());
        }
    }
}
