namespace Ex05.UI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using Ex02_Othello;

    public partial class GameForm : Form
    {
        private Game m_OthelloGame;
        private readonly int r_BoardSize;
        private Player m_Player1;
        private Player m_Player2;
        private Player m_CurrentPlayer;
        private Square[,] m_Board;
        private int m_Left = 20;
        private int m_Top = 20;
        //private int m_Col;
        //private int m_Row;

        public GameForm(int i_BoardSize)
        {
            InitializeComponent();
            r_BoardSize = i_BoardSize;
            m_Board = new Square[r_BoardSize, r_BoardSize];
            SetSize();
            m_Player1 = new Player("Black", 'X');
            m_Player2 = new Player("White", 'O');
            StartGame();
        }

        public GameForm(int i_BoardSize, Player i_Player1, Player i_Player2)
        {
            InitializeComponent();
            r_BoardSize = i_BoardSize;
            m_Board = new Square[r_BoardSize, r_BoardSize];
            SetSize();
            m_Player1 = i_Player1;
            m_Player2 = i_Player2;
            StartGame();
        }

        public void StartGame()
        {
            m_OthelloGame = new Game(r_BoardSize, m_Player1, m_Player2);
            BuildBoard();
            m_CurrentPlayer = m_Player1;
            PlayerTurn();
        }

        public void ChangeNameToComputer()
        {
            m_Player2.PlayerName = "Computer";
        }

        public void SwitchPlayers()
        {
            if (m_CurrentPlayer.PlayerName == m_Player1.PlayerName)
            {
                m_CurrentPlayer = m_Player2;
            }
            else
            {
                m_CurrentPlayer = m_Player1;
            }
        }

        public void SetSize()
        {
            Height = 40 + (r_BoardSize * 50) + (r_BoardSize * 10);
            Width = 50 + (r_BoardSize * 50) + (r_BoardSize * 5);
        }

        public void ComputerMove()
        {
            Timer computerSleep = new Timer();
            m_OthelloGame.ComputerMove();
            computerSleep.Interval = 10000;
            SwitchPlayers();
            PlayerTurn();
        }

        public void PlayerTurn()
        {
            if (m_OthelloGame.CheckFreeSpaces(m_Player1) || m_OthelloGame.CheckFreeSpaces(m_Player2))
            {
                if (CheckFreeSpaces(m_CurrentPlayer))
                {
                    this.Text = "Othello - " + m_CurrentPlayer.PlayerName + "'s Turn";
                    if (m_CurrentPlayer.PlayerName == "Computer")
                    {
                        ComputerMove();
                    }
                }
                else
                {
                    SwitchPlayers();
                    PlayerTurn();
                }
            }
            else
            {
                GameOver();
            }
        }

        public Square CreateSquare(int i_Row, int i_Col)
        {
            Square square = new Square();
            square.Height = 50;
            square.Width = 50;
            square.Col = i_Col;
            square.Row = i_Row;
            square.Left = m_Left;
            square.Top = m_Top;

            return square;
        }

        public void BuildBoard()
        {
            for (int i = 0; i < r_BoardSize; i++)
            {
                for (int j = 0; j < r_BoardSize; j++)
                {
                    m_Board[i, j] = CreateSquare(i, j);
                    this.Controls.Add(m_Board[i, j]);
                    m_Board[i, j].Enabled = false;
                    m_Board[i, j].BackColor = Color.LightGray;
                    m_Left += 55;
                }

                m_Top += 55;
                m_Left = 20;
            }

            m_Top = 20;
            m_Left = 20;
        }
        
        public void DisplayBoard()
        {
            for (int i = 0; i < r_BoardSize; i++)
            {
                for (int j = 0; j < r_BoardSize; j++)
                {
                    if (m_OthelloGame.m_BoardGame.PlayBoard[i, j] == 'X')
                    {
                        ReshapeSqaure(Color.Black, m_Board[i, j]);
                    }
                    else if (m_OthelloGame.m_BoardGame.PlayBoard[i, j] == 'O')
                    {
                        ReshapeSqaure(Color.White, m_Board[i, j]);
                    }
                    else
                    {
                        ReshapeSqaure(Color.LightGray, m_Board[i, j]);
                    }

                    m_Board[i, j].Enabled = false;
                }
            }
        }

        public void ReshapeSqaure(Color i_Color, Square i_Sqaure)
        {
            if (i_Color == Color.Black)
            {
                i_Sqaure.ForeColor = Color.White;
            }

            if (i_Color != Color.LightGreen && i_Color != Color.LightGray)
            { 
                i_Sqaure.Text = "O";
            }

            i_Sqaure.BackColor = i_Color; 
        }

        public void GetChosenButton()
        {
            for (int i = 0; i < r_BoardSize; i++)
            {
                for (int j = 0; j < r_BoardSize; j++)
                {
                    m_Board[i, j].Click -= new EventHandler(buttonSquareChoise_Click);
                }
            }
        }

        public void MakeMove(Player i_Player, int i_Col, int i_Row)
        {
            m_OthelloGame.Move(i_Col, i_Row);
            m_OthelloGame.CheckValid(i_Player);
            SwitchPlayers();
            PlayerTurn();
        }

        public bool CheckFreeSpaces(Player i_Player)
        {
            GetChosenButton();
            DisplayBoard();
            bool validFlag = m_OthelloGame.CheckFreeSpaces(i_Player);
            foreach (Tuple<int, int> square in m_OthelloGame.m_ValidMovesList)
            {
                ReshapeSqaure(Color.LightGreen, m_Board[square.Item1, square.Item2]);
                m_Board[square.Item1, square.Item2].Enabled = true;
                m_Board[square.Item1, square.Item2].Click += new EventHandler(buttonSquareChoise_Click);
            }

            return validFlag;
        }

        public void GameOver()
        {
            string caption = "Othello";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            string message = GameOverMessage();
            result = MessageBox.Show(message, caption, buttons);

            if (result == System.Windows.Forms.DialogResult.No)
            {
                this.Close();
            }
            else
            {
                this.Hide();
                GameForm newGame = new GameForm(r_BoardSize, m_Player1, m_Player2);
                newGame.ShowDialog();
                this.Close();
            }
        }

        public string GameOverMessage()
        {
            string message = string.Empty;
            m_OthelloGame.UpdateCoinsNumber(ref m_Player1, ref m_Player2);

            if (m_Player1.NumOfCoins > m_Player2.NumOfCoins)
            {
                m_Player1.NumOfWins++;
                message = string.Format("{0} Won!!! ({1}/{2}) ({3}/{4})",
                    m_Player1.PlayerName,
                    m_Player1.NumOfCoins,
                    m_Player2.NumOfCoins,
                    m_Player1.NumOfWins,
                    m_Player2.NumOfWins);
            }
            else if (m_Player1.NumOfCoins < m_Player2.NumOfCoins)
            {
                m_Player2.NumOfWins++;
                message = string.Format("{0} Won!!! ({1}/{2}) ({3}/{4})",
                    m_Player2.PlayerName,
                    m_Player2.NumOfCoins,
                    m_Player1.NumOfCoins,
                    m_Player2.NumOfWins,
                    m_Player1.NumOfWins);
            }
            else
            {
                message = string.Format("Its a Tie!!! ({0}/{1}) ({2}/{3})",
                    m_Player1.NumOfCoins,
                    m_Player2.NumOfCoins,
                    m_Player1.NumOfWins,
                    m_Player2.NumOfWins);
            }

            message += "\n" + "Would you like to play another round?";

            return message;
        }

        private void buttonSquareChoise_Click(object sender, EventArgs e)
        {
            Square selectedMove = sender as Square;
            //m_Col = selectedMove.Col;
            //m_Row = selectedMove.Row;
            MakeMove(m_CurrentPlayer, selectedMove.Col, selectedMove.Row);
        }
    }
}