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

#if false
            string? input = null;

            while(input != "ESC")
            {
                input = ReadLine();
                ReadInput(input, l);
            }
            
            WriteLine("Thanks for playing!");
#endif


        }

        public static void ReadInput(string? input, Level level)
        {
            switch (input?.ToLower())
            {
                //  0,0   0,1   0,2   0,3   0,4
                //  1,0   1,1   1,2   1,3   1,4
                //  2,0   2,1   2,2   2,3   2,4
                //  3,0   3,1   3,2   3,3   3,4
                //  4,0   4,1   4,2   4,3   4,4
                case "w":
                    level.Move(-1, 0);
                    break;
                case "a":
                    level.Move(0, -1);
                    break;
                case "s":
                    level.Move(1, 0);
                    break;
                case "d":
                    level.Move(0, 1);
                    break;
            }
        }
    }
}

