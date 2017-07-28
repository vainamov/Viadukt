using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Unfrosted.Forms;
using Unfrosted.Networking;

namespace Unfrosted.Transfering
{
    public class TransferController
    {
        public Transfer Transfer { get; }
        public ToolStripMenuItem ToolStripItem { get; set; }
        public TransferOverviewWindow Overview { get; set; } = new TransferOverviewWindow();

        public float Percentage => 100F / Transfer.FileSizeBytes * BytesSent;

        public long BytesSent { get; set; }

        public TransferController(Transfer transfer) {
            Transfer = transfer;
        }

        public void StartTransfer() {
            ShowOverview();
            new Thread(RunTransfer).Start();
        }

        private void RunTransfer() {
            using (var client = new Client(this)) {
                client.SendData();
                client.Dispose();
            }
        }

        public void ReportProgress() {
            Overview.SetProgress(Percentage);
        }

        public void ShowOverview() {
            Application.OpenForms.OfType<MainWindow>().ElementAt(0).Invoke(new Action(() => Overview.Show()));

            // ToolStripItem.Text = $"{Percentage}% ({Helper.GetSizeString(BytesSent)}/{Helper.GetSizeString(Transfer.FileSizeBytes)}) - {Transfer.FileName} > {Transfer.ReceiverAddress} [:{Transfer.Port}]";
        }
    }
}
