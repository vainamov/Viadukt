using System.IO;
using System.Windows.Forms;
using unfrosted.Core;

namespace unfrosted
{
    public partial class MainWindow : Form
    {
        public MainWindow() {
            InitializeComponent();

            foreach (ToolStripMenuItem item in mstMain.Items) {
                ((ToolStripDropDownMenu) item.DropDown).ShowImageMargin = false;
                item.Padding = new Padding(4);
            }
            mstMain.Renderer = new ToolStripProfessionalRenderer(new WhiteColorTable());

            for (var i = 50000; i < 50020; i++) {
                tsmiTransfers.DropDownItems.Add($"42% - defectively-min.zip (10.0.115.3) [:{i}]");
            }

            var client = new Client();

            var transfer = new Transfer {
                ReceiverAddress = "localhost",
                Port = 50000,
                FileInfo = new FileInfo(Path.Combine(Application.StartupPath, "Newtonsoft.Json.dll"))
            };

            button1.Click += async (s1, e1) => await new Server(50000).WaitForConnectionsAsync();
            button2.Click += async (s2, e2) => await client.ConnectAsync(transfer.ReceiverAddress, transfer.Port);
            button3.Click += (s3, e3) => client.StartTransfer(transfer);
        }
    }
}
