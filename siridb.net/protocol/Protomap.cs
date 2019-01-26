//
// Taken from 
// https://github.com/transceptor-technology/go-siridb-connector/blob/master/protomap.go
namespace Fantasista.siridb.protocol
{

    public enum Protomap : byte
    {
            // CprotoReqQuery for sending queries
            CprotoReqQuery = 0,

            // CprotoReqInsert for sending inserts
            CprotoReqInsert = 1,

            // CprotoReqAuth for authentication
            CprotoReqAuth = 2,

            // CprotoReqPing for ping on the connection
            CprotoReqPing = 3,

            // CprotoReqInfo for requesting database info
            CprotoReqInfo = 4,

            // CprotoReqLoadDB for loading a new database
            CprotoReqLoadDB = 5,

            // CprotoReqRegisterServer for registering a new server
            CprotoReqRegisterServer = 6,

            // CprotoReqFileServers for requesting a server.dat file
            CprotoReqFileServers = 7,

            // CprotoReqFileUsers for requesting a users.dat file
            CprotoReqFileUsers = 8,

            // CprotoReqFileGroups for requesting a groups.dat file
            CprotoReqFileGroups = 9,

            //CprotoReqAdmin for a manage server request
            CprotoReqAdmin = 32,

            // CprotoResQuery on query response
            CprotoResQuery = 0,

            // CprotoResInsert on insert response
            CprotoResInsert = 1,

            // CprotoResAuthSuccess on authentication success
            CprotoResAuthSuccess = 2,

            // CprotoResAck on ack
            CprotoResAck = 3,

            // CprotoResInfo on database info response
            CprotoResInfo = 4,

            // CprotoResFile on request file response
            CprotoResFile = 5,

            //CprotoAckAdmin on successful manage server request
            CprotoAckAdmin = 32,

            //CprotoAckAdminData on successful manage server request with data
            CprotoAckAdminData = 33,

            // CprotoErrMsg general error
            CprotoErrMsg = 64,

            // CprotoErrQuery on query error
            CprotoErrQuery = 65,

            // CprotoErrInsert on insert error
            CprotoErrInsert = 66,

            // CprotoErrServer on server error
            CprotoErrServer = 67,

            // CprotoErrPool on server error
            CprotoErrPool = 68,

            // CprotoErrUserAccess on server error
            CprotoErrUserAccess = 69,

            // CprotoErr on server error
            CprotoErr = 70,

            // CprotoErrNotAuthenticated on server error
            CprotoErrNotAuthenticated = 71,

            // CprotoErrAuthCredentials on server error
            CprotoErrAuthCredentials = 72,

            // CprotoErrAuthUnknownDb on server error
            CprotoErrAuthUnknownDb = 73,

            // CprotoErrLoadingDb on server error
            CprotoErrLoadingDb = 74,

            // CprotoErrFile on server error
            CprotoErrFile = 75,

            // CprotoErrAdmin on manage server error with message
            CprotoErrAdmin = 96,

            // CprotoErrAdminInvalidRequest on invalid manage server request
            CprotoErrAdminInvalidRequest = 97,

            // AdminNewAccount for create a new manage server account
            AdminNewAccount = 0,

            // AdminChangePassword for changing a server account password
            AdminChangePassword = 1,

            // AdminDropAccount for dropping a server account
            AdminDropAccount = 2,

            // AdminNewDatabase for creating a new database
            AdminNewDatabase = 3,

            // AdminNewPool for expanding a database with a new pool
            AdminNewPool = 4,

            // AdminNewReplica for expanding a database with a new replica
            AdminNewReplica = 5,

            // AdminGetVersion for getting the siridb server version
            AdminGetVersion = 64,

            // AdminGetAccounts for getting all accounts on a siridb server
            AdminGetAccounts = 65,

            // AdminGetDatabases for getting all database running on a siridb server
            AdminGetDatabases = 66        
    }
}