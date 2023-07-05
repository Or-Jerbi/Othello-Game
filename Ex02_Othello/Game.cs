namespace Ex02_Othello
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Game
    {
        public Board m_BoardGame;
        public int m_ChosenCol;
        public int m_ChosenRow;
        public List<Tuple<int, int>> m_ValidMovesList = new List<Tuple<int, int>> { };
        private Player m_Player1;
        private Player m_Player2;

        public Game(int i_SizeBoard, string i_Player1Name, string i_Player2Name)
        {
            m_BoardGame = new Board(i_SizeBoard);
            m_Player1 = new Player(i_Player1Name, 'X');
            m_Player2 = new Player(i_Player2Name, 'O');
        }

        public Game(int i_SizeBoard, Player i_Player1Name, Player i_Player2Name)
        {
            m_BoardGame = new Board(i_SizeBoard);
            m_Player1 = i_Player1Name;
            m_Player2 = i_Player2Name;
        }

        public int ChosenCol
        {
            get { return m_ChosenCol; }
            set { m_ChosenCol = value; }
        }

        public void Move(int i_Col, int i_Row)
        {
            m_ChosenCol = i_Col;
            m_ChosenRow = i_Row;
        }

        public void ComputerMove()
        {
            if (CheckFreeSpaces(m_Player2))
            {
                Random rnd = new Random();
                int random = rnd.Next(0, m_ValidMovesList.Count);

                m_ChosenRow = m_ValidMovesList[random].Item1;
                m_ChosenCol = m_ValidMovesList[random].Item2;
                CheckValid(m_Player2);
            }
            else
            {
                Console.WriteLine("Computer has no valid moves");
            }
        }

        public bool CheckValid(Player i_Player)
        {
            bool validFlag = true;

            if (!(CheckIfSquareIsEmpty() && (CheckIfExistInCol(i_Player) ||
            CheckIfExistInRow(i_Player) || CheckIfExistInSlant(i_Player))))
            {
                validFlag = false;

                if (i_Player.PlayerName == "Computer")
                {
                    ComputerMove();
                }
            }
            else
            {
                CheckIfExistInCol(i_Player);
                CheckIfExistInRow(i_Player);
                CheckIfExistInSlant(i_Player);
            }

            return validFlag;
        }

        public bool CheckIfSquareIsEmpty()
        {
            bool validFlag;
            validFlag = m_BoardGame.m_Board[m_ChosenRow, m_ChosenCol] == ' ';

            return validFlag;
        }

        public bool CheckIfExistInCol(Player i_Player)
        {
            int numOfCoinsFlip = 0;
            bool validFlag = false;

            for (int i = m_ChosenRow + 1; i < m_BoardGame.m_BoardSize; i++)
            {
                if (m_BoardGame.m_Board[i, m_ChosenCol] == i_Player.CoinSign || m_BoardGame.m_Board[i, m_ChosenCol] == ' ')
                {
                    if (numOfCoinsFlip > 0 && m_BoardGame.m_Board[i, m_ChosenCol] == i_Player.CoinSign)
                    {
                        validFlag = true;
                        FlipCoins(i, m_ChosenCol, i_Player);
                    }

                    break;
                }
                else
                {
                    numOfCoinsFlip++;
                }
            }

            for (int i = m_ChosenRow - 1; i >= 0; i--)
            {
                if (m_BoardGame.m_Board[i, m_ChosenCol] == i_Player.CoinSign || m_BoardGame.m_Board[i, m_ChosenCol] == ' ')
                {
                    if (numOfCoinsFlip > 0 && m_BoardGame.m_Board[i, m_ChosenCol] == i_Player.CoinSign)
                    {
                        validFlag = true;
                        FlipCoins(i, m_ChosenCol, i_Player);
                    }

                    break;
                }
                else
                {
                    numOfCoinsFlip++;
                }
            }

            return validFlag;
        }

        public bool CheckIfExistInRow(Player i_Player)
        {
            int numOfCoinsFlip = 0;
            bool validFlag = false;

            for (int i = m_ChosenCol + 1; i < m_BoardGame.m_BoardSize; i++)
            {
                if (m_BoardGame.m_Board[m_ChosenRow, i] == i_Player.CoinSign || m_BoardGame.m_Board[m_ChosenRow, i] == ' ')
                {
                    if (numOfCoinsFlip > 0 && m_BoardGame.m_Board[m_ChosenRow, i] == i_Player.CoinSign)
                    {
                        validFlag = true;
                        FlipCoins(m_ChosenRow, i, i_Player);
                    }

                    break;
                }
                else
                {
                    numOfCoinsFlip++;
                }
            }

            for (int i = m_ChosenCol - 1; i >= 0; i--)
            {
                if (m_BoardGame.m_Board[m_ChosenRow, i] == i_Player.CoinSign || m_BoardGame.m_Board[m_ChosenRow, i] == ' ')
                {
                    if (numOfCoinsFlip > 0 && m_BoardGame.m_Board[m_ChosenRow, i] == i_Player.CoinSign)
                    {
                        validFlag = true;
                        FlipCoins(m_ChosenRow, i, i_Player);
                    }

                    break;
                }
                else
                {
                    numOfCoinsFlip++;
                }
            }

            return validFlag;
        }

        public bool CheckIfExistInSlant(Player i_Player)
        {
            bool checkUpRightDir = false;
            bool checkDownRightDir = false;
            bool checkUpLeftDir = false;
            bool checkDownLeftDir = false;
            bool existFlag = false;
            int numOfCoinsFlipUpRight = 0;
            int numOfCoinsFlipDownRight = 0;
            int numOfCoinsFlipUpLeft = 0;
            int numOfCoinsFlipDownLeft = 0;

            for (int i = 1; i <= m_BoardGame.m_BoardSize; i++)
            {
                if ((m_ChosenRow - i >= 0) && (m_ChosenCol + i < m_BoardGame.m_BoardSize) && (!checkUpRightDir))
                {
                    ////up right slant dirction
                    if (m_BoardGame.m_Board[m_ChosenRow - i, m_ChosenCol + i] == i_Player.CoinSign || m_BoardGame.m_Board[m_ChosenRow - i, m_ChosenCol + i] == ' ')
                    {
                        checkUpRightDir = true;
                        if (numOfCoinsFlipUpRight > 0 && m_BoardGame.m_Board[m_ChosenRow - i, m_ChosenCol + i] == i_Player.CoinSign)
                        {
                            existFlag = true;
                            FlipCoins(m_ChosenRow - i, m_ChosenCol + i, i_Player);
                        }
                    }
                    else
                    {
                        numOfCoinsFlipUpRight++;
                    }
                }

                if ((m_ChosenRow + i < m_BoardGame.m_BoardSize) && (m_ChosenCol - i >= 0) && (!checkDownLeftDir))
                {
                    ////Down left slant dirction
                    if (m_BoardGame.m_Board[m_ChosenRow + i, m_ChosenCol - i] == i_Player.CoinSign || m_BoardGame.m_Board[m_ChosenRow + i, m_ChosenCol - i] == ' ')
                    {
                        checkDownLeftDir = true;
                        if (numOfCoinsFlipDownLeft > 0 && m_BoardGame.m_Board[m_ChosenRow + i, m_ChosenCol - i] == i_Player.CoinSign)
                        {
                            existFlag = true;
                            FlipCoins(m_ChosenRow + i, m_ChosenCol - i, i_Player);
                        }
                    }
                    else
                    {
                        numOfCoinsFlipDownLeft++;
                    }
                }

                if ((m_ChosenRow - i >= 0) && (m_ChosenCol - i >= 0) && (!checkUpLeftDir))
                {
                    ////Up left slant dirction
                    if (m_BoardGame.m_Board[m_ChosenRow - i, m_ChosenCol - i] == i_Player.CoinSign || m_BoardGame.m_Board[m_ChosenRow - i, m_ChosenCol - i] == ' ')
                    {
                        checkUpLeftDir = true;
                        if (numOfCoinsFlipUpLeft > 0 && m_BoardGame.m_Board[m_ChosenRow - i, m_ChosenCol - i] == i_Player.CoinSign)
                        {
                            existFlag = true;
                            FlipCoins(m_ChosenRow - i, m_ChosenCol - i, i_Player);
                        }
                    }
                    else
                    {
                        numOfCoinsFlipUpLeft++;
                    }
                }

                if ((m_ChosenRow + i < m_BoardGame.m_BoardSize) && (m_ChosenCol + i < m_BoardGame.m_BoardSize) && (!checkDownRightDir))
                {
                    ////Down right slant dirction
                    if (m_BoardGame.m_Board[m_ChosenRow + i, m_ChosenCol + i] == i_Player.CoinSign || m_BoardGame.m_Board[m_ChosenRow + i, m_ChosenCol + i] == ' ')
                    {
                        checkDownRightDir = true;
                        if (numOfCoinsFlipDownRight > 0 && m_BoardGame.m_Board[m_ChosenRow + i, m_ChosenCol + i] == i_Player.CoinSign)
                        {
                            existFlag = true;
                            FlipCoins(m_ChosenRow + i, m_ChosenCol + i, i_Player);
                        }
                    }
                    else
                    {
                        numOfCoinsFlipDownRight++;
                    }
                }
            }

            return existFlag;
        }

        public bool FlipCoins(int i_FlipRow, int i_FlipCol, Player i_Player)
        {
            bool flipAllCoins = true;
            int maxCol = Math.Max(this.m_ChosenCol, i_FlipCol);
            int minCol = Math.Min(this.m_ChosenCol, i_FlipCol);
            int maxRow = Math.Max(this.m_ChosenRow, i_FlipRow);
            int minRow = Math.Min(this.m_ChosenRow, i_FlipRow);

            if (minRow == maxRow)
            {
                ////flip coin in row
                for (int i = minCol; i <= maxCol; i++)
                {
                    {
                        m_BoardGame.m_Board[m_ChosenRow, i] = i_Player.CoinSign;
                    }
                }

                return flipAllCoins;
            }
            else if (minCol == maxCol)
            {
                ////flip coin in column
                for (int i = minRow; i <= maxRow; i++)
                {
                    m_BoardGame.m_Board[i, m_ChosenCol] = i_Player.CoinSign;
                }
            }
            else
            {
                for (int i = 0; i <= maxRow - minRow; i++)
                {
                    if ((m_ChosenRow > i_FlipRow) && (m_ChosenCol < i_FlipCol))
                    {
                        ////up right slant
                        m_BoardGame.m_Board[m_ChosenRow - i, m_ChosenCol + i] = i_Player.CoinSign;
                    }
                    else if ((m_ChosenRow > i_FlipRow) && (m_ChosenCol > i_FlipCol))
                    {
                        ////up left slant
                        m_BoardGame.m_Board[m_ChosenRow - i, m_ChosenCol - i] = i_Player.CoinSign;
                    }
                    else if ((m_ChosenRow < i_FlipRow) && (m_ChosenCol < i_FlipCol))
                    {
                        ////down right slant
                        m_BoardGame.m_Board[m_ChosenRow + i, m_ChosenCol + i] = i_Player.CoinSign;
                    }
                    else if ((m_ChosenRow < i_FlipRow) && (m_ChosenCol > i_FlipCol))
                    {
                        ////down left slant
                        m_BoardGame.m_Board[m_ChosenRow + i, m_ChosenCol - i] = i_Player.CoinSign;
                    }
                }
            }

            return false;
        }

        public void UpdateCoinsNumber(ref Player i_Player1, ref Player i_Player2)
        {
            i_Player1.NumOfCoins = 0;
            i_Player2.NumOfCoins = 0;

            for (int i = 0; i < m_BoardGame.BoardSize; i++)
            {
                for (int j = 0; j < m_BoardGame.BoardSize; j++)
                {
                    if (m_BoardGame.m_Board[i, j] == i_Player1.CoinSign)
                    {
                        i_Player1.NumOfCoins++;
                    }
                    else if (m_BoardGame.m_Board[i, j] == i_Player2.CoinSign)
                    {
                        i_Player2.NumOfCoins++;
                    }
                }
            }
        }

        public bool CheckFreeSpaces(Player i_Player)
        {
            m_ValidMovesList.Clear();
            bool validMoveFlag = false;
            Board copyOfBoard = new Board(m_BoardGame.BoardSize);
            m_BoardGame.CopyBoard(ref copyOfBoard);

            for (int i = 0; i < m_BoardGame.BoardSize; i++)
            {
                for (int j = 0; j < m_BoardGame.m_BoardSize; j++)
                {
                    m_ChosenRow = i;
                    m_ChosenCol = j;
                    if ((CheckIfSquareIsEmpty() && (CheckIfExistInCol(i_Player) ||
                        CheckIfExistInRow(i_Player) || CheckIfExistInSlant(i_Player))))
                    {
                        m_ValidMovesList.Add(Tuple.Create(i, j));
                        validMoveFlag = true;
                    }

                    copyOfBoard.CopyBoard(ref m_BoardGame);
                }               
            }

            return validMoveFlag;
        }
    }
}