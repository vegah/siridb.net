using System;
using Fantasista.siridb.connection;

namespace examples
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Example code for connecting to siridb");
            var cluster = Cluster.Builder()
                                .AddServer("localhost")
                                .WithCredentials("iris","siri")
                                .WithDefaultDatabase("test")
                                .Build();
            var task= cluster.ConnectAsync();
            task.Wait();
            Console.WriteLine("Connected");
        }
    }
}
