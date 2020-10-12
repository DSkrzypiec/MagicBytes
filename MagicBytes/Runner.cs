using System;
using Read.Domain;
using Read.Application;

namespace MagicBytes
{
    public class Runner
    {
        private readonly IBytesReader _bytesReader;
        private readonly IFileWalker _fileWalker;
        private readonly string _separator;
        private readonly string _bytesSeparator;

        public Runner(
            IBytesReader bytesReader,
            IFileWalker fileWalker,
            string separator,
            string bytesSeperator)
        {
            _bytesReader = bytesReader;
            _fileWalker = fileWalker;
            _separator = separator;
            _bytesSeparator = bytesSeperator;
        }

        public void Run()
        {
            Action<string> fileFunc = (string path) =>
                Console.WriteLine(
                    _bytesReader
                        .ReadBytes(path)
                        .Format(_separator, _bytesSeparator));

            _fileWalker.Walk(fileFunc);
        }
    }
}
