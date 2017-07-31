using System.Windows.Forms;

namespace Unfrosted.Forms
{
    public partial class ReceiveTransferDialog : Form
    {
        private int timeout = 10;

        public ReceiveTransferDialog() {
            InitializeComponent();

            tmrTimeout.Tick += OnTick;
        }

        public DialogResult ShowDialog(IWin32Window owner, string filename, string filesender) {
            lblFilename.Text = filename;
            lblSender.Text = $"{filesender}\nwants to share this file with you.";
            return base.ShowDialog(owner);
        }

        private void OnTick(object sender, System.EventArgs e) {
            btnNo.Text = $"No ({timeout--})";
            if (timeout == -1) {
                btnNo.PerformClick();
            }
        }
    }
}
