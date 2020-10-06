using System;

namespace Read.Application
{
    public class PathValidator
    {
        private readonly string _path;

        public PathValidator(string path)
        {
            _path = path;
        }

        public bool IsValid()
        {
            // TODO
            return false;
        }
    }

    public static class PathFix
    {
        public static string GetParentDirectory(string path)
        {
            // TODO
            return path;
        }
    }
}
