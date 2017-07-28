using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unfrosted.Core;

namespace Unfrosted.Network
{
    public class Server
    {
        private readonly TcpListener server;

        public Server(int port) {
            server = new TcpListener(IPAddress.Any, port);
            server.Start();
        }

        public async Task WaitForConnectionsAsync() {
            try {
                await Task.Run(async () => {
                    while (true) {
                        var client = await server.AcceptTcpClientAsync();
                        var transfer = new Transfering.Transfer();

                        transfer.Connection = new Connection(client);

                        var thread = new Thread(ListenToConnection);
                        thread.Start(transfer);
                    }
                });
            } catch { }
        }

        private void ListenToConnection(object o) {
            var transfer = (Transfering.Transfer) o;

            while (true) {
                try {
                    if (transfer?.Connection == null)
                        continue;

                    var code = transfer.Connection.ReadCode();

                    switch (code) {
                    case ProtocolCode.Meta:
                        var size = transfer.Connection.BinaryReader.ReadUInt64();
                        var filename = transfer.Connection.BinaryReader.ReadString();

                        MessageBox.Show($"{filename} ({size / 1024}KB)");

                        break;
                    case ProtocolCode.Transfer:
                        break;

                    }
                } catch {
                    return;
                }
            }
        }
    }
}
