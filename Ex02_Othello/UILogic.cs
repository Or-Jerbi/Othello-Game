namespace Ex02_Othello
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class UILogic
    {
        private Game m_OthelloGame;
        private Player m_Player1;
        private Player m_Player2;

        public void BuildGame()
        {
            string player1Name;
            string player2Name;
            string playerChoice;

            Console.WriteLine(string.Format(
@"WELCOME TO OTHELLO
press 'Q' any time you to quit game"));
            Console.WriteLine("Insert your player name");
            player1Name = Console.ReadLine();
            m_Player1 = new Player(player1Name, 'X');
            QuitGame(player1Name);

            Console.WriteLine(string.Format(
@"Press '0' to play against another player or press '1' to play against computer"));
            playerChoice = Console.ReadLine();
            QuitGame(playerChoice);

            while ((playerChoice != "0" && playerChoice != "1") || playerChoice == "Q")
            {
                QuitGame(playerChoice);
                Console.WriteLine("Please Press 0 to play with another player or 1 to play with computer");
                playerChoice = Console.ReadLine();
            }

            switch (playerChoice)
            {
                case "0":
                    Console.WriteLine("Insert the second player name");
                    player2Name = Console.ReadLine();
                    m_Player2 = new Player(player2Name, 'O');
                    QuitGame(player2Name);
                    m_OthelloGame = new Game(ChooseBoardSize(), m_Player1, m_Player2);

                    StartGame2Players();
                    break;
                case "1":
                    m_Player2 = new Player("Computer", 'O');
                    m_OthelloGame = new Game(ChooseBoardSize(), m_Player1, m_Player2);

                    StartGameWithComputer();
                    break;
                default:
                    while (playerChoice != "1" && playerChoice != "0")
                    {
                        Console.WriteLine("Please Press 0 to play with another player or 1 to play with computer");
                        playerChoice = Console.ReadLine();
                    }

                    break;
            }
        }

        public void QuitGame(string i_QuitButton)
        {
            if (i_QuitButton == "Q")
            {
                Console.WriteLine("Game Over");
                System.Environment.Exit(0);
            }
        }

        public int ChooseBoardSize()
        {
            string boardSize;
            Console.WriteLine("Please press '6' for 6X6 board or '8' for 8X8 board");
            boardSize = Console.ReadLine();
            while ((boardSize != "6" && boardSize != "8") || boardSize == "Q")
            {
                QuitGame(boardSize);
                Console.WriteLine("Your input must be '6' or '8'");
                boardSize = Console.ReadLine();
            }

            return Int32.Parse(boardSize);
        }

        public int GetRowNumber(int i_LineLength)
        {
            string input;
            int o_SquareRowChoice;

            Console.WriteLine("Enter your row number");
            input = Console.ReadLine();
            QuitGame(input);
            int.TryParse(input, out o_SquareRowChoice);
            o_SquareRowChoice--;

            while (o_SquareRowChoice < 0 || o_SquareRowChoice > i_LineLength)
            {
                Console.WriteLine(string.Format(
@"Your input is not between 1 to {0}
Please enter a new number",
i_LineLength + 1));
                input = Console.ReadLine();
                QuitGame(input);
                int.TryParse(input, out o_SquareRowChoice);
                o_SquareRowChoice--;
            }

            return o_SquareRowChoice;
        }

        public int GetColLetter(int i_LineLength)
        {
            string input;
            char o_playerColChoice;
            int sqaureColChoice;

            Console.WriteLine("Enter your column letter");
            input = Console.ReadLine();
            QuitGame(input);
            char.TryParse(input, out o_playerColChoice);

            while ((o_playerColChoice < 'A' || o_playerColChoice > 'A' + i_LineLength) && (o_playerColChoice < 'a' || o_playerColChoice > 'a' + i_LineLength))
            {
                Console.WriteLine(string.Format(
@"Your input is not a letter between A to {0}
Please enter a new letter",
Char.ConvertFromUtf32('A' + i_LineLength)));
                input = Console.ReadLine();
                QuitGame(input);
                char.TryParse(input, out o_playerColChoice);
            }

            sqaureColChoice = char.ToUpper(o_playerColChoice) - 'A';

            return sqaureColChoice;
        }

        public void StartGame2Players()
        {
            while (m_OthelloGame.CheckFreeSpaces(m_Player1) || m_OthelloGame.CheckFreeSpaces(m_Player2))
            {
                if (m_OthelloGame.CheckFreeSpaces(m_Player1))
                {
                    Console.WriteLine("Its {0}({1}) turn", m_Player1.PlayerName, m_Player1.CoinSign);
                    GetChosenSquare(m_Player1);
                }
                else
                {
                    Console.WriteLine("Player {0} has no valid moves", m_Player1.PlayerName);
                }

                if (m_OthelloGame.CheckFreeSpaces(m_Player2))
                {
                    Console.WriteLine("Its {0}({1}) turn", m_Player2.PlayerName, m_Player2.CoinSign);
                    GetChosenSquare(m_Player2);
                }
                else
                {
                    Console.WriteLine("Player {0} has no valid moves", m_Player2.PlayerName);
                }
            }

            GameOver();
        }

        public void StartGameWithComputer()
        {
            while (m_OthelloGame.CheckFreeSpaces(m_Player1) || m_OthelloGame.CheckFreeSpaces(m_Player2))
            {
                if (m_OthelloGame.CheckFreeSpaces(m_Player1))
                {
                    Console.WriteLine("Its {0}({1}) turn", m_Player1.PlayerName, m_Player1.CoinSign);
                    GetChosenSquare(m_Player1);
                    m_OthelloGame.m_BoardGame.PrintBoard();
                }
                else
                {
                    Console.WriteLine("Player {0} has no valid moves", m_Player1.PlayerName);
                }

                Console.WriteLine(string.Format(@"{0}'s points : {1}   {2}'s points : {3}", m_Player1.PlayerName, m_Player1.NumOfCoins, m_Player2.PlayerName, m_Player2.NumOfCoins));
                m_OthelloGame.ComputerMove();
            }

            GameOver();
        }

        public void GetChosenSquare(Player i_Player)
        {
            m_OthelloGame.m_BoardGame.PrintBoard();
            m_OthelloGame.Move(GetColLetter(m_OthelloGame.m_BoardGame.m_BoardSize - 1), GetRowNumber(m_OthelloGame.m_BoardGame.m_BoardSize - 1));
            if (!m_OthelloGame.CheckValid(i_Player))
            {
                if (i_Player.PlayerName != "Computer")
                {
                    Console.WriteLine(string.Format(
@"Your move is not valid
Its {0}({1}) turn",
i_Player.PlayerName,
i_Player.CoinSign));
                    GetChosenSquare(i_Player);
                }
            }
        }

        public void GameOver()
        {
            Console.WriteLine("Game Over");
            m_OthelloGame.UpdateCoinsNumber(ref m_Player1, ref m_Player2);
            if (m_Player1.NumOfCoins > m_Player2.NumOfCoins)
            {
                Console.WriteLine("{0}'s WON!!!!", m_Player1.PlayerName);
            }
            else if (m_Player1.NumOfCoins < m_Player2.NumOfCoins)
            {
                Console.WriteLine("{0}'s WON!!!! ", m_Player2.PlayerName);
            }
            else
            {
                Console.WriteLine("IT'S A TIE!!!");
            }

            Console.WriteLine(string.Format(
@"score: {0}'s -  {1}       {2}'s - {3}",
m_Player1.PlayerName,
m_Player1.NumOfCoins,
m_Player2.PlayerName,
m_Player2.NumOfCoins));

            Console.WriteLine("Would you like to play again? press '1' else press at any other key");
            if (Console.ReadLine() == "1")
            {
                m_OthelloGame.m_BoardGame = new Board(m_OthelloGame.m_BoardGame.BoardSize);
                if (m_Player2.PlayerName == "Computer")
                {
                    StartGameWithComputer();
                }
                else
                {
                    StartGame2Players();
                }
            }
            else
            {
                Console.WriteLine("Bye bye");
            }
        }
    }
}