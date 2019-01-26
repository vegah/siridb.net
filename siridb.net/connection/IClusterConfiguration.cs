using System.Collections.Generic;

namespace Fantasista.siridb.connection
{
    public interface IClusterConfiguration
    {
         List<Server> Servers {get;}
         Credentials Credentials {get;}
         IDatabase Database {get;}
    }
}