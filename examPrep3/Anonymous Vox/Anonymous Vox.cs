using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;

namespace Anonymous_Vox
{
    class Program
    {
        static void Main(string[] args)
        {
            string encodedText = Console.ReadLine();

            string[] placeholders = Console.ReadLine().Split("{}".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            string pattern = @"([A-Za-z]+)(.+)(\1)";
            var matches = Regex.Matches(encodedText, pattern);
            int count = 0;
            foreach (Match m in matches)
            {
                string decodedMessage = m.Groups[1] + placeholders[count++] + m.Groups[3];
                encodedText = encodedText.Replace(m.Value, decodedMessage);
            }
            Console.WriteLine(encodedText);
        }
    }
}
