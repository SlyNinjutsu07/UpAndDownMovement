using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace UpDownMovement
{
    internal class Level
    {
        private int xPos, yPos;
        private int xGoal, yGoal;

        public bool isGoalReached = false;

        private string[,] array; //row = y, col = x
        //  0,0   0,1   0,2   0,3   0,4
        //  1,0   1,1   1,2   1,3   1,4
        //  2,0   2,1   2,2   2,3   2,4
        //  3,0   3,1   3,2   3,3   3,4
        //  4,0   4,1   4,2   4,3   4,4

        private const string x = "X";
        private const string wall = "█";
        private const string goal = "»";

        public Level(int rows, int col)
        {
            array = new string[rows, col];
            SetArray();
            array[0, 0] = x;//UpdatePos(0, 0);
            xGoal = array.GetLength(1) - 1;
            yGoal = array.GetLength(0) - 1;
        }

        public Level(int rows, int col, int rG, int cG)
        {
            array = new string[rows, col];
            SetArray();
            array[0, 0] = x;//UpdatePos(0,0);
            xGoal = cG;
            yGoal = rG;
        }

        public void SetArray()
        {
            for (int r = 0; r < array.GetLength(0); r++)
            {
                for (int c = 0; c < array.GetLength(1); c++)
                {
                    if (array[r, c] == array[yGoal, xGoal]) array[r, c] = goal; //<< Find Goal mode //if (r == yGoal && c == xGoal) array[r, c] = goal; 
                    else array[r, c] = wall;
                }
            }
        }

        public void PrintArray()
        {
            for (int row = 0; row < array.GetLength(0); row++)
            {
                for (int col = 0; col < array.GetLength(1); col++)
                {
                    Write(array[row, col] + " ");
                }
                WriteLine();
            }
        }
        
        public void UpdatePos(int row, int col)
        {
            if((col >= 0 && row >= 0) && 
                (array.GetLength(0) > row && array.GetLength(1) > col))
            {
                xPos = col;
                yPos = row;
                array[yPos, xPos] = x;
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
            SetArray();
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
