using System.IO;
using System.Net.Sockets;

namespace Unfrosted.Core
{
    public class Connection
    {
        private readonly NetworkStream stream;
        public BinaryReader BinaryReader { get; }
        public BinaryWriter BinaryWriter { get; }

        public Connection(TcpClient client) {
            stream = client.GetStream();
            BinaryReader = new BinaryReader(stream);
            BinaryWriter = new BinaryWriter(stream);
        }

        public void Dispose() {
            BinaryReader.Close();
            BinaryReader.Dispose();
            BinaryWriter.Close();
            BinaryWriter.Dispose();
            stream.Close();
            stream.Dispose();
        }
    }
}
