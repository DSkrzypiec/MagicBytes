using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Read.Application
{
    public interface IParallelFileWalker
    {
        void WalkInParallel(Action<string> fileFunc);
    }

    public class ParallelFileWalker : IParallelFileWalker
    {
        private readonly string _rootDirPath;

        public ParallelFileWalker(string rootDirPath)
        {
            _rootDirPath = rootDirPath;
        }

        public void WalkInParallel(Action<string> fileFunc)
        {
            var options = new ParallelOptions();
            options.MaxDegreeOfParallelism = 8;

            var paths = FilePaths();

            Parallel.ForEach(
                paths,
                options,
                path =>
                {
                    try
                    {
                        fileFunc(path);
                    }
                    catch (Exception ex) // TODO
                    {
                        Console.WriteLine($"Expection in [{path}]: {ex.Message}");
                    }
                });
        }

        private IList<string> FilePaths()
        {
            var paths = new List<string>(10000);
            FilePathsRecursive(_rootDirPath, paths);

            return paths;
        }

        private void FilePathsRecursive(string dirPath, IList<string> paths)
        {
            foreach (var filesWithinDir in Directory.GetFiles(dirPath))
            {
                paths.Add(filesWithinDir);
            }

            foreach (var dir in Directory.GetDirectories(dirPath))
            {
                FilePathsRecursive(dir, paths);
            }
        }
    }
}
