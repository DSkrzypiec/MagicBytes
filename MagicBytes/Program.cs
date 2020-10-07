using System;
using System.IO;
using System.Threading.Tasks;
using System.Threading.Channels;
using Read.Domain;
using Read.Application;

namespace magicBytes
{
    class Program
    {
        static async Task<int> Main(string[] args)
        {
            var path = args[0];
            var reader = new BytesReader(8);

            Func<string, FileBytes> fileFunc = (string path) => reader.ReadBytes(path);
            Channel<FileBytes> byteChannel = Channel.CreateUnbounded<FileBytes>();

            var walkerAsync = new FileWalkerAsync<FileBytes>(path, byteChannel);
            await walkerAsync.WalkAsync(fileFunc);

            var printer = Task.Run(async () =>
            {
                while (await byteChannel.Reader.WaitToReadAsync())
                    Console.WriteLine(await byteChannel.Reader.ReadAsync());
            });

            await Task.WhenAll(printer);

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
