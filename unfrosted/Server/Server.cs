using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using unfrosted.Core;

namespace unfrosted.Server
{
    internal class Server
    {
        private readonly TcpListener server;
        private readonly List<Connection> connections;

        public Server(int port) {
            server = new TcpListener(IPAddress.Any, port);
            connections = new List<Connection>();
        }

        public async Task WaitForConnectionsAsync() {
            await Task.Run(async () => {
                while (true) {
                    var client = await server.AcceptTcpClientAsync();
                    connections.Add(new Connection(client));
                }
            });
        }
    }
}
