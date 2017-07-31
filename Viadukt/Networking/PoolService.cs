using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading;

namespace Unfrosted.Networking
{
    public class PoolService
    {
        private TcpListener listener;
        private TcpClient client;

        public List<string> Members { get; } = new List<string>();

        public static PoolService Instance = new PoolService();

        public void StartService(int port) {
            listener = new TcpListener(IPAddress.Any, port);
            listener.Start();

            new Thread(Listener).Start();
        }

        public void Reload() {
            Members.Clear();
            foreach (var ni in NetworkInterface.GetAllNetworkInterfaces()) {
                foreach (var info in ni.GetIPProperties().UnicastAddresses) {
                    if (!info.IsDnsEligible && info.Address.AddressFamily == AddressFamily.InterNetwork) {
                        if (CheckHost(info.Address.ToString(), 42042)) {
                            Members.Add(info.Address.ToString());
                        }
                    }
                }
            }
        }

        public bool CheckHost(string host, int port) {
            client = new TcpClient();
            try {
                client.Connect(host, port);
            } catch {
                return false;
            }

            using (var writer = new BinaryWriter(client.GetStream())) {
                writer.Write("unfrosted");
                writer.Flush();
                using (var reader = new BinaryReader(client.GetStream())) {
                    try {
                        return reader.ReadString() == "unfrosted";
                    } catch {
                        return false;
                    } finally {
                        client.Close();
                    }
                }
            }
        }

        private void Listener() {
            while (true) {
                try {
                    var acceptedClient = listener.AcceptTcpClient();

                    using (var reader = new BinaryReader(acceptedClient.GetStream())) {
                        try {
                            if (reader.ReadString() == "unfrosted") {
                                using (var writer = new BinaryWriter(acceptedClient.GetStream())) {
                                    writer.Write("unfrosted");
                                    writer.Flush();
                                }
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
