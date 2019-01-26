using Fantasista.siridb.net.protocol.Messages;
using Fantasista.siridb.protocol;

namespace Fantasista.siridb.net.protocol
{
    public class ResponseMessage : IResponseMessage
    {
        protected short _streamid;
        protected byte _id;
        protected byte[] _bytes;
        public ResponseMessage(short streamid, byte id, byte[] bytes)
        {
            _streamid=streamid;
            _id = id;
            _bytes = bytes;
        }

        public short StreamId => _streamid;

        public static IResponseMessage Create(short streamid, byte id, byte[] bytes)
        {
            switch(id)
            {
                case (byte)Protomap.CprotoResAuthSuccess:
                {
                    return new AuthenticationSuccessResponseMessage(streamid,id,bytes);
                }
                default:
                    return new UnknownResponseMessage(streamid,id,bytes); 
            }
        }
    }
}