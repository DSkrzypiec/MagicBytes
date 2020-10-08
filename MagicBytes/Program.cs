using System;
using System.IO;
using Read.Domain;
using Read.Application;

namespace magicBytes
{
    class Program
    {
        static int Main(string[] args)
        {
            var path = args[0];
            var reader = new BytesReader(8);

            Action<string> fileFunc = (string path) =>
                Console.WriteLine(reader.ReadBytes(path).ToString());

            var parallelWalker = new ParallelFileWalker(path);
            parallelWalker.WalkInParallel(fileFunc);

            /* -- sync version:
            var walker = new FileWalker<FileBytes>(path, true);
            var results = walker.Walk(fileFunc);

            foreach (var entry in results)
            {
                Console.WriteLine(entry.Result.ToString());
            }
            */

            return 0;
        }
    }
}
