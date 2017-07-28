using System.Drawing;
using System.Windows.Forms;

namespace Unfrosted.Core
{
    public class WhiteColorTable : ProfessionalColorTable
    {
        public override Color MenuStripGradientBegin => Color.White;
        public override Color MenuStripGradientEnd => Color.White;
    }
}
