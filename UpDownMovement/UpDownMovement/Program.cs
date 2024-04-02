using System;
using static System.Console;

namespace UpDownMovement
{
    class Program
    {

        public static void Main(string[] args)
        {
            Game g = new Game(3);
            Level l = new Level(5, 5);

            Title = "Game";

            Game.Play(g);

        }
    }
}

