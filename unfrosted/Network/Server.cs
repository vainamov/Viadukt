using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unfrosted.Core;
using Unfrosted.Transfering;

namespace Unfrosted.Network
{
    public class Server
    {
        private readonly TcpListener server;

        public List<TransferController> Controllers { get; } = new List<TransferController>();
        public int Port { get; set; }
        public Thread Thread { get; set; }
        private List<Thread> transferThreads = new List<Thread>();

        private bool stop;

        public Server(int port) {
            server = new TcpListener(IPAddress.Any, port);
            server.Start();
        }

        //public async Task WaitForConnectionsAsync() {
        //    try {
        //        while (true) {
        //            var client = await server.AcceptTcpClientAsync();
        //            var connection = new Connection(client);

        //            if (connection.BinaryReader.ReadByte() == (byte) ProtocolCode.Transfer) {
        //                var id = connection.BinaryReader.ReadUInt32();

        //                var controller = Controllers.Find(c => c.Transfer.Id == id);
        //                if (controller != null) {
        //                    controller.Transfer.FilePath = Path.Combine(Application.StartupPath, "receive", "client.exe");
        //                    controller.Transfer.Connection = connection;
        //                    var thread = new Thread(ListenToConnection);
        //                    thread.Start(controller);
        //                }
        //            }
        //        }
        //    } catch { }
        //}

        public void Stop() {
            stop = true;
            transferThreads.ForEach(t => {
                try {
                    t.Abort();
                } catch { }
            });
        }

        public void WaitForConnections() {
            Debug.Print(Port + " running");
            try {
                while (!stop) {
                    var client = server.AcceptTcpClient();
                    var connection = new Connection(client);

                    if (connection.BinaryReader.ReadByte() == (byte) ProtocolCode.Transfer) {
                        var id = connection.BinaryReader.ReadUInt32();

                        var controller = Controllers.Find(c => c.Transfer.Id == id);
                        if (controller != null) {
                            controller.Transfer.FilePath = Path.Combine(Application.StartupPath, "receive", "client.exe");
                            controller.Transfer.Connection = connection;
                            var thread = new Thread(ListenToConnection);
                            transferThreads.Add(thread);
                            thread.Start(controller);
                        }
                    }
                }
            } catch { }
        }

        private void ListenToConnection(object o) {
            var controller = (TransferController) o;
            var stream = new FileStream(controller.Transfer.FilePath, FileMode.Create, FileAccess.Write);
            var writer = new BinaryWriter(stream);

            while (!stop) {
                try {
                    if (controller.Transfer.Connection == null)
                        continue;

                    var code = (ProtocolCode) controller.Transfer.Connection.BinaryReader.ReadByte();
                    if (code == ProtocolCode.End) {
                        break;
                    }

                    var buffer = controller.Transfer.Connection.BinaryReader.ReadBytes(1048576);
                    writer.Write(buffer);
                    writer.Flush();
                    controller.BytesSent += buffer.Length;

                } catch {
                    break;
                }
            }

            writer.Flush();
            Controllers.Remove(controller);
            writer.Close();
            writer.Dispose();
            stream.Close();
            stream.Dispose();

            Thread.CurrentThread.Abort();
        }
    }
}
