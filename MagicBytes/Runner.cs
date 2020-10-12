using System;
using Read.Domain;
using Read.Application;

namespace MagicBytes
{
    public class Runner
    {
        private readonly IBytesReader _bytesReader;
        private readonly IFileWalker _fileWalker;

        public Runner(
            IBytesReader bytesReader,
            IFileWalker fileWalker)
        {
            _bytesReader = bytesReader;
            _fileWalker = fileWalker;
        }

        public void Run()
        {
            Action<string> fileFunc = (string path) =>
                Console.WriteLine(_bytesReader.ReadBytes(path).ToString());

            _fileWalker.Walk(fileFunc);
        }
    }
}
