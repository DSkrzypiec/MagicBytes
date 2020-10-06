using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using Read.Domain;

namespace Read.Application
{
    public interface IFileWalker<T>
    {
        IList<PathResult<T>> Walk(Func<string, T> fileFunc);
        Task<IList<PathResult<T>>> WalkAsync(Func<string, T> fileFunc);
    }

    public class FileWalker<T> : IFileWalker<T>
    {
        private readonly string _rootDirPath;
        private readonly bool _walkRecursive = false;

        public FileWalker(string rootDirPath)
        {
            _rootDirPath = rootDirPath;
        }

        public FileWalker(string rootDirPath, bool recursively)
        {
            _rootDirPath = rootDirPath;
            _walkRecursive = recursively;
        }


        public IList<PathResult<T>> Walk(Func<string, T> fileFunc)
        {
            return _walkRecursive ? WalkRecursively(fileFunc) : WalkOnlyCurrentDir(fileFunc);
        }

        public Task<IList<PathResult<T>>> WalkAsync(Func<string, T> fileFunc)
        {
            // TODO
            return null;
        }

        private IList<PathResult<T>> WalkOnlyCurrentDir(Func<string, T> fileFunc)
        {
            var results = new List<PathResult<T>>();
            AddFilesResults(_rootDirPath, fileFunc, results);

            return results;
        }

        private IList<PathResult<T>> WalkRecursively(Func<string, T> fileFunc)
        {
            var results = new List<PathResult<T>>();
            WalkRec(_rootDirPath, fileFunc, results);

            return results;
        }

        private void WalkRec(string dirPath, Func<string, T> fileFunc, IList<PathResult<T>> results)
        {
            AddFilesResults(dirPath, fileFunc, results);

            foreach (var dir in Directory.GetDirectories(dirPath))
            {
                WalkRec(dir, fileFunc, results);
            }
        }

        private void AddFilesResults(string dirPath, Func<string, T> fileFunc, IList<PathResult<T>> results)
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

                results.Add(new PathResult<T>{ Path = filePath, Result = result });
            }
        }
    }
}
