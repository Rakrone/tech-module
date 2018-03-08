using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;

namespace Hornets
{
    class Program
    {
        static void Main(string[] args)
        {
            int wingFlaps = int.Parse(Console.ReadLine());
            decimal distancePerThousandFlaps = decimal.Parse(Console.ReadLine());
            int endurance = int.Parse(Console.ReadLine());

            Console.WriteLine($"{(wingFlaps / 1000) * distancePerThousandFlaps:F2} m.");
            Console.WriteLine($"{(wingFlaps / 100) + (wingFlaps / endurance) * 5} s.");
        }
    }
}
