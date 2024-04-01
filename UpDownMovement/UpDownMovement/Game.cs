using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace UpDownMovement
{
    internal class Game
    {
        
        public List<Level> levels = new List<Level>();
        private static int levelCounter;

        public Game(int l)
        {
            levelCounter = 0;
            //levels = new List<Level>(l);
            for(int i = 0; i < l/*levels.Count*/; i++)
            {
                Random r = new Random();
                int val = r.Next(5, 10);
                levels.Add(new Level(val, val + 2));//[i] = new Level(val, val + 2);
            }
        }


        /*Simulates the play of the game and each level in the game
         (The Main method of the game)*/
        public static void Play(Game g)
        {
            DisplayInfo();

            string? input = null;
            input = ReadLine();
            int i = 0;

            if(input == "start")
            {
                while(i < g.levels.Count && input != "ESC")//foreach (Level l in g.levels)
                {
                    Level l = g.levels[i];
                    Clear();
                    l.PrintArray();
                    while (input != "ESC" && l.isGoalReached == false)
                    {
                        input = ReadLine();
                        ReadInput(input, l);
                    }
                    levelCounter++;
                    Write($"Levels Completed [{levelCounter}/{g.levels.Count}]");
                    ReadKey();
                    i++;
                }
            }

            

            Clear();
            DisplayOutro();
            ReadKey(true);
        }


        /*Reads input with null expression, and moves the character in the level
         they are in, according to that input*/
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
                case "esc":
                    break;

            }
        }

        public static void DisplayInfo()
        {
            ForegroundColor = ConsoleColor.Green;
            WriteLine("This game tests horizontal and vertical movement across a grid");
            WriteLine("Input accepted will only be: \"W\" \"A\" \"S\" \"D\" (lowercase will also be accepted)");
            WriteLine("To quit, please type \"ESC\" (case sensitive)\n");
            WriteLine("Type \"start\" to begin");
            ForegroundColor = ConsoleColor.Red;
        }

        public static void DisplayOutro()
        {
            ForegroundColor = ConsoleColor.Green;
            WriteLine("Thanks for playing!");
        }
    }
}
