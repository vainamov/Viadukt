using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
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

            foreach (ToolStripMenuItem item in mstMain.Items) {
                ((ToolStripDropDownMenu) item.DropDown).ShowImageMargin = false;
                item.Padding = new Padding(4);
            }
            mstMain.Renderer = new ToolStripProfessionalRenderer(new WhiteColorTable());

            tsmiReloadPool.Click += OnReloadPoolClick;
            tsmiConnectionDetails.Click += (sender, e) => MessageBox.Show(Dns.GetHostEntry(Dns.GetHostName()).AddressList.ToList().Find(ip => ip.AddressFamily == AddressFamily.InterNetwork).ToString());

            button1.Click += OnClick;
        }

        private void OnReloadPoolClick(object sender, System.EventArgs e) {
            PoolService.Instance.Reload();
            lsbPoolMembers.Items.Clear();
            lsbPoolMembers.Items.AddRange(PoolService.Instance.Members.Select(m => (object) m).ToArray());
        }

        private void OnClick(object sender, System.EventArgs e) {
            var info = new FileInfo(Path.Combine(Application.StartupPath, "send", "data.rar"));
            TransferManager.Instance.CreateNewTransfer(new Transfer {
                FilePath = info.FullName,
                FileName = info.Name,
                FileSizeBytes = info.Length,
                SenderAddress = "127.0.0.1",
                ReceiverAddress = "localhost"
            });
        }

        public void AddTransfer(Transfer transfer) {
            var item = new ToolStripMenuItem("Establishing Connection...", null, (s, e) => transfer.Controller.ShowOverview());
            transfer.Controller.ToolStripItem = item;
            tsmiTransfers.DropDownItems.Add(item);
        }
    }
}
