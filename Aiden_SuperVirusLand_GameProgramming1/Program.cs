using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aiden_SuperVirusLand_GameProgramming1
{
    internal class Program
    {
        static Random VirusMovement = new Random();
        static String VirusLetter = "X";

        static List<Tuple<int, int>> VirusPositionList = new List<Tuple<int, int>>
        {
            Tuple.Create(5, 8),
            Tuple.Create(10, 5),
            Tuple.Create(15, 8)
        };
        static Tuple<int, int> VirusPositions;

        static int VirusX;
        static int VirusY;


        static Char[,] mapArray = { { '^', '^', '^', '^', '^', '^', '^', '-', '-', '-', '~', '~', '~', '~', '~', '~', '~', '~', '~', '~', '~', '~', '~', '~', '~', '~' },
                                    { '^', '^', '^', '^', '~', '~', '-', '-', '-', '-', '-', '~', '~', '~', '~', '~', '~', '~', '~', '~', '~', '~', '~', '~', '~', '~' },
                                    { '^', '^', '~', '~', '~', '~', '~', '-', '-', '-', '-', '-', '~', '~', '~', '~', '~', '~', '~', '~', '^', '^', '~', '~', '~', '~' },
                                    { '^', '~', '~', '-', '~', '~', '-', '-', '-', '-', '-', '-', '~', '~', '~', '~', '~', '~', '~', '~', '^', '^', '~', '~', '~', '~' },
                                    { '~', '~', '-', '-', '~', '~', '-', '-', '-', '-', '-', '-', '-', '-', '-', '~', '~', '~', '~', '^', '-', '^', '~', '~', '~', '~' },
                                    { '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '^', '-', '-', '^', '~', '~', '~', '^' },
                                    { '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '^', '-', '^', '^' },
                                    { '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '^' },
                                    { '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-' }
        };

        static void PrintMap()
        {
            for (int i = 0; i < mapArray.GetLength(0); i++)
            {
                for (int j = 0; j < mapArray.GetLength(1); j++)
                {
                    if (mapArray[i, j] == '-')
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                    }
                    else if (mapArray[i, j] == '~')
                    {
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                    }
                    else if (mapArray[i, j] == '^')
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                    }
                    Console.Write(mapArray[i, j]);
                }
                Console.ForegroundColor = ConsoleColor.Gray;

                Console.WriteLine();
            }
        }
        static void Virus(int index)
        {
            if (index < 0 || index >= VirusPositionList.Count)
            {
                Console.WriteLine("Index Out Of Bounds");
                return;
            }

            VirusPositions = VirusPositionList[index];
            VirusX = VirusPositions.Item1;
            VirusY = VirusPositions.Item2;

            int UpDownLeftRight = VirusMovement.Next(0, 4);
            int newX = VirusX;
            int newY = VirusY;

            switch (UpDownLeftRight)
            {
                case 0: // up
                    if (VirusY > 0) newY = VirusY - 1;
                    break;
                case 1: // down
                    if (VirusY < mapArray.GetLength(0) - 1) newY = VirusY + 1;
                    break;
                case 2: // left
                    if (VirusX > 0) newX = VirusX - 1;
                    break;
                case 3: // right
                    if (VirusX < mapArray.GetLength(1) - 1) newX = VirusX + 1;
                    break;
            }

            bool virusSpot = VirusPositionList.Any(v => v.Item1 == newX && v.Item2 == newY);

            if (newX >= 0 && newX < mapArray.GetLength(1) && newY >= 0 && newY < mapArray.GetLength(0) && !virusSpot)
            {
                if (mapArray[newY, newX] == '-')
                {
                    Console.SetCursorPosition(VirusX, VirusY);
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write(mapArray[VirusY, VirusX]);
                    Console.ForegroundColor = ConsoleColor.Gray;

                    VirusX = newX;
                    VirusY = newY;

                    var newVirusList = Tuple.Create(VirusX, VirusY);
                    VirusPositionList[index] = newVirusList;

                    Console.SetCursorPosition(VirusX, VirusY);
                    Console.Write(VirusLetter);

                    Random Duplicate = new Random();
                    if (Duplicate.Next(0, 100) >= 90)
                    {
                        VirusPositionList.Add(Tuple.Create(newX, newY));
                    }
                }
            }
        }




        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            PrintMap();
            Console.ReadKey(false);

            for (int i = 0; i < 1000; i++)
            {
                Virus(i % VirusPositionList.Count);
                Thread.Sleep(10);
            }
        }

    }
}
