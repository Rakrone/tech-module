using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;
using System.Numerics;

namespace ExamPrep4
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal cash = decimal.Parse(Console.ReadLine());
            long guests = long.Parse(Console.ReadLine());
            
            decimal count = Math.Ceiling(guests/6.0m);
            
            decimal bananaPrice = count*2.0m*(decimal.Parse(Console.ReadLine()));
            decimal eggsPrice = count * 4.0m * (decimal.Parse(Console.ReadLine()));
            decimal berriesPrice = count * 0.2m *(decimal.Parse(Console.ReadLine()));
            decimal totalCost = bananaPrice + eggsPrice + berriesPrice;
            
            if (cash >= totalCost)
            {
                Console.WriteLine($"Ivancho has enough money - it would cost {totalCost:F2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivancho will have to withdraw money - he will need {totalCost - cash:F2}lv more.");
            }
        }
    }
}
