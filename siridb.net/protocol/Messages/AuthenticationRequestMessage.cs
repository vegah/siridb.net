using System;
using System.Collections.Generic;
using Fantasista.siridb.connection;
using Fantasista.siridb.protocol;

namespace Fantasista.siridb.net.protocol.Messages
{
    public class AuthenticationRequestMessage : IMessage
    {
        private byte[] _packedData;

        public AuthenticationRequestMessage(Credentials credentials,string database)
        {
            _packedData = QPack.Pack(new string[] {credentials.Username,credentials.Password,database});
            var obj = (IEnumerable<string>)QPack.Unpack(_packedData);
        }

        public byte Header => (byte)Protomap.CprotoReqAuth;

        public byte[] RawQPackHeader => _packedData;
    }
}