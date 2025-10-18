using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        }
        static void Virus()
        {
            ChangeList(0);
            Console.SetCursorPosition(VirusX, VirusY);
            Console.WriteLine(VirusLetter);

            ChangeList(1);
            Console.SetCursorPosition(VirusX, VirusY);
            Console.WriteLine(VirusLetter);

            ChangeList(2);
            Console.SetCursorPosition(VirusX, VirusY);
            Console.WriteLine(VirusLetter);
        }

        static void Main(string[] args)
        {
            Console.CursorSize = 100;
            PrintMap();
            Console.WriteLine("Map Printed");
            Console.ReadKey(false);

            Virus();
            Console.ReadKey();

        }
    }
}
