using System;
using System.IO;
using Read.Domain;
using Read.Application;

namespace MagicBytes
{
    public interface IValidator
    {
        void Validate();
    }

    public class CmdOptionsValidator : IValidator
    {
        private const int MaxNumberOfBytes = 1024;
        private readonly CmdOptions _options;

        public CmdOptionsValidator(CmdOptions options)
        {
            _options = options;
        }

        public void Validate()
        {
            if (_options.NumberOfBytes <= 0 || _options.NumberOfBytes > MaxNumberOfBytes)
            {
                var bytesMsg = $"Incorrect number of bytes give [{_options.NumberOfBytes}]. " +
                    $"Number of bytes should be from interval [1, {MaxNumberOfBytes}].";

                throw new System.ArgumentOutOfRangeException(bytesMsg);
            }

            if (_options.MaxDepth < 0 || _options.MaxDepth > ushort.MaxValue)
            {
                var maxDepthMsg = $"Incorrect max depth value [{_options.MaxDepth}]. " +
                    $"Max depth recursion level should be from interval [0, {ushort.MaxValue}].";

                throw new System.ArgumentOutOfRangeException(maxDepthMsg);
            }
        }
    }
}
