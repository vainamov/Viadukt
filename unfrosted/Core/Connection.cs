using System.IO;
using System.Net.Sockets;

namespace unfrosted.Core
{
    internal class Connection
    {
        private readonly TcpClient client;
        private readonly NetworkStream stream;
        private readonly BinaryReader reader;
        private readonly BinaryWriter writer;

        public Connection(TcpClient client) {
            this.client = client;
            stream = client.GetStream();
            reader = new BinaryReader(stream);
            writer = new BinaryWriter(stream);
        }

        public void Write(byte[] buffer) {
            writer.Write(buffer);
        }

        public byte[] Read(int count) {
            return reader.ReadBytes(count);
        }
    }
}
