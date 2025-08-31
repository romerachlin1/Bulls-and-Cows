using System.Windows.Forms;
using System.Drawing;

namespace Ex05
{
    public class ButtonSubmitGuess : Button
    {
        public ButtonSubmitGuess()
        {
            Text = "->";
            Size = new Size(25, 25);
            Enabled = false;
        }
    }
}
