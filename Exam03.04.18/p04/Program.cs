using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;
using System.Numerics;

namespace p04
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string forceSide = "";
            string forceUser = "";
            
            Dictionary<string, List<string>> side = new Dictionary<string, List<string>>();
            
            while (input != "Lumpawaroo")
            {
                Match sideUser = Regex.Match(input, @"^([\w ]*[\w]+)\s?\|\s?([\w]+[\w ]*)");
                Match userSide = Regex.Match(input, @"^([\w ]*[\w]+)\s?\->\s?([\w]+[\w ]*)");
                string[] sideToUser = input.Split(new string[] { " | " }, StringSplitOptions.RemoveEmptyEntries);
                if (sideUser.Length > 0)
                {

                    forceSide = sideUser.Groups[0].ToString().Trim();
                    forceUser = sideUser.Groups[1].ToString().Trim();
                    if (!side.ContainsKey(forceSide))
                    {
                        side.Add(forceSide, new List<string>());
                    }
                    if (!side[forceSide].Contains(forceUser))
                    {
                        side[forceSide].Add(forceUser);
                    }
                }
                ///////////////////////////////////
                string[] userToSide = input.Split(new string[] { " -> "}, StringSplitOptions.RemoveEmptyEntries);

                if (userSide.Length > 0)
                {

                    forceUser = userSide.Groups[0].ToString().Trim();
                    forceSide = userSide.Groups[1].ToString().Trim();
                    if (!side.ContainsKey(forceSide))
                    {
                        side.Add(forceSide, new List<string>());

                    }
                    foreach (var pair in side)
                    {
                        if (pair.Value.Contains(forceUser))
                        {
                            pair.Value.Remove(forceUser);
                        }
                        
                    }
                    if (!side[forceSide].Contains(forceUser))
                    {
                        side[forceSide].Add(forceUser);
                    }


                    Console.WriteLine($"{forceUser} joins the {forceSide} side!");

                }

                input = Console.ReadLine();
            }
            foreach (var pair in side.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                if (pair.Value.Count > 0)
                {
                    Console.WriteLine($"Side: {pair.Key}, Members: {pair.Value.Count}");
                    foreach (var l in pair.Value.OrderBy(x => x))
                    {
                        Console.WriteLine($"! {l}");
                    }
                }
            }
        }
    }
}
