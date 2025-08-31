using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Ex05
{
    public class FormPickColors : Form
    {
        private readonly List<ButtonColor> r_ColorOptions = new List<ButtonColor>();
        private Color m_ChosenColor;

        public FormPickColors()
        {
            Text = "Pick A Color:";
            Size = new Size(150, 120);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            StartPosition = FormStartPosition.CenterScreen;
            MaximizeBox = false;
            MinimizeBox = false;
        }

        public Color ChosenColor
        {
            get { return m_ChosenColor; }
        }

        private void initComponent()
        {
            for (int j = 0; j < 2; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    ButtonColor colorButton = new ButtonColor();
                    colorButton.Enabled = true;
                    colorButton.Location = new Point(i * (colorButton.Width + 5) + 10, 10 + j * (colorButton.Height + 5));
                    colorButton.Color = GuessableColors.MapEnumToColor((GuessableColors.eGuessableColors)(i + 1 + j * 4));
                    colorButton.BackColor = colorButton.Color;
                    colorButton.Click += m_ButtonColorClick;
                    r_ColorOptions.Add(colorButton);
                    Controls.Add(colorButton);
                }
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            initComponent();
        }

        private void m_ButtonColorClick(object sender, EventArgs e)
        {
            m_ChosenColor = (sender as ButtonColor).Color;
            Close();
        }
    }
}
