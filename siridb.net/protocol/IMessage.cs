namespace Fantasista.siridb.net.protocol
{
    public interface IMessage
    {
        byte Header {get;}
        byte[] RawQPackHeader {get;}
    }
}