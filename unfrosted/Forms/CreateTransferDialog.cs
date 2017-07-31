using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Unfrosted.Forms
{
    public partial class CreateTransferDialog : Form
    {
        public Transfering.Transfer Transfer { get; }

        public CreateTransferDialog() {
            InitializeComponent();

            Transfer = new Transfering.Transfer();

            tbxAddress.TextChanged += OnTextChanged;
            tbxPort.TextChanged += OnTextChanged;
            lblFile.DragEnter += OnDragEnter;
            lblFile.DragDrop += OnDragDrop;
        }

        private void OnDragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetFormats().Contains("FileName") && ((string[]) e.Data.GetData("FileDrop")).Length == 1) {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void OnDragDrop(object sender, DragEventArgs e) {
            var fileName = ((string[]) e.Data.GetData("FileDrop"))[0];
            var info = new FileInfo(fileName);

            Transfer.FileName = info.Name;
            Transfer.FilePath = info.FullName;
            Transfer.FileSizeBytes = info.Length;

            lblFile.Text = $"{Transfer.FileName} ({Transfer.FileSizeBytes / 1024}KB)";

            SetButtonEnabled();
        }

        private void OnTextChanged(object sender, System.EventArgs e) {
            if (sender == tbxAddress) {
                Transfer.ReceiverAddress = tbxAddress.Text;
            } else {
                Transfer.Port = int.TryParse(tbxPort.Text, out var port) ? port : 0;
            }

            SetButtonEnabled();
        }

        public void SetButtonEnabled() {
            btnCreate.Enabled = !string.IsNullOrEmpty(Transfer.FilePath) && !string.IsNullOrEmpty(Transfer.ReceiverAddress) && Transfer.Port != 0;
        }

        public DialogResult ShowDialog(string host, int port) {
            tbxAddress.Text = host;
            tbxPort.Text = port.ToString();

            Transfer.ReceiverAddress = host;
            Transfer.Port = port;

            return ShowDialog();
        }
    }
}
