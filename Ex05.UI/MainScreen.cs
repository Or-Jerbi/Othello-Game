namespace Ex05.UI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;

    public partial class MainScreen : Form
    {
        private int m_BoardSize = 6;

        public MainScreen()
        {
            InitializeComponent();
        }

        private void buttonBoardSize_Click(object sender, EventArgs e)
        {
            if (m_BoardSize < 12)
            {
                m_BoardSize += 2;
            }
            else
            {
                m_BoardSize = 6;
            }

            buttonBoardSize.Text = "Board Size: " + m_BoardSize + "x" + m_BoardSize + " (click to increase)";
        }

        private void buttonPlayWithComputer_Click(object sender, EventArgs e)
        {
            SetGame(true);
        }

        private void buttonPlayWithFriend_Click(object sender, EventArgs e)
        {
            SetGame(false);
        }

        private void SetGame(bool i_PlayWithComputer)
        {
            this.Hide();
            GameForm newGameForm = new GameForm(m_BoardSize);
            if (i_PlayWithComputer)
            {
                newGameForm.ChangeNameToComputer();
            }

            newGameForm.ShowDialog();
            this.Close();
        }
    }
}