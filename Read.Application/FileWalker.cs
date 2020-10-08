using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using Read.Domain;

namespace Read.Application
{
    public interface IFileWalker
    {
        void Walk(Action<string> fileFunc);
    }

    public class FileWalker : IFileWalker
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


        public void Walk(Action<string> fileFunc)
        {
            if (_walkRecursive)
                WalkRecursively(fileFunc);
            else
                WalkOnlyCurrentDir(fileFunc);
        }

        private void WalkOnlyCurrentDir(Action<string> fileFunc)
        {
            HandleFilesResults(_rootDirPath, fileFunc);
        }

        private void WalkRecursively(Action<string> fileFunc)
        {
            WalkRec(_rootDirPath, fileFunc);
        }

        private void WalkRec(string dirPath, Action<string> fileFunc)
        {
            HandleFilesResults(dirPath, fileFunc);

            string[] directories = new string[] {};

            try
            {
                directories = Directory.GetDirectories(dirPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Expection while getting directories from [{dirPath}]: {ex.Message}");
            }

            foreach (var dir in directories)
            {
                WalkRec(dir, fileFunc);
            }
        }

        private void HandleFilesResults(string dirPath, Action<string> fileFunc)
        {
            string[] filesWithinDir = new string[] {};

            try
            {
                filesWithinDir = Directory.GetFiles(dirPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Expection while getting files from [{dirPath}]: {ex.Message}");
            }

            foreach (var filePath in filesWithinDir)
            {
                try
                {
                    fileFunc(filePath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Expection while [{filePath}]: {ex.Message}");
                    continue;
                }
            }
        }
    }
}
