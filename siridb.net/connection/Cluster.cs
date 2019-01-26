using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fantasista.siridb.connection
{
    public class Cluster    
    {
        private List<Server> _servers;
        private Credentials _credentials;
        private IDatabase _database;

        internal Cluster(List<Server> servers, Credentials credentials, IDatabase database)
        {
            _servers = servers;
            _credentials = credentials;
            _database = database;
        }
        public static Builder Builder()
        {
            return new Builder();
        }

        public Task ConnectAsync()
        {
            var tasks = new List<Task>();
            foreach (var server in _servers)
                tasks.Add(server.ConnectAsync(_credentials,_database));
            return Task.WhenAll(tasks);
            
        }

        internal static Cluster FromConfigurator(IClusterConfiguration cluster)
        {
            return new Cluster(cluster.Servers,cluster.Credentials,cluster.Database);
        }
    }
}
