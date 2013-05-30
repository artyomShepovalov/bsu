using System;

namespace templates_decorator.@abstract
{
    public abstract class AbstractStream : IStream, IDisposable
    {
        protected System.IO.Stream Stream { get; set; }

        private const int BufferSize = 10000;
        private readonly byte[] _buffer = new byte[BufferSize];
        private int _currentPos;

        public void PutBytes(byte[] bytes)
        {
            if (bytes.Length > BufferSize)
            {
                return;
            }
            if (bytes.Length > BufferSize - _currentPos)
            {
                HandleBufferFull();
            }

            var j = 0;

            for (var i = _currentPos; i < _currentPos + bytes.Length; ++i)
            {
                _buffer[i] = bytes[j++];
            }

            _currentPos += bytes.Length;
        }

        public void PutInt(int number)
        {
            PutBytes(BitConverter.GetBytes(number));
        }

        public virtual void HandleBufferFull()
        {
            Stream.Write(_buffer, 0, BufferSize);
            _currentPos = 0;
        }

        public void Dispose()
        {
            Stream.Close();
        }
    }
}