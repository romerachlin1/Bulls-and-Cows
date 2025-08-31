using System.Collections.Generic;
using System.Drawing;
namespace Ex05
{
    public class GuessValidation
    {
        private int m_Bull = 0;
        private int m_Pgiya = 0;
        private readonly List<Color> r_ComputerColors = new List<Color>();
        private readonly List<Color> r_UserGuess = new List<Color>();
        private bool m_DidPlayerWin = false;

        public int Bull
        {
            get { return m_Bull; }
        }

        public int Pgiya
        {
            get { return m_Pgiya; }
        }

        public bool DidPlayerWin
        {
            get { return m_DidPlayerWin; }
        }

        public GuessValidation(List<Color> i_UserGuess, List<Color> i_ComputerColors)
        {
            r_UserGuess = i_UserGuess;
            r_ComputerColors = i_ComputerColors;
            compareUserGuessToComputer();
            CheckPlayerWon();
        }

        public void compareUserGuessToComputer()
        {
            for (int i = 0; i < r_UserGuess.Count; i++)
            {
                if (r_UserGuess[i] == r_ComputerColors[i])
                {
                    m_Bull++;
                }

                for (int j = 0; j < r_UserGuess.Count; j++)
                {
                    if (j != i)
                    {
                        if (r_UserGuess[i] == r_ComputerColors[j])
                        {
                            m_Pgiya++;
                        }
                    }
                }
            }
        }

        public void CheckPlayerWon()
        {
            if (m_Bull == 4)
            {
                m_DidPlayerWin = true;
            }
        }
    }
}
