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

        static int VirusPositionX;
        static int VirusPositionY;


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

        static String Virus = "X";
        static void Main(string[] args)
        {
            for(int i = 0; i < mapArray.GetLength(0); i++)
            {
                for(int j = 0; j < mapArray.GetLength(1); j++)
                {
                    if (mapArray[i, j] == '-')
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                    }
                    else if(mapArray[i, j] == '~')
                    {
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                    }
                    else if(mapArray[i, j] == '^')
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                    }
                        Console.Write(mapArray[i, j]/* + " "*/);
                }
                Console.ForegroundColor = ConsoleColor.Gray;

                Console.WriteLine();

            }


            for (int l = 0; l < 20; l++)
            {
                VirusPositionX = VirusMovement.Next(0, mapArray.GetLength(1) - 1);
                VirusPositionY = VirusMovement.Next(0, mapArray.GetLength(0) - 1);

                Console.SetCursorPosition(VirusPositionX, VirusPositionY);
                Char CurrentChar = mapArray[VirusPositionX, VirusPositionY];

                if (CurrentChar == '-')
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(Virus);
                }
                else
                {
                    if(l > 0)
                    {
                        l--;
                    }
                    
                }

            }


            Console.SetCursorPosition(0, 10);
        }
    }
}
