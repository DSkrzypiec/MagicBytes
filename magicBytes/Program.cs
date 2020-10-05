using System;
using Read.Domain;
using Read.Application;

namespace magicBytes
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = args[0];
            var reader = new BytesReader(8);
            FileBytes bytes = reader.ReadBytes(path);
            Console.WriteLine(bytes.ToString());
        }
    }
}
