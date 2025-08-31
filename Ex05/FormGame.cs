using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Ex05
{
    public class FormGame : Form
    {
        private readonly int r_NumOfGuesses;
        private readonly List<ButtonComputerColor> r_ComputerColorButtons = new List<ButtonComputerColor>();
        private readonly List<PanelUserGuess> r_PanelUserGuess = new List<PanelUserGuess>();
        private GameLogic m_GameLogic;
        public FormGame(int i_NumOfGuesses)
        {
            r_NumOfGuesses = i_NumOfGuesses;
            Text = "Bull Pgiya";
            Size = new Size(230, calculateFormHeight());
            FormBorderStyle = FormBorderStyle.Fixed3D;
            StartPosition = FormStartPosition.CenterScreen;
            MaximizeBox = false;
            m_GameLogic = new GameLogic(i_NumOfGuesses);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            initButtonsComputerColor();
            initPanelsUserGuess();
            r_PanelUserGuess[0].ToggleButtonsUserColor();
        }
        private int calculateFormHeight()
        {
            int computerColorButtonsHeight = 25 + 10;
            int panelsHeight = r_NumOfGuesses * (25 + 5);
            int additionalSpacing = 20;
            int formPadding = 40;

            return computerColorButtonsHeight + panelsHeight + additionalSpacing + formPadding;
        }

        private void initButtonsComputerColor()
        {
            for (int i = 0; i < 4; i++)
            {
                ButtonComputerColor colorButton = new ButtonComputerColor(m_GameLogic.GetColorFromList(i));
                colorButton.Location = new Point(i * (colorButton.Width + 5) + 10, 10);
                r_ComputerColorButtons.Add(colorButton);
                Controls.Add(colorButton);
            }
        }

        private void initPanelsUserGuess()
        {
            for (int i = 0; i < r_NumOfGuesses; i++)
            {
                PanelUserGuess panelUserGuess = new PanelUserGuess();
                panelUserGuess.Location = new Point(r_ComputerColorButtons[0].Left, i * (panelUserGuess.Height + 5) + 20 + r_ComputerColorButtons[0].Height);
                panelUserGuess.ButtonSubmitGuess.Click += ButtonSubmitGuess_Click;
                r_PanelUserGuess.Add(panelUserGuess);
                Controls.Add(panelUserGuess);
            }
        }

        private void ButtonSubmitGuess_Click(object sender, EventArgs e)
        {
            (sender as ButtonSubmitGuess).Enabled = false;
            updateUIAfterGuess();
        }

        private void updateUIAfterGuess()
        {
            List<Color> userGuessColors = new List<Color>();

            for (int i = 0; i < 4; i++)
            {
                userGuessColors.Add(r_PanelUserGuess[m_GameLogic.CurrentTurnNumber].ButtonsUserColor[i].Color);
            }

            GuessValidation currentGuess = m_GameLogic.ProcessGuess(userGuessColors);
            r_PanelUserGuess[m_GameLogic.CurrentTurnNumber].ToggleButtonsUserColor();
            r_PanelUserGuess[m_GameLogic.CurrentTurnNumber].UpdateBullPgiyaMarkers(currentGuess.Bull, currentGuess.Pgiya);
            updateGameStateAfterGuess(currentGuess.DidPlayerWin);
        }
        private void updateGameStateAfterGuess(bool i_PlayerWon)
        {
            bool gameContinues = m_GameLogic.ShouldContinueGame(i_PlayerWon);

            if (gameContinues)
            {
                r_PanelUserGuess[m_GameLogic.CurrentTurnNumber].ToggleButtonsUserColor();
            }
            else
            {
                showComputerColors();
            }
        }

        private void showComputerColors()
        {
            foreach (ButtonComputerColor computerColorButton in r_ComputerColorButtons)
            {
                computerColorButton.ShowChosenColor();
            }
        }
    }
}
