using Unfrosted.Core;

namespace Unfrosted.Transfering
{
    public class Transfer
    {
        private static uint NextId = 1;
        
        public string FilePath { get; set; }
        public long FileSizeBytes { get; set; }
        public string FileName { get; set; }
        public uint Id { get; }
        public Connection Connection { get; set; }
        public string SenderName { get; set; }
        public string SenderAddress { get; set; }
        public string ReceiverAddress { get; set; }
        public int Port { get; set; }
        public TransferController Controller { get; set; }

        public Transfer() {
            Id = NextId++;
        }

        public Transfer(uint id) {
            Id = id;
        }
    }
}
