using System;
using System.Windows.Forms;
using System.Drawing;

namespace Ex05
{
    public class FormInit : Form
    {
        private Button m_ButtonStart = new Button();
        private Button m_ButtonNumOfChances = new Button();
        private int m_CurNumChances = 4;

        public FormInit()
        {
            Text = "Bull Pgiya";
            Size = new Size(250, 150);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            StartPosition = FormStartPosition.CenterScreen;
            MaximizeBox = false;
        }

        private void initComponent()
        {           
            m_ButtonNumOfChances.Text = $"Number Of Chances: {m_CurNumChances}";
            m_ButtonNumOfChances.Location = new Point(10, 10);
            m_ButtonNumOfChances.Size = new Size(ClientSize.Width - 2 * m_ButtonNumOfChances.Left, 25);
            Controls.Add ( m_ButtonNumOfChances );
            m_ButtonStart.Text = "Start";
            m_ButtonStart.Location = new Point(m_ButtonNumOfChances.Right - m_ButtonStart.Width, ClientSize.Height - m_ButtonStart.Height - 10);
            Controls.Add(m_ButtonStart);
            m_ButtonStart.Click += m_ButtonStart_Click;
            m_ButtonNumOfChances.Click += m_ButtonNumOfChances_Click;
        }

        private void m_ButtonNumOfChances_Click(object sender, EventArgs e)
        {
            m_CurNumChances++;
            if (m_CurNumChances == 11)
            {
                m_CurNumChances = 4;
            }

            m_ButtonNumOfChances.Text = $"Number Of Chances: {m_CurNumChances}";
        }

        private void m_ButtonStart_Click(object sender, EventArgs e)
        {
            Hide();
            FormGame gameForm = new FormGame(m_CurNumChances);
            gameForm.ShowDialog();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            initComponent();
        }
    }
}
