using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.IO;

namespace UpDownMovement
{
    internal class Level
    {
        private int xPos, yPos; //Keep track of player's position
        private int xGoal, yGoal; //Goal's position

        public bool isGoalReached = false; //Marker to reach next level when true

        private char[][] array; //row = y, col = x
        //  0,0   0,1   0,2   0,3   0,4
        //  1,0   1,1   1,2   1,3   1,4
        //  2,0   2,1   2,2   2,3   2,4
        //  3,0   3,1   3,2   3,3   3,4
        //  4,0   4,1   4,2   4,3   4,4

        private const char x = 'X';
        private const string wall = "█";
        private const string goal = "»";
        private string textFile;

        //FIGURE OUT HOW TO CONVERT TXT FILE TO NEW LEVEL

        public Level(/*int rows, int col,*/ string file)
        {
            textFile = file;
            //array = new string[rows, col];
            //SetArray();
            array = File.ReadAllLines(textFile).Select(x=>x.ToCharArray()).ToArray();
            //array[0, 0] = x;//UpdatePos(0, 0);
            //SetArray();
        }

        /*
        public Level(int rows, int col, int rG, int cG) 
        {
            array = new char[rows][];
            SetArray();
            //array[0, 0] = x;//UpdatePos(0,0);
            xGoal = cG;
            yGoal = rG;
        }*/

        /*
        public void SetArray()
        {
            //  0,0   0,1   0,2   0,3   0,4
            //  1,0   1,1   1,2   1,3   1,4
            //  2,0   2,1   2,2   2,3   2,4
            //  3,0   3,1   3,2   3,3   3,4
            //  4,0   4,1   4,2   4,3   4,4
            for (int r = 0; r < array.GetLength(0); r++)
            {
                for (int c = 0; c < array.GetLength(1); c++)
                {
                    if (r == yGoal && c == xGoal) array[r, c] = goal;  
                    else array[r, c] = wall;
                }
            }
        }*/

        public void FindGoalPos(char[][] array)
        {
            for(int r = 0; r < array.GetLength(0); r++)
            {
                for(int c = 0; c < array.GetLength(1); c++)
                {
                    if (array[r][c].Equals(goal))
                    {
                        yGoal = r;
                        xGoal = c;
                        return;
                    }
                }
            }
        }

        public void PrintArray()
        {
            for (int row = 0; row < array.Length; row++)
            {
                for (int col = 0; col < array[row].Length; col++)
                {
                    Write(array[row][col] + " ");
                }
                WriteLine();
            }
        }
        
        //4/12/24 => STACKOVERFLOWEXCEPTION ERROR
        public void UpdatePos(int row, int col)
        {
            if((col >= 0 && row >= 0) && 
                (array.Length > row && array[row].Length > col) &&
                (array[row][col] != '█'))
            {
                xPos = col;
                yPos = row;
                array[yPos][xPos] = x;
            }
            else
            {
                //xPos = 0;
                //yPos = 0;
                UpdatePos(yPos, xPos);
            }
        }

        public void Move(int row, int col)
        {
            //  0,0   0,1   0,2   0,3   0,4
            //  1,0   1,1   1,2   1,3   1,4
            //  2,0   2,1   2,2   2,3   2,4
            //  3,0   3,1   3,2   3,3   3,4
            //  4,0   4,1   4,2   4,3   4,4
            //SetArray();
            UpdatePos(yPos + row, xPos + col);
            if(xPos == xGoal && yPos == yGoal)
            {
                isGoalReached = true;
                Clear();
                ReadKey(true);
            }
            else
            {
                Clear();
                PrintArray();
            }
        }


    }
}
