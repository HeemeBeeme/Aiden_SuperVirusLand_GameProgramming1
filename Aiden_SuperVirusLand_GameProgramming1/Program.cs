using System;
using System.Collections.Generic;
using System.Linq;
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
                    Console.Write(mapArray[i, j]/* + " "*/);
                }
                Console.ForegroundColor = ConsoleColor.Gray;

                Console.WriteLine();
            }
        }

        static void ChangeList(int index)
        {
            VirusPositions = VirusPositionList[index];
            VirusX = VirusPositions.Item1;
            VirusY = VirusPositions.Item2;

            Console.SetCursorPosition(VirusX, VirusY);
            Console.Write(VirusLetter);
        }
        static void Virus()
        {
            for(int i = 0; i < 4; i++)
            {
                Random UpDownLeftRightRnD = new Random();
                int UpDownLeftRight = UpDownLeftRightRnD.Next(0, 4);


                //up
                if (UpDownLeftRight == 0 && mapArray[VirusX, VirusY + 1] == '-')
                {
                    VirusPositionList[i] = Tuple.Create(VirusX, VirusY++);
                    Console.WriteLine("up");
                }
                //down
                else if (UpDownLeftRight == 1 && mapArray[VirusX, VirusY - 1] == '-')
                {
                    VirusPositionList[i] = Tuple.Create(VirusX, VirusY--);
                    Console.WriteLine("down");
                }
                //left
                else if (UpDownLeftRight == 2 && mapArray[VirusX - 1, VirusY] == '-')
                {
                    VirusPositionList[i] = Tuple.Create(VirusX--, VirusY);
                    Console.WriteLine("left");
                }
                //right
                else if (UpDownLeftRight == 3 && mapArray[VirusX + 1, VirusY] == '-')
                {
                    VirusPositionList[i] = Tuple.Create(VirusX++, VirusY);
                    Console.WriteLine("right");
                }
                else
                {
                    Console.WriteLine("B");
                }

                ChangeList(i);

                Thread.Sleep(1000);

            }
            
        }

        static void Main(string[] args)
        {
            PrintMap();
            Console.WriteLine("Map Printed");
            Console.ReadKey(false);

            Virus();
            Console.ReadKey();

        }
    }
}
