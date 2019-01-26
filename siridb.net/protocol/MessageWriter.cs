using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Fantasista.siridb.net.protocol
{
    public class MessageWriter : IMessageWriter
    {
        private Stream _stream;

        public MessageWriter(Stream stream)
        {
            _stream = stream;
        }
        public Task WriteAsync(short streamid,IMessage message)
        {
            var buffer = GetBuffer(streamid,message);
            Console.WriteLine($"Sending message of {buffer.Length}");

            return _stream.WriteAsync(buffer,0,buffer.Length);
        }

        private byte[] GetBuffer(short streamid, IMessage message)
        {
            var start = new List<byte>(BitConverter.GetBytes((Int32)message.RawQPackHeader.Length));
            start.AddRange(BitConverter.GetBytes(streamid));
            start.Add(message.Header);
            start.Add((byte)(0xff^message.Header));
            start.AddRange(message.RawQPackHeader);
            return start.ToArray();
        }
    }
}