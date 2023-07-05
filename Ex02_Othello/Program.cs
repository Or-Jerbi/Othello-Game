namespace Ex02_Othello
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Program
    {
        public static void Main()
        {
            UILogic startGame = new UILogic();
            startGame.BuildGame();
        }
    }
}