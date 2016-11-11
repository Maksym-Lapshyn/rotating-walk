using System;

namespace the_first_one
{
    class Program
    {
        public static void Main()
        {
            Maze myMaze = new Maze(6);
            myMaze.FillTheMaze();
            myMaze.PrintTheMaze();
        }
    }

    public class Maze
    {
        private int[,] matrix;
        private int currentRow;
        private int currentCol;
        private int step;
        public Maze(int Size)
        {
            matrix = new int[Size, Size];
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    matrix[i, j] = 0;
                }
            }
            currentCol = 0;
            currentRow = 0;
            step = 1;
            matrix[currentRow, currentCol] = step;
            step++;
        }

        public void FillTheMaze()
        {
            int numberOfSteps = 1;
            bool checkResult = false;
            int numberOfPath = 0;
            while (numberOfSteps < Math.Pow(matrix.GetLength(0), 2))
            {
                int limit = 0;
                while (checkResult == false)
                {
                    checkResult = DoStep(numberOfPath % 8);
                    if (limit == 7)
                    {
                        currentRow = RestartPosition()[0];
                        currentCol = RestartPosition()[1];
                        matrix[currentRow, currentCol] = step;
                        step++;
                        break;
                    }
                    if (checkResult == false)
                    {
                        numberOfPath++;
                        limit++;
                    }
                }
                numberOfSteps++;
                checkResult = false;
            }
        }

        public void PrintTheMaze()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0, 7}", matrix[i,j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(matrix[5,5]);
        }

        private int[] RestartPosition()
        {
            int[] positions = new int[2];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        positions[0] = i;
                        positions[1] = j;
                        return positions;
                    }
                }
            }
            return positions;
        }

        private bool DoStep(int number)
        {
            if (number == 0)
            {
                if (currentRow + 1 < matrix.GetLength(0) && currentCol + 1 < matrix.GetLength(1) && matrix[currentRow + 1, currentCol + 1] == 0)
                {
                    matrix[currentRow + 1, currentCol + 1] = step;
                    currentRow++;
                    currentCol++;
                    step++;
                    return true;
                }
            }
            else if (number == 1)
            {
                if (currentRow + 1 < matrix.GetLength(0) && matrix[currentRow + 1, currentCol] == 0)
                {
                    matrix[currentRow + 1, currentCol] = step;
                    currentRow++;
                    step++;
                    return true;
                }
            }
            else if (number == 2)
            {
                if (currentRow + 1 < matrix.GetLength(0) && currentCol - 1 >= 0 && matrix[currentRow + 1, currentCol - 1] == 0)
                {
                    matrix[currentRow + 1, currentCol - 1] = step;
                    currentRow++;
                    currentCol--;
                    step++;
                    return true;
                }
            }
            else if (number == 3)
            {
                if (currentCol - 1 >= 0 && matrix[currentRow, currentCol - 1] == 0)
                {
                    matrix[currentRow, currentCol - 1] = step;
                    currentCol--;
                    step++;
                    return true;
                }
            }
            else if (number == 4)
            {
                if (currentRow - 1 >= 0 && currentCol - 1 >= 0 && matrix[currentRow - 1, currentCol - 1] == 0)
                {
                    matrix[currentRow - 1, currentCol - 1] = step;
                    currentRow--;
                    currentCol--;
                    step++;
                    return true;
                }
            }
            else if (number == 5)
            {
                if (currentRow - 1 >= 0 && matrix[currentRow - 1, currentCol] == 0)
                {
                    matrix[currentRow - 1, currentCol] = step;
                    currentRow--;
                    step++;
                    return true;
                }
            }
            else if (number == 6)
            {
                if (currentRow - 1 >= 0 && currentCol + 1 < matrix.GetLength(1) && matrix[currentRow - 1, currentCol + 1] == 0)
                {
                    matrix[currentRow - 1, currentCol + 1] = step;
                    currentRow--;
                    currentCol++;
                    step++;
                    return true;
                }
            }
            else if (number == 7)
            {
                if (currentCol + 1 < matrix.GetLength(1) && matrix[currentRow, currentCol + 1] == 0)
                {
                    matrix[currentRow, currentCol + 1] = step;
                    currentCol++;
                    step++;
                    return true;
                }
            }
            return false;
        }
    }
}
