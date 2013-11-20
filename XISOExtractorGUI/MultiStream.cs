namespace XISOExtractorGUI
{
    using System;
    using System.Collections;
    using System.IO;

    public class MultiStream : Stream
    {
        readonly ArrayList _streamList = new ArrayList();
        long _position;

        #region Methods

        #region Empty Methods

        public override void Flush() {
        }

        public override void SetLength(long value) {
        }

        public override void Write(byte[] buffer, int offset, int count) {
        }

        #endregion Empty Methods
        
        public override long Seek(long offset, SeekOrigin origin) {
            var len = Length;
            switch (origin)
            {
                case SeekOrigin.Begin:
                    _position = offset;
                    break;
                case SeekOrigin.Current:
                    _position += offset;
                    break;
                case SeekOrigin.End:
                    _position = len - offset;
                    break;
            }
            if (_position > len)
                _position = len;
            else if (_position < 0)
                _position = 0;
            return _position;
        }

        public override int Read(byte[] buffer, int offset, int count) {
            long len = 0;
            var result = 0;
            var bufPos = offset;
            foreach (Stream stream in _streamList)
            {
                if (_position < (len + stream.Length))
                {
                    stream.Position = _position - len;
                    var bytesRead = stream.Read(buffer, bufPos, count);
                    result += bytesRead;
                    bufPos += bytesRead;
                    _position += bytesRead;
                    if (bytesRead < count)
                        count -= bytesRead;
                    else
                        break;
                }
                len += stream.Length;
            }
            return result;
        }

        public byte[] ReadBytes(int count) {
            if (count < 0)
                return new byte[0];
            var buffer = new byte[count];
            var length = 0;
            do {
                var num = Read(buffer, length, count);
                if (num == 0)
                    break;
                length += num;
                count -= num;
            }
            while (count > 0);
            if (length != buffer.Length) {
                var numArray = new byte[length];
                Buffer.BlockCopy(buffer, 0, numArray, 0, length);
                return numArray;
            }
            return buffer;
        }

        public void AddStream(Stream stream) {
            _streamList.Add(stream);
        }

        public override void Close() {
            foreach (Stream stream in _streamList)
                stream.Close();
            base.Close();
        }

        #endregion

        #region Properties

        public override bool CanRead {
            get { return true; }
        }

        public override bool CanSeek {
            get { return true; }
        }

        public override long Length {
            get
            {
                long ret = 0;
                foreach (Stream stream in _streamList)
                    ret += stream.Length;
                return ret;
            }
        }

        public override long Position {
            get {
                return _position;
            }
            set { 
                Seek(value, SeekOrigin.Begin);
            }
        }

        

        public override bool CanWrite
        {
            get { return false; }
        }

        #endregion Properties
    }
}