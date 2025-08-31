using System.Drawing;

namespace Ex05
{
    public class ButtonComputerColor : ButtonColor
    {
        public ButtonComputerColor(Color i_Color) : base()
        {
            m_Color = i_Color;
            BackColor = Color.Black;
        }

        public void ShowChosenColor()
        {
            BackColor = m_Color;
        }
    }
}
