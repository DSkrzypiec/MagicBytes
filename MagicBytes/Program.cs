using System;
using System.IO;
using Read.Domain;
using Read.Application;

namespace magicBytes
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = args[0];
            var reader = new BytesReader(8);
            //FileBytes bytes = reader.ReadBytes(path);
            //Console.WriteLine(bytes.ToString());

            Func<string, FileBytes> fileFunc = (string path) => reader.ReadBytes(path);

            var walker = new FileWalker<FileBytes>(path, true);
            var results = walker.Walk(fileFunc);

            foreach (var entry in results)
            {
                Console.WriteLine(entry.Result.ToString());
            }
        }
    }
}
