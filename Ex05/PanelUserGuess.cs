using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Ex05
{
    public class PanelUserGuess : Panel
    {
        private readonly List<ButtonUserColor> r_ButtonsUserColor = new List<ButtonUserColor>();
        private readonly List<ButtonBullPgiyaMarker> r_ButtonsBullPgiyaMarker = new List<ButtonBullPgiyaMarker>();
        private ButtonSubmitGuess m_ButtonSubmitGuess = new ButtonSubmitGuess();

        public PanelUserGuess()
        {
            initButtonsUserColor();
            initButtonSubmitGuess();
            initButtonsBullPgiyaMarker();
            Size = new Size(calcPanelWidth() , 25);
        }

        public ButtonSubmitGuess ButtonSubmitGuess
        {
            get { return m_ButtonSubmitGuess; }
        }

        public List<ButtonUserColor> ButtonsUserColor
        {
            get { return r_ButtonsUserColor; }
        }

        private int calcPanelWidth()
        {
            return r_ButtonsBullPgiyaMarker[1].Right - r_ButtonsUserColor[0].Left;
        }

        private void initButtonsUserColor()
        {
            for (int i = 0; i < 4; i++)
            {
                ButtonUserColor colorButton = new ButtonUserColor();
                colorButton.Location = new Point(i * (colorButton.Width + 5));
                colorButton.Click += ColorButton_Click;
                r_ButtonsUserColor.Add(colorButton);
                Controls.Add(colorButton);
            }
        }

        private void ColorButton_Click(object sender, System.EventArgs e)
        {
            (sender as ButtonUserColor).ChangeButtonColor();
            updateSubmitButtonState();
        }

        private bool hasUserSelectedAllColors()
        {
            bool hasUserSelectedAllColors = true;
            foreach (ButtonUserColor buttonUserColor in r_ButtonsUserColor)
            {
                if (!buttonUserColor.ColorWasChanged)
                {
                    hasUserSelectedAllColors = false;
                }
            }

            return hasUserSelectedAllColors;
        }

        private bool areAllColorsUnique()
        {
            bool areAllColorsUnique = true;
            for (int i = 0; i < r_ButtonsUserColor.Count; i++)
            {
                for (int j = 0; j < r_ButtonsUserColor.Count; j++)
                {
                    if (i!= j)
                    {
                        if (r_ButtonsUserColor[i].Color == r_ButtonsUserColor[j].Color)
                        {
                            areAllColorsUnique = false;
                        }
                    }
                }
            }

            return areAllColorsUnique;
        }

        private void updateSubmitButtonState()
        {
            if (hasUserSelectedAllColors() && areAllColorsUnique())
            {
                m_ButtonSubmitGuess.Enabled = true;
            }
            else
            {
                m_ButtonSubmitGuess.Enabled= false;
            }
        }

        private void initButtonSubmitGuess()
        {
            m_ButtonSubmitGuess.Location = new Point(r_ButtonsUserColor[3].Right + 10, r_ButtonsUserColor[3].Top);
            Controls.Add(m_ButtonSubmitGuess);
        }

        private void initButtonsBullPgiyaMarker()
        {
            for (int j = 0; j < 2; j++)
            {
                for (int i = 0; i < 2; i++)
                {
                    ButtonBullPgiyaMarker ButtonsBullPgiyaMarker = new ButtonBullPgiyaMarker();
                    ButtonsBullPgiyaMarker.Location = new Point(i * (ButtonsBullPgiyaMarker.Width + 5) + m_ButtonSubmitGuess.Right + 10 , j * (ButtonsBullPgiyaMarker.Height + 5));
                    r_ButtonsBullPgiyaMarker.Add(ButtonsBullPgiyaMarker);
                    Controls.Add(ButtonsBullPgiyaMarker);
                }
            }
        }

        public void ToggleButtonsUserColor()
        {
            foreach (Button button in r_ButtonsUserColor)
            {
                button.Enabled = !button.Enabled;
            }
        }

        public void UpdateBullPgiyaMarkers(int i_BullCount, int i_PgiyaCount)
        {
            for (int i = 0; i < i_BullCount; i++)
            {
                r_ButtonsBullPgiyaMarker[i].ChangeColorToBull();
            }

            for (int i = i_BullCount; i < i_BullCount + i_PgiyaCount; i++)
            {
                r_ButtonsBullPgiyaMarker[i].ChangeColorToPgiya();
            }
        }
    }
}
