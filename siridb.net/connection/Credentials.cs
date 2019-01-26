namespace Fantasista.siridb.connection
{
    public class Credentials
    {
        public Credentials(string username, string password)
        {
            Username = username;
            Password = password;
        }
         public string Username {get;private set;}
         public string Password {get; private set;}
    }
}