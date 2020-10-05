using System;
using System.Linq;
using System.Collections.Generic;

namespace Read.Domain
{
    public class FileBytes
    {
        private const int _byteLimitToPrint = 50;

        private string _filePath;
        private IList<byte> _bytes;

        public FileBytes(string filePath, IEnumerable<byte> bytes)
        {
            _filePath = filePath;
            _bytes = bytes.ToList();
        }

        public override string ToString()
        {
            if (_bytes.Count > _byteLimitToPrint)
            {
                return $"Too many bytes for {_filePath}, limit is {_byteLimitToPrint}";
            }

            string bytesInHex = BitConverter.ToString(_bytes.ToArray()).Replace("-", " ");

            return $"{_filePath}: [{bytesInHex}]";
        }
    }
}
