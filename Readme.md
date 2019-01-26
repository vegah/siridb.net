# SiriDb.net
A dotnet library for using the SiriDb native protocol.  

## Install
Git clone and reference the project for now.  Nuget package coming.

## SiriDb protocol
The SiriDb protocol isn't very well documented, so I have written down what I have found out so that others can make clients in their favorite language.  This is of course not official documentation, so it could be wrong, but it is meant as random notes from when I was debugging and reading other client's code (golang,c,python).  If you find an error, make a pull request on the documentation.

### Connection
The native protocol listens on tcp port 9000.  The connetion stays up, and is being used for communicating back and forth between server and 
client.  After connection is established a CprotoReqAdmin request is sent to authenticate.
#### Message format
First a message header with this format:  
|Type|Content|
|----|-------|
|int32|Total length of the message.|
|int16|The id of the message on this stream.  This is used in the response to identify what the response is for|
|byte|The type of message|
|byte|Check bit.  This seems to be 0xff XOR the type of message byte.|

#### Authentication
Header : CprotoReqAdmin  - 0 
