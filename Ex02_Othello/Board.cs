namespace Ex02_Othello
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Board
    {
        public readonly char[,] m_Board;
        public int m_BoardSize;

        public Board(int i_BoardSize)
        {
            m_BoardSize = i_BoardSize;
            m_Board = new char[i_BoardSize, i_BoardSize];

            for (int i = 0; i < i_BoardSize; i++)
            {
                for (int j = 0; j < i_BoardSize; j++)
                {
                    m_Board[i, j] = ' ';
                }
            }

            m_Board[((i_BoardSize / 2) - 1), ((i_BoardSize / 2) - 1)] = 'O';
            m_Board[((i_BoardSize / 2) - 1), (i_BoardSize / 2)] = 'X';
            m_Board[(i_BoardSize / 2), ((i_BoardSize / 2) - 1)] = 'X';
            m_Board[(i_BoardSize / 2), (i_BoardSize / 2)] = 'O';
        }

        public char[,] PlayBoard
        {
            get { return m_Board; }
        }

        public int BoardSize
        {
            get { return m_BoardSize; }
            set { m_BoardSize = value; }
        }

        public void PrintBoard()
        {
            int letterA = 'A';
            string rowPartition = "=";
            int elementsCounter = 0;

            Console.Write("   ");
            for (int i = 0; i < m_BoardSize; i++)
            {
                Console.Write(" {0}  ", Char.ConvertFromUtf32(letterA + i));
                rowPartition += "====";
            }

            foreach (char element in m_Board)
            {
                if (elementsCounter == 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("  {0}", rowPartition);
                    Console.Write((elementsCounter / m_BoardSize) + 1);
                }
                else if (elementsCounter % m_BoardSize == 0)
                {
                    Console.WriteLine(" | ");
                    Console.WriteLine("  {0}", rowPartition);
                    Console.Write((elementsCounter / m_BoardSize) + 1);
                }

                Console.Write(" | ");
                Console.Write(element);

                elementsCounter++;
            }

            Console.WriteLine(" | ");
            Console.WriteLine("  {0}", rowPartition);
        }

        public void CopyBoard(ref Board i_BoardCopy)
        {
            for (int i = 0; i < m_Board.GetLength(0); i++)
            {
                for (int j = 0; j < m_Board.GetLength(0); j++)
                {
                    i_BoardCopy.m_Board[i, j] = this.m_Board[i, j];
                }
            }
        }
    }
}
