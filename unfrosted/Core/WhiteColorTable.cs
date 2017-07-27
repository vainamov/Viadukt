using System.Drawing;
using System.Windows.Forms;

namespace unfrosted.Core
{
    internal class WhiteColorTable : ProfessionalColorTable
    {
        public override Color MenuStripGradientBegin => Color.White;
        public override Color MenuStripGradientEnd => Color.White;
    }
}
