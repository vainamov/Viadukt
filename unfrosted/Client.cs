using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using unfrosted.Core;

namespace unfrosted
{
    internal class Client
    {
        private readonly TcpClient client;

        public Client() {
            client = new TcpClient();
        }

        public async Task<bool> ConnectAsync(string host, int port) {
            try {
                await client.ConnectAsync(host, port);
            } catch {
                return false;
            }

            return true;
        }

        public bool StartTransfer(Transfer transfer) {
            transfer.Connection = new Connection(client);
            var thread = new Thread(ListenToConnection);
            thread.Start(transfer.Connection);

            transfer.Connection.WriteCode(ProtocolCode.Meta);
            transfer.Connection.BinaryWriter.Write((ulong)transfer.FileInfo.Length);
            transfer.Connection.BinaryWriter.Write(transfer.FileInfo.Name);
            transfer.Connection.BinaryWriter.Flush();

            return true;
        }

        private void ListenToConnection(object o) {
            var connection = (Connection) o;

            // Connected

            while (true) {
                try {
                    var code = connection.ReadCode();

                    switch (code) {
                    case ProtocolCode.Accept:

                        break;
                    case ProtocolCode.Decline:
                        break;

                    }
                } catch { }
            }
        }
    }
}