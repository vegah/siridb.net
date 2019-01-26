using System;
using Fantasista.siridb.net.protocol;

namespace Fantasista.siridb.net.protocol.Messages
{
    public class AuthenticationSuccessResponseMessage : ResponseMessage
    {
        public AuthenticationSuccessResponseMessage(short streamid, byte id, byte[] bytes)
        :base(streamid,id,bytes)
        {
            
        }

    }
}