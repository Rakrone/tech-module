using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;

namespace Assault
{
    class Program
    {
        static void Main(string[] args)
        {
            int [] beehives = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int [] hornets = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            long sumHornets = 0;
            int count = 0;
            
            foreach (var item in hornets)
            {
                sumHornets += item;
            }
            for (int i = 0; i < beehives.Length; i++)
            {
                
                if (sumHornets > beehives[i])
                {
                    continue;
                }
                else
                {
                    if (count > hornets.Length - 1)
                    {
                        break;
                    }
                    if (beehives[i] - sumHornets > 0)
                    {
                        Console.Write((beehives[i] - sumHornets) + " ");
                    }
                    sumHornets -= hornets[count];
                    hornets[count++] = 0;
                }
            }
            foreach (var item in hornets)
            {
                if (item > 0)
                {
                    Console.Write(item + " ");
                }
            }

        }
    }
}
