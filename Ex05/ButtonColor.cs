using System.Windows.Forms;
using System.Drawing;

namespace Ex05
{
    public class ButtonColor : Button
    {
        protected Color m_Color;
        public ButtonColor()
        {
            Size = new Size(25, 25);
            Enabled = false;
        }

        public Color Color
        {
            get { return m_Color; ; }
            set
            {
                m_Color = value;
                BackColor = m_Color;
            }
        }
    }
}
