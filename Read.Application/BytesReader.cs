using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using Read.Domain;

namespace Read.Application
{
    public interface IBytesReader
    {
        FileBytes ReadBytes(string path);
    }

    public class BytesReader : IBytesReader
    {
        private readonly int _numberOfBytes;

        public BytesReader(int numberOfBytesToBeRead)
        {
            _numberOfBytes = numberOfBytesToBeRead;
        }

        public FileBytes ReadBytes(string path)
        {
            var bytes = new List<byte>(_numberOfBytes);

            using (StreamReader reader = new StreamReader(path))
            {
                for (var i = 0; i < _numberOfBytes; i++)
                {
                    if (reader.Peek() < 0)
                    {
                        break;
                    }

                    bytes.Add((byte)reader.Read());
                }
            }

            var res = new FileBytes(path, bytes);

            return res;
        }
    }
}
