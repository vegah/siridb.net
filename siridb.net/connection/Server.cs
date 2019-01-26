using System;
using System.Collections.Concurrent;
using System.Net.Sockets;
using System.Threading.Tasks;
using Fantasista.siridb.net.protocol;
using Fantasista.siridb.net.protocol.Messages;

namespace Fantasista.siridb.connection
{
    public class Server
    {
        private string _host;
        private int _port;

        private IMessageWriter _writer;
        private IMessageReader _reader;
        private short stream_id;
        private ConcurrentDictionary<short,TaskCompletionSource<IResponseMessage>> _tasks;
        private Task _readTask;
        public Server(string host, int port)
        {
            _host = host;
            _port = port;
            _tasks = new ConcurrentDictionary<short, TaskCompletionSource<IResponseMessage>>();

        }

        public Task ConnectAsync(Credentials credentials, IDatabase database)
        {
            var current_id = stream_id;
            CreateWriterAndReader();
            var task_completion = CreateTask(credentials, database, current_id);
            StartReadTask();
            return task_completion.Task;
        }

        private void StartReadTask()
        {
            _readTask = new Task(() => ReadLoop(_reader));
            _readTask.Start();
        }

        private TaskCompletionSource<IResponseMessage> CreateTask(Credentials credentials, IDatabase database, short current_id)
        {
            var task_completion = new TaskCompletionSource<IResponseMessage>();
            _tasks.TryAdd(current_id, task_completion);
            var task = _writer.WriteAsync(current_id, new AuthenticationRequestMessage(credentials, database.Name));
            return task_completion;
        }

        private void CreateWriterAndReader()
        {
            var client = new TcpClient();
            client.Connect(_host, _port);
            var stream = client.GetStream();
            _writer = new MessageWriter(stream);
            _reader = new MessageReader(stream);
        }

        public void ReadLoop(IMessageReader reader)
        {
            while (true)
            {
                var message = reader.Read();
                if (message!=null)
                    if (_tasks.ContainsKey(message.StreamId))
                        _tasks[message.StreamId].SetResult(message);
            }
        }
    }
}