using System;
using System.IO;
using System.Net.Sockets;
using Fantasista.siridb.net.protocol.Messages;

namespace Fantasista.siridb.net.protocol
{
    public class MessageReader : IMessageReader
    {
        private NetworkStream _network_stream;
        private BinaryReader _reader;
        public MessageReader(NetworkStream s)
        {
            _network_stream = s;
            _reader = new BinaryReader(s);
        }
        public IResponseMessage Read()
        {
            if (!_network_stream.DataAvailable) return null;
            var length = _reader.ReadInt32();
            var streamid = _reader.ReadInt16();
            var id = _reader.ReadByte();
            var checksum = _reader.ReadByte();
            var bytes = _reader.ReadBytes(length);
            return ResponseMessage.Create(streamid,id,bytes);
        }
    }
}