using System.Drawing;

namespace Ex05
{
    public class GuessableColors
    {
        public enum eGuessableColors
        {
            PaleGreen = 1,
            PaleTurquoise,
            PaleVioletRed,
            PaleGoldenrod,
            LightPink,
            CornflowerBlue,
            MediumPurple,
            LightSalmon
        }

        public static Color MapEnumToColor(eGuessableColors i_Color)
        {
            Color colorToReturn = Color.Empty;
            switch (i_Color)
            {
                case eGuessableColors.PaleGreen:
                    colorToReturn = Color.PaleGreen;
                    break;
                case eGuessableColors.MediumPurple:
                    colorToReturn = Color.MediumPurple;
                    break;
                case eGuessableColors.LightSalmon:
                    colorToReturn = Color.LightSalmon;
                    break;
                case eGuessableColors.LightPink:
                    colorToReturn = Color.LightPink;
                    break;
                case eGuessableColors.CornflowerBlue:
                    colorToReturn = Color.CornflowerBlue;
                    break;
                case eGuessableColors.PaleVioletRed:
                    colorToReturn = Color.PaleVioletRed;
                    break;
                case eGuessableColors.PaleGoldenrod:
                    colorToReturn = Color.PaleGoldenrod;
                    break;
                case eGuessableColors.PaleTurquoise:
                    colorToReturn = Color.PaleTurquoise;
                    break;
            }

            return colorToReturn;
        }
    }
}
