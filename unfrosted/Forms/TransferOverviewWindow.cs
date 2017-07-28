using System.Windows.Forms;
using Unfrosted.Transfering;

namespace Unfrosted.Forms
{
    public partial class TransferOverviewWindow : Form
    {
        public TransferOverviewWindow() {
            InitializeComponent();
        }

        public void SetProgress(TransferController controller) {
            Text = $"{(int) controller.Percentage}% - Status";
            lblPercentage.Text = controller.Percentage.ToString("N") + "%";
            pgbProgress.Value = (int) controller.Percentage;
            lblBytes.Text = $"{Helper.GetSizeString(controller.BytesSent)}/{Helper.GetSizeString(controller.Transfer.FileSizeBytes)}";
        }
    }
}
