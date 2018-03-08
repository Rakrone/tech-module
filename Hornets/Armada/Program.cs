using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;

namespace Armada
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(new char[] { '=', '>', '-', ' ', ':' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, int> legionsWithActivity = new Dictionary<string, int>();
            Dictionary<string, Dictionary<string, long>> legionsWithSoldiers = new Dictionary<string, Dictionary<string, long>>();
            for (int i = 0; i < n; i++)
            {
                int lastActivity = int.Parse(input[0]);
                string legionName = input[1];
                string soldierType = input[2];
                int soldierCount = int.Parse(input[3]);
                if(!legionsWithActivity.ContainsKey(legionName))
                {
                    legionsWithActivity.Add(legionName, lastActivity);
                    legionsWithSoldiers.Add(legionName, new Dictionary<string, long>());
                }
                if (lastActivity > legionsWithActivity[legionName])
                {
                    legionsWithActivity[legionName] = lastActivity;
                }
                if (!legionsWithSoldiers[legionName].ContainsKey(soldierType))
                {
                    legionsWithSoldiers[legionName].Add(soldierType, 0);
                }
                legionsWithSoldiers[legionName][soldierType] += soldierCount;
            }
            string[] outputCommand = Console.ReadLine().Split('\\');
            if (outputCommand.Length > 1)
            {
                int activity = int.Parse(outputCommand[0]);
                string soldierType = outputCommand[1];
                foreach (var legion in legionsWithSoldiers.Where(l => l.Value.ContainsKey(soldierType)).OrderByDescending(l => l.Value[soldierType]))
                {
                    if(legionsWithActivity[legion.Key]< activity)
                        Console.WriteLine($"{legion.Key} -> {legionsWithSoldiers[legion.Key][soldierType]}");
                }

            }
            else
            {
                
                string soldierType = outputCommand[0];

                
                foreach (var legionEntry in legionsWithActivity.OrderByDescending(legion => legion.Value))
                {
                    if (legionsWithSoldiers[legionEntry.Key].ContainsKey(soldierType))
                    {
                        Console.WriteLine("{0} : {1}", legionEntry.Value, legionEntry.Key);
                    }
                }
            }

        }
    }
}
