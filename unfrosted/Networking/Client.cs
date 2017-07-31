using System;
using System.IO;
using System.Net.Sockets;
using Unfrosted.Core;
using Unfrosted.Transfering;

namespace Unfrosted.Networking
{
    public class Client : IDisposable
    {
        private TcpClient client;
        private TransferController controller;

        public Client(TransferController controller) {
            this.controller = controller;

            client = new TcpClient();
            try {
                client.Connect(controller.Transfer.ReceiverAddress, controller.Transfer.Port);

                this.controller.Transfer.Connection = new Connection(client);

                this.controller.Transfer.Connection.BinaryWriter.Write((byte) ProtocolCode.Transfer);
                this.controller.Transfer.Connection.BinaryWriter.Write(controller.Transfer.Id);
                this.controller.Transfer.Connection.BinaryWriter.Flush();
            } catch { }
        }

        public void SendData() {
            using (var stream = new FileStream(controller.Transfer.FilePath, FileMode.Open, FileAccess.Read)) {
                using (var reader = new BinaryReader(stream)) {
                    while (controller.BytesSent < controller.Transfer.FileSizeBytes) {
                        var buffer = reader.ReadBytes(1048576);
                        controller.BytesSent += buffer.Length;
                        controller.Transfer.Connection.BinaryWriter.Write((byte) ProtocolCode.Data);
                        controller.Transfer.Connection.BinaryWriter.Write(buffer);
                        controller.Transfer.Connection.BinaryWriter.Flush();
                        controller.ReportProgress();
                    }
                }
            }
            controller.Transfer.Connection.BinaryWriter.Write((byte) ProtocolCode.End);
            controller.Transfer.Connection.BinaryWriter.Flush();

            GC.Collect();
        }

        public void Dispose() {
            controller.Transfer.Connection.Dispose();
            client.Close();
            client.Dispose();
        }
    }
}
