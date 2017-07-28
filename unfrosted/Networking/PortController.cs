using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Unfrosted.Transfering;

namespace Unfrosted.Networking
{
    public class PortController
    {
        public static PortController Instance { get; set; } = new PortController();

        public List<Server> Servers { get; } = new List<Server>();

        public void PrepareServers() {
            Servers.Clear();
            for (var i = Configuration.Instance.ServerArrayStartPort; i < Configuration.Instance.ServerArrayStartPort + Configuration.Instance.ServerArraySize; i++) {
                try {
                    var server = new Server(i) { Port = i };
                    Servers.Add(server);
                    //Task.Run(async () => await server.WaitForConnectionsAsync());
                    server.Thread = new Thread(() => server.WaitForConnections());
                    server.Thread.Start();
                } catch { }
            }
        }

        public void StopServers() {
            Servers.ForEach(s => s.Stop());
            Servers.ForEach(s => s.Thread.Abort());
        }

        public void AssignController(TransferController controller) {
            Servers.Find(s => s.Port == controller.Transfer.Port).Controllers.Add(controller);
        }

        public int GetBestPort() {
            return Servers.Find(s => s.Controllers.Count == Servers.Min(_ => _.Controllers.Count)).Port;
        }
    }
}
