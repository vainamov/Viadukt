using System.Net.Sockets;
using System.Threading.Tasks;

namespace unfrosted.Client
{
    internal class Client
    {private readonly TcpClient client;

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
        
    }
}
