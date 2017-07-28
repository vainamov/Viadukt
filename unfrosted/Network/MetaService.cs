using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using Unfrosted.Core;
using Unfrosted.Transfering;

namespace Unfrosted.Network
{
    public class MetaService
    {
        private TcpListener listener;
        private TcpClient client;

        public static MetaService Instance = new MetaService();

        public void StartService(int port) {
            listener = new TcpListener(IPAddress.Any, port);
            listener.Start();

            new Thread(Listener).Start();
        }

        public void SendMeta(string host, int port, Transfer transfer) {
            client = new TcpClient();
            try {
                client.Connect(host, port);
            } catch {
                return;
            }

            using (var writer = new BinaryWriter(client.GetStream())) {
                writer.Write((byte) ProtocolCode.Meta);
                writer.Write(transfer.Id);
                writer.Write(transfer.SenderAddress);
                writer.Write(transfer.FileSizeBytes);
                writer.Write(transfer.FileName);

                writer.Flush();
            }

            client.Close();
        }

        public void SendMetaResult(string host, int port, Transfer transfer, bool accept) {
            client = new TcpClient();
            try {
                client.Connect(host, port);
            } catch {
                return;
            }

            using (var writer = new BinaryWriter(client.GetStream())) {
                writer.Write(accept ? (byte) ProtocolCode.Accept : (byte) ProtocolCode.Decline);
                writer.Write(transfer.Id);
                writer.Write(transfer.Port);

                writer.Flush();
            }

            client.Close();
        }

        private void Listener() {
            while (true) {
                try {
                    var acceptedClient = listener.AcceptTcpClient();

                    using (var reader = new BinaryReader(acceptedClient.GetStream())) {
                        try {
                            var code = (ProtocolCode) reader.ReadByte();

                            switch (code) {
                            case ProtocolCode.Meta:
                                var transfer = new Transfer(reader.ReadUInt32()) {
                                    SenderAddress = reader.ReadString(),
                                    FileSizeBytes = reader.ReadInt64(),
                                    FileName = reader.ReadString()
                                };

                                TransferManager.Instance.ShowTransferPrompt(transfer);
                                break;
                            case ProtocolCode.Accept:
                                reader.ReadUInt32();
                                MessageBox.Show(reader.ReadInt32().ToString());
                                break;
                            case ProtocolCode.Decline:

                                break;
                            }
                        } catch { }
                    }

                    acceptedClient.Close();
                    acceptedClient.Dispose();
                } catch {
                    return;
                }
            }
        }

        public void StopService() {
            try {
                client.Close();
            } catch { }
            try {
                listener.Stop();
            } catch { }
        }
    }
}
