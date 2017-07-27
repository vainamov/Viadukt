using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using unfrosted.Core;

namespace unfrosted
{
    internal class Server
    {
        private readonly TcpListener server;
        private readonly List<Transfer> transfers;

        public Server(int port) {
            server = new TcpListener(IPAddress.Any, port);
            server.Start();
            transfers = new List<Transfer>();
        }

        public async Task WaitForConnectionsAsync() {
            try {
                await Task.Run(async () => {
                    while (true) {
                        var client = await server.AcceptTcpClientAsync();
                        var transfer = new Transfer();

                        transfer.Connection = new Connection(client);

                        transfers.Add(transfer);
                        var thread = new Thread(ListenToConnection);
                        thread.Start(transfer);
                    }
                });
            } catch { }
        }

        private void ListenToConnection(object o) {
            var transfer = (Transfer) o;

            MessageBox.Show("Connected");

            while (true) {
                //try {
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
                //} catch { }
            }
        }
    }
}
