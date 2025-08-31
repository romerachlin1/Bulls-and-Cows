using System;
using System.Collections.Generic;
using System.Drawing;

namespace Ex05
{
    public class GameLogic
    {
        private readonly List<Color> r_ComputerColors = new List<Color>();
        private static readonly Random sr_random = new Random();
        private int m_CurrentTurnNumber = 0;
        private readonly int r_NumOfGuesses;

        public GameLogic(int i_NumOfGuesses)
        {
            generateComputerColors();
            r_NumOfGuesses = i_NumOfGuesses;
        }

        public int CurrentTurnNumber
        {
            get { return m_CurrentTurnNumber; }
        }

        public Color GetColorFromList(int i_IndexToRetrieve)
        {
            return r_ComputerColors[i_IndexToRetrieve];
        }

        private GuessValidation attemptGuess(List<Color> i_UserColorGuess)
        {
            GuessValidation guessValidation = new GuessValidation(i_UserColorGuess, r_ComputerColors);

            return guessValidation;
        }
        private void generateComputerColors()
        {
            while (r_ComputerColors.Count < 4)
            {
                Color currentColor = GuessableColors.MapEnumToColor((GuessableColors.eGuessableColors)sr_random.Next(1, 9));
                if (!r_ComputerColors.Contains(currentColor))
                {
                    r_ComputerColors.Add(currentColor);
                }
            }
        }

        public GuessValidation ProcessGuess(List<Color> i_UserColorGuess)
        {
            GuessValidation currentGuess = attemptGuess(i_UserColorGuess);

            return currentGuess;
        }

        public bool ShouldContinueGame(bool i_PlayerWon)
        {
            m_CurrentTurnNumber++;

            return m_CurrentTurnNumber < r_NumOfGuesses && !i_PlayerWon;
        }
    }
}
