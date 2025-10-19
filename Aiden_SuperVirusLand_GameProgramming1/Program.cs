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
        static Tuple<int, int> VirusPositions = VirusPositionList[0];

        static int VirusX = VirusPositions.Item1;
        static int VirusY = VirusPositions.Item2;


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

            Random UpDownLeftRightRnD = new Random();
            int UpDownLeftRight = UpDownLeftRightRnD.Next(0, 4);

            int newX = VirusX;
            int newY = VirusY;

            Console.WriteLine($"Current Position: ({VirusX}, {VirusY}), Direction: {UpDownLeftRight}");


            if (UpDownLeftRight == 0 && VirusY > 0)
            {
                if (mapArray[VirusX, VirusY - 1] == '-')
                {
                    newX = VirusY - 1;
                }
            }
            else if (UpDownLeftRight == 1 && VirusY < mapArray.GetLength(1) - 1)
            {
                if (mapArray[VirusX, VirusY + 1] == '-')
                {
                    newX = VirusY + 1;
                }
            }
            else if (UpDownLeftRight == 2 && VirusX > 0)
            {
                if (mapArray[VirusX - 1, VirusY] == '-')
                {
                    newX = VirusX - 1;
                }
            }
            else if (UpDownLeftRight == 3 && VirusX < mapArray.GetLength(0) - 1)
            {
                if (mapArray[VirusX - 1, VirusY] == '-')
                {
                    newX = VirusX + 1;
                }
            }
            else
            {
                return;
            }

            if (newX >= 0 && newX < mapArray.GetLength(0) && newY >= 0 && newY < mapArray.GetLength(1) && mapArray[newX, newY] == '-')
            {
                Console.SetCursorPosition(VirusX, VirusY);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write(mapArray[VirusX, VirusY]);
                Console.ForegroundColor = ConsoleColor.Gray;

                VirusX = newX;
                VirusY = newY;
                VirusPositionList[index] = Tuple.Create(VirusX, VirusY);

                Console.SetCursorPosition(VirusX, VirusY);
                Console.Write(VirusLetter);
            }
            else
            {
                Console.WriteLine($"Invalid Move: Current Position: ({VirusX}, {VirusY}) | New Position: ({newX}, {newY})");
                return;
            }


        }

        static void Main(string[] args)
        {
            PrintMap();
            Console.WriteLine("Map Printed");
            Console.ReadKey(false);

            for (int i = 0; i < 10; i++)
            {
                Virus(i % VirusPositionList.Count);
                Thread.Sleep(1000);
            }

        }
    }
}
