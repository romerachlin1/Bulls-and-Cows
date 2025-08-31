using System.Drawing;
using System.Windows.Forms;

namespace Ex05
{
    public class ButtonBullPgiyaMarker : Button
    {
        public ButtonBullPgiyaMarker()
        {
            Size = new Size(10, 10);
            Enabled = false;
        }

        public void ChangeColorToBull()
        {
            BackColor = Color.Black;
        }

        public void ChangeColorToPgiya()
        {
            BackColor = Color.Yellow;
        }
    }
}
