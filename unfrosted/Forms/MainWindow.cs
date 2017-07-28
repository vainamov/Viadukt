using System.IO;
using System.Linq;
using System.Windows.Forms;
using Unfrosted.Core;
using Unfrosted.Networking;
using Unfrosted.Transfering;

namespace Unfrosted.Forms
{
    public partial class MainWindow : Form
    {
        public MainWindow() {
            InitializeComponent();

            TransferManager.Instance.Owner = this;

            this.Closing += OnClosing;

            foreach (ToolStripMenuItem item in mstMain.Items) {
                ((ToolStripDropDownMenu) item.DropDown).ShowImageMargin = false;
                item.Padding = new Padding(4);
            }
            mstMain.Renderer = new ToolStripProfessionalRenderer(new WhiteColorTable());

            tsmiReloadPool.Click += (sender, args) => {
                PoolService.Instance.Reload();
                lsbPoolMembers.Items.Clear();
                lsbPoolMembers.Items.AddRange(PoolService.Instance.Members.Select(m => (object) m).ToArray());
            };

            tsmiNewTransfer.Click += OnTsmiNewTransferClick;

            lsbPoolMembers.DoubleClick += OnLsbPoolMembersDoubleClick;

            button1.Click += OnClick;
        }

        private void OnClick(object sender, System.EventArgs e) {
            var info = new FileInfo(Path.Combine(Application.StartupPath, "send", "client.exe"));
            TransferManager.Instance.CreateNewTransfer(new Transfer {
                FilePath = info.FullName,
                FileName = info.Name,
                FileSizeBytes = info.Length,
                SenderAddress = "127.0.0.1",
                ReceiverAddress = "localhost"
            });
        }

        private void OnLsbPoolMembersDoubleClick(object sender, System.EventArgs e) {
            if (lsbPoolMembers.SelectedItem != null) {
                var dialog = new CreateTransferDialog();
                if (dialog.ShowDialog(lsbPoolMembers.SelectedItem.ToString(), 50043) == DialogResult.OK) {
                    var transfer = dialog.Transfer;
                }
            }
        }

        private void OnTsmiNewTransferClick(object sender, System.EventArgs e) {
            var dialog = new CreateTransferDialog();
            if (dialog.ShowDialog() == DialogResult.OK) {
                var transfer = dialog.Transfer;
            }
        }

        private void OnClosing(object sender, System.ComponentModel.CancelEventArgs e) {
        }

        public void AddTransfer(Transfer transfer) {
            var item = new ToolStripMenuItem("Establishing Connection...", null, (s, e) => transfer.Controller.ShowOverview());
            transfer.Controller.ToolStripItem = item;
            tsmiTransfers.DropDownItems.Add(item);
        }
    }
}
