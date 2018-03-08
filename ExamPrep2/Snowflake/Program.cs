using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03.Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^([^A-Za-z\d]+)    
([\d_]+)
((?:[^A-Za-z\d]+)(?:[\d_]+)(?<core>[a-zA-Z]+)(?:[\d_]+)(?:[^A-Za-z\d]+))
([\d_]+)
([^A-Za-z\d]+)$";

            // цаката на тази задача е да не забравяме че като използваме съкращението \w ще ни връща множество от [a-zA-Z_]
            // тази долна черта ни спъва задачата :Д

            List<string> inputs = new List<string>();
            string input = string.Empty;

            for (int i = 0; i < 5; i++)
            {
                input = Console.ReadLine();

                inputs.Add(input);
            }

            string result = $@"{inputs[0]}
{inputs[1]}
{inputs[2]}
{inputs[3]}
{inputs[4]}";

            if (Regex.IsMatch(result, pattern))
            {
                Match match = Regex.Match(result, pattern);
                int coreLe = match.Groups["core"].Value.Length;
                Console.WriteLine("Valid");
                Console.WriteLine(coreLe);
            }
            else
            {
                Console.WriteLine("Invalid");
            }
        }
    }
}