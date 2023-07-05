namespace Ex02_Othello
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public struct Player
    {
        private string m_PlayerName;
        private int m_NumOfCoins;
        private int m_NumOfWins;
        private char m_CoinSign;

        public Player(string i_PlayerName, char i_CoinSign)
        {
            m_PlayerName = i_PlayerName;
            m_NumOfCoins = 2;
            m_CoinSign = i_CoinSign;
            m_NumOfWins = 0;
        }

        public string PlayerName
        {
            get { return m_PlayerName; }
            set { m_PlayerName = value; }
        }

        public char CoinSign
        {
            get { return m_CoinSign; }
            set { m_CoinSign = value; }
        }

        public int NumOfCoins
        {
            get { return m_NumOfCoins; }
            set { m_NumOfCoins = value; }
        }

        public int NumOfWins
        { 
            get { return m_NumOfWins; }
            set { m_NumOfWins = value; }
        }
    }
}
