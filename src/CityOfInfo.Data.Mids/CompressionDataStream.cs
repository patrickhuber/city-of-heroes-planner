using ICSharpCode.SharpZipLib.Zip.Compression.Streams;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CityOfInfo.Data.Mids
{
    /// <summary>
    /// Creates a stream around a CompressedData object so it can be read by a binary reader and binary writer
    /// </summary>
    public class CompressionDataStream : Stream
    {
        private Stream _internalStream;

        public CompressionDataStream(CompressionData data)
        {
            var encoded = Encoding.ASCII.GetBytes(data.EncodedString);
            var decodedBytes = HexUtil.Decode(encoded);
            var compressedStream = new MemoryStream(decodedBytes);
            _internalStream = new InflaterInputStream(compressedStream);
        }

        public override bool CanRead => true;

        public override bool CanSeek => false;

        public override bool CanWrite => false;

        public override long Length => _internalStream.Length;

        public override long Position
        {
            get { return _internalStream.Position; }
            set { _internalStream.Position = value; }
        }

        public override void Flush()
        {
            _internalStream.Flush();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return _internalStream.Read(buffer, offset, count);
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return _internalStream.Seek(offset, origin);
        }

        public override void SetLength(long value)
        {
            _internalStream.SetLength(value);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            _internalStream.Write(buffer, offset, count);
        }
    }
}
