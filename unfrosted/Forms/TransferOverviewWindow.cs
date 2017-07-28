using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Unfrosted.Forms
{
    public partial class TransferOverviewWindow : Form
    {
        public TransferOverviewWindow() {
            InitializeComponent();
        }

        public void SetProgress(float percentage) {
            Invoke(new Action(() => progressBar1.Value = (int) percentage));
        }
    }
}
