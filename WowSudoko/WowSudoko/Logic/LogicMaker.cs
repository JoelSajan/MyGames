using System;
using System.Collections.Generic;
using System.Linq;

namespace WowSudoko.Logic
{
    public static class LogicMaker
    {
        public static List<int> basics = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        public static int[,] Sudoko = new int[9, 9];
        public static int[,] heart = new int[9, 9];
        static LogicMaker()
        {
            heartGeneratorMethod();
            middleGeneratorMethod();
            cornerGeneratorMethod();
        }

        private static void cornerGeneratorMethod()
        {
            var random = new Random();
            basics = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var needARest = false;
            int row = 0, col = 0;
            int tries = 0;
            var middle = Sudoko;
            for (int corner = 0; corner < 4; corner++)
            {
                if (corner == 0)
                {
                    row = 2;
                    col = 2;
                    tries = 0;
                }
                else if (corner == 1)
                {
                    row = 2;
                    col = 8;
                    tries = 0;
                }
                else if (corner == 2)
                {
                    row = 8;
                    col = 2;
                    tries = 0;
                }
                else if (corner == 3)
                {

                    row = 8;
                    col = 8;
                    tries = 0;
                }
                do
                {
                    needARest = false;
                    int num = 0;
                    for (int i = 1; i < 10; i++)
                    {
                        num = basics[random.Next(basics.Count)];
                        if (!fillCorner(row, col, num))
                        {
                            reset(row, col);
                            needARest = true;
                            num = 0;
                            break;
                        }
                        basics.Remove(num);
                        if (basics.Count == 0)
                        {
                            break;
                        }
                    }
                    basics = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                    tries++;
                    if (tries == 10)
                    {
                        corner = -1;
                        Sudoko = middle;
                        break;
                    }
                } while (needARest);
            }
            displayBoard();
        }

        private static void reset(int row, int col)
        {
            for (int i = row - 1; i < row + 2; i++)
            {
                for (int j = col - 1; j < col + 2; j++)
                {
                    Sudoko[i - 1, j - 1] = 0;
                }
            }
        }

        private static bool fillCorner(int row, int col, int filler)
        {
            var done = false;
            for (int i = row - 1; i < row + 2; i++)
            {
                for (int j = col - 1; j < col + 2; j++)
                {
                    if (rowAndcolCheckCorner(i, j, filler) && Sudoko[i - 1, j - 1] == 0)
                    {
                        Sudoko[i - 1, j - 1] = filler;
                        filler = 0;
                        done = true;
                        break;
                    }
                }
                if (done == true)
                    break;
            }
            if (filler != 0)
                return false;
            else
                return true;
        }

        private static bool rowAndcolCheckCorner(int row, int col, int number)
        {
            //rowcheck
            for (int i = 0; i < 9; i++)
            {
                if (Sudoko[i, col - 1] == number || Sudoko[row - 1, i] == number)
                    return false;

            }
            return true;
        }

        private static void middleGeneratorMethod()
        {
            fillMiddle(2, 5);
            fillMiddle(5, 2);
            fillMiddle(5, 8);
            fillMiddle(8, 5);

        }

        private static void fillMiddle(int row, int col, bool needHelpBro = false)
        {
            var needtorestart = false;
            do
            {
                var random = new Random();
                var acceptedList = new List<int>();
                var currentBox = new List<int>();
                needtorestart = false;
                for (int i = row - 1; i < row + 2; i++)
                {
                    for (int j = col - 1; j < col + 2; j++)
                    {
                        List<int> listOfForbiddenNumbers;

                        listOfForbiddenNumbers = rowAndcolCheck(i - 1, j - 1, currentBox);
                        acceptedList = basics.Except(listOfForbiddenNumbers).ToList();

                        if (acceptedList.Count == 0)
                        {
                            needtorestart = true;
                            break;
                        }
                        Sudoko[i - 1, j - 1] = acceptedList[random.Next(acceptedList.Count)];
                        currentBox.Add(Sudoko[i - 1, j - 1]);
                    }
                }
            } while (needtorestart);

        }



        private static List<int> rowAndcolCheck(int row, int col, List<int> numbers)
        {
            var alreadyRegistered = new List<int>(numbers);
            //rowcheck
            for (int i = 0; i < 9; i++)
            {
                if (Sudoko[row, i] != 0)
                {
                    if (!alreadyRegistered.Any(x => x == Sudoko[row, i]))
                        alreadyRegistered.Add(Sudoko[row, i]);
                }
                if (Sudoko[i, col] != 0)
                {
                    if (!alreadyRegistered.Any(x => x == Sudoko[i, col]))
                        alreadyRegistered.Add(Sudoko[i, col]);
                }
            }
            return alreadyRegistered;
        }

        private static void heartGeneratorMethod()
        {
            Random random = new Random();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    heart[i, j] = basics[random.Next(basics.Count)];
                    Sudoko[3 + i, 3 + j] = heart[i, j];
                    basics = basics.Where(x => x != heart[i, j]).ToList();
                    //Console.Write(heart[i, j]+" ");
                }
                //Console.Write("\n");
            }
            basics = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        }

        private static void displayBoard()
        {
            Console.WriteLine("-------------------------------------");
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (j == 0)
                        Console.Write("| ");
                    Console.Write(Sudoko[i, j] + " | ");
                }
                Console.Write("\n");
                Console.WriteLine("-------------------------------------");
            }
        }

        public static void displayBoard_ofChoice(int[,] sudoko)
        {
            Console.WriteLine("-------------------------------------");
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (j == 0)
                        Console.Write("| ");
                    Console.Write(sudoko[i, j] + " | ");
                }
                Console.Write("\n");
                Console.WriteLine("-------------------------------------");
            }
        }
    }
}
