using System.Threading.Tasks;

namespace Fantasista.siridb.net.protocol
{
    public interface IMessageWriter
    {
         Task WriteAsync(short streamid,IMessage message);
    }
}