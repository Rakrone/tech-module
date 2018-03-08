using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;
using System.Numerics;

namespace p02._01
{
    class Program
    {
        static void Main(string[] args)
        {
            int sequenceLength = int.Parse(Console.ReadLine());
            string[] input = Console.ReadLine().Split(new char[] { '!' }, StringSplitOptions.RemoveEmptyEntries);
            List<int[]> numbers = new List<int[]>();
            var counter = 1;
            var bestCounter = 1;
            var start = 0;
            var bestStart = 0;
            while (input[0] != "Clone them")
            {
                for (int i = 0; i < numbers.Count; i++)
                {
                    for (int j = 1; j < numbers[i].Length; j++)
                    {
                        if (numbers[j - 1] == numbers[j])
                        {
                            counter++;
                            if (counter > bestCounter)
                            {
                                bestCounter = counter;
                                bestStart = start;
                            }
                        }
                        else
                        {
                            start = j;
                            counter = 1;
                        }

                    }
                    
                }
                input = Console.ReadLine().Split(new char[] { '!' }, StringSplitOptions.RemoveEmptyEntries);
            }
            
            
           
            
            for (int i = bestStart; i < bestStart + bestCounter; i++)
            {
                Console.Write($"{numbers[i]} ");
            }
            Console.WriteLine();
        }
    }
}
