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

            /* -- parallel version:
            var parallelWalker = new ParallelFileWalker(path);
            parallelWalker.WalkInParallel(fileFunc);
            */

            ///* -- sync version:
            var walker = new FileWalker(path, true);
            walker.Walk(fileFunc);

            //*/

            return 0;
        }
    }
}
