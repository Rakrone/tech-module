using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;
using System.Numerics;

namespace Snowmen
{
    class Program
    {
        static void Main(string[] args)
        {
            int [] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            List<int> snowmen = new List<int>();
            int winner, loser = 0;
            List<int> loserList = new List<int>();
            foreach (var item in input)
            {
                snowmen.Add(item);
            }
            int attackerIndex, targetIndex;
            int result = 0;
            while(snowmen.Count > 1)
            {
                for (int i = 0; i <= snowmen.Count - 1; i++)
                {
                    attackerIndex = i;
                    targetIndex = snowmen[i];
                    if(loserList.Contains(snowmen[attackerIndex]) || snowmen.Count - loserList.Count <= 1)
                    {
                        continue;
                    }
                    if (targetIndex > snowmen.Count)
                    {
                        targetIndex %= snowmen.Count;
                    }
                    
                    result = Math.Abs(attackerIndex - targetIndex);
                    if (result == 0)
                    {
                        winner = attackerIndex;
                        loser = winner;
                        Console.WriteLine($"{loser} performed harakiri");
                    }
                    else if (result % 2 == 0)
                    {
                        winner = attackerIndex;
                        loser = targetIndex;

                        Console.WriteLine($"{attackerIndex} x {targetIndex} -> {winner} wins");
                    }
                    else if (result % 2 != 0)
                    {
                        winner = targetIndex;
                        loser = attackerIndex;
                        Console.WriteLine($"{attackerIndex} x {targetIndex} -> {winner} wins");
                    }
                    
                    loserList.Add(snowmen[loser]);

                }
                foreach (var item in loserList)
                {
                    snowmen.Remove(item);
                }
                loserList.Clear();
                
                
            }
            
        }
    }
}
