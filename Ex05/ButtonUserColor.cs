namespace Ex05
{
    public class ButtonUserColor : ButtonColor
    {
        private bool m_ColorWasChanged = false;
        private FormPickColors m_FormPickColor = new FormPickColors();
        public ButtonUserColor() : base()
        {
        }

        public bool ColorWasChanged
        {
            get { return m_ColorWasChanged; }
        }
       
        public void ChangeButtonColor()
        {
            m_FormPickColor.ShowDialog();
            Color = m_FormPickColor.ChosenColor;
            m_ColorWasChanged = true;
        }
    }
}
