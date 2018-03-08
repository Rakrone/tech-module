using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;
using System.Numerics;

namespace ArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            string [] command = Console.ReadLine().Split();
            var sb = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                sb.Append(input[0]);
            }
            while (command[0] != "end")
            {
                switch (command[0])
                {
                    case "exchange":
                        
                        for (int i = int.Parse(command[1]); i <= sb.Length-1; i++)
                        {
                            if (i < input.Length && 0 < i)
                            {
                                sb.Append(input[i]);

                            }
                            else
                            {
                                Console.WriteLine("Invalid index");
                            }
                        }
                        for (int i = 0; i < int.Parse(command[1]); i++)
                        {
                            sb.Append(input[i]);
                        }
                        break;
                    case "max":

                     
                        Console.WriteLine(oddOrEven(input, command[1]));
                        break;
                    case "min":

                        Console.WriteLine(oddOrEvenMin(input, command[1]));
                        break;
                    case "first":
                        if (command[1] == "even")
                        {

                        }

                        break;

                }
                command = Console.ReadLine().Split();
            }

        }
        /// <summary>
        /// ///
        /// </summary>
        /// <param name="numbersToCheck"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        private static int oddOrEven (int [] numbersToCheck, string command)
        {
            int result = 0;
            int temp = 0;
            if (command == "even")
            {
                for (int i = 0; i < numbersToCheck.Length; i++)
                {
                    if (numbersToCheck[i] % 2 == 0 && numbersToCheck[i] > temp)
                    {
                        temp = numbersToCheck[i];
                    }
                }
            }
            else if (command == "odd")
            {
                for (int i = 0; i < command.Length; i++)
                {
                    if (numbersToCheck[i] % 2 != 0 && numbersToCheck[i] > temp)
                    {
                        temp = numbersToCheck[i];
                    }
                }
            }
            result = temp;

            return result;
        }
        private static int oddOrEvenMin(int[] numbersToCheck, string command)
        {
            int result = 0;
            int temp = int.MaxValue;
            if (command == "even")
            {
                for (int i = 0; i < numbersToCheck.Length; i++)
                {
                    if (numbersToCheck[i] % 2 == 0 && numbersToCheck[i] < temp)
                    {
                        temp = numbersToCheck[i];
                    }
                }
            }
            else if (command == "odd")
            {
                for (int i = 0; i < command.Length; i++)
                {
                    if (numbersToCheck[i] % 2 != 0 && numbersToCheck[i] < temp)
                    {
                        temp = numbersToCheck[i];
                    }
                }
            }
            result = temp;

            return result;
        }
    }
}
