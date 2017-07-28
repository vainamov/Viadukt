using System.Threading;
using System.Windows.Forms;
using Unfrosted.Network;

namespace Unfrosted.Transfering
{
    public class TransferController
    {
        public Transfer Transfer { get; }
        public ToolStripMenuItem ToolStripItem { get; set; }

        public float Percentage => Transfer?.FileSizeBytes / 100 * BytesSent ?? 0;

        public long BytesSent { get; set; }

        public TransferController(Transfer transfer) {
            Transfer = transfer;
        }

        public void StartTransfer() {
            new Thread(RunTransfer).Start();
        }

        private void RunTransfer() {
            using (var client = new Client(this)) {
                client.SendData();
                client.Dispose();
            }
        }

        public void ShowOverview() {
            ToolStripItem.Text = $"{Percentage}% ({BytesSent / 1024}/{Transfer.FileSizeBytes / 1024}KB) - {Transfer.FileName} > {Transfer.ReceiverAddress} [:{Transfer.Port}]";
        }
    }
}
