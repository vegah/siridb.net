using System.Collections.Generic;

namespace Fantasista.siridb.connection
{
    public class Builder :  IClusterConfiguration
    {
        public Builder()
        {
            Servers = new List<Server>();
        }

        public List<Server> Servers { get; private set; }
        public Credentials Credentials { get; private set; }
        public IDatabase Database { get; private set; }

        public Builder AddServer(string host)
        {
            return AddServer(host,9000);
        }

        public Builder AddServer(string host, int port)
        {
            return AddServer(new Server(host,port));
        }

        public Builder AddServer(Server server)
        {
            Servers.Add(server);
            return this;
        }

        public Builder WithCredentials(string username,string password)
        {
            Credentials = new Credentials(username,password);
            return this;
        }

        public Builder WithDefaultDatabase(string database)
        {
            Database = new Database(database);
            return this;
        }

        public Cluster Build()
        {
            return Cluster.FromConfigurator(this);
        }

    }
}