using Fantasista.siridb.protocol;

namespace Fantasista.siridb.net.protocol.Messages
{
    public class UnknownResponseMessage : ResponseMessage
    {
        public UnknownResponseMessage(short streamid, byte id, byte[] bytes) : base(streamid, id, bytes)
        {
        }
    }
}