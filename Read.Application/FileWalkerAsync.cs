using System;
using System.IO;
using System.Threading.Tasks;
using System.Threading.Channels;

namespace Read.Application
{
    public interface IFileWalkerAsync<T>
    {
        Task WalkAsync(Func<string, T> fileFunc);
    }

    public class FileWalkerAsync<T> : IFileWalkerAsync<T>
    {
        private readonly Channel<T> _channel;
        private readonly string _rootDirPath;

        public FileWalkerAsync(string rootDirPath, Channel<T> channel)
        {
            _rootDirPath = rootDirPath;
            _channel = channel;
        }

        public async Task WalkAsync(Func<string, T> fileFunc)
        {
            await WalkRec(_rootDirPath, fileFunc);
            _channel.Writer.Complete();
        }

        private async Task WalkRec(string dirPath, Func<string, T> fileFunc)
        {
            await SendFilesBytes(dirPath, fileFunc);

            foreach (var dir in Directory.GetDirectories(dirPath))
            {
                await WalkRec(dir, fileFunc);
            }
        }

        private async Task SendFilesBytes(string dirPath, Func<string, T> fileFunc)
        {
            var filesWithinDir = Directory.GetFiles(dirPath);

            foreach (var filePath in filesWithinDir)
            {
                T result;

                try
                {
                    result = fileFunc(filePath);
                }
                catch (Exception ex)
                {
                    // TODO
                    Console.WriteLine($"Expection while fileFunc({filePath}): {ex.Message}");
                    continue;
                }

                await _channel.Writer.WriteAsync(result);
            }
        }
    }
}
