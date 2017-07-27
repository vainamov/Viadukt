using System.IO;

namespace unfrosted.Core
{
    internal class Transfer
    {
        public FileInfo FileInfo { get; set; }
        public Connection Connection { get; set; }
        public string SenderAddress { get; set; }
        public string ReceiverAddress { get; set; }
        public int Port { get; set; }
    }
}
