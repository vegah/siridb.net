namespace Fantasista.siridb.connection
{
    public class Database : IDatabase
    {
        public Database(string name)
        {
            Name = name;
        }
        public string Name {get;private set;}
    }
}