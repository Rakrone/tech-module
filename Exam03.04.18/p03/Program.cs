using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;
using System.Numerics;

namespace p03
{
    class Program
    {
        static void Main(string[] args)
        {
            string star = @"([starSTAR])";
            Regex planetPattern = new Regex(@"@([A-Za-z]+)[^@\-!:>]*:[^@\-!:>]*?([0-9]+)[^@\-!:>]*!([AD])![^@\-!:>]*->[^@\-!:>]*?([0-9]+)");
            int n = int.Parse(Console.ReadLine());
            int decryptionKey;
            
            List<string> attackedPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();
            int newValue = 0;
            List<StringBuilder> list = new List<StringBuilder>();
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                StringBuilder sb = new StringBuilder();

                MatchCollection starMatches = Regex.Matches(input, star);
                decryptionKey = starMatches.Count;
                char[] charArray = input.ToCharArray();
                for (int j = 0; j < charArray.Length; j++)
                {
                //    if(charArray[j] == 's' || charArray[j] == 't' || charArray[j] == 'a' || charArray[j] == 'r' || charArray[j] == 'S' || charArray[j] == 'T' || charArray[j] == 'A' || charArray[j] == 'R' )
                //    {
                //        continue;
                //    }
                    newValue = charArray[j] - decryptionKey;
                    sb.Append((char)newValue);
                }
                list.Add(sb);

            }
            foreach (var item in list)
            {
                string newItem = item.ToString();
                if (planetPattern.IsMatch(newItem))
                {
                    Match resultMatch = planetPattern.Match(newItem);
                    if (resultMatch.Groups[3].ToString() == "A")
                    {
                        attackedPlanets.Add(resultMatch.Groups[1].ToString());
                    }
                    else
                    {
                        destroyedPlanets.Add(resultMatch.Groups[1].ToString());
                    }
                }
            }
            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");
            foreach (var item in attackedPlanets.OrderBy(a => a))
            {
                Console.WriteLine($"-> {item}");
            }
            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");
            foreach (var item in destroyedPlanets.OrderBy(x=>x))
            {
                Console.WriteLine($"-> {item}");
            }
           
        }
    }
}
