using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;
using System.Numerics;

namespace p01
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal cash = decimal.Parse(Console.ReadLine());
            decimal studentsCount = decimal.Parse(Console.ReadLine());
            decimal lightsaberPrice = decimal.Parse(Console.ReadLine());
            decimal freeBelts = Math.Floor(studentsCount / 6);
            decimal robePrice = decimal.Parse(Console.ReadLine());
            decimal beltPrice = decimal.Parse(Console.ReadLine());
            decimal xtraSabers = Math.Ceiling(studentsCount / 10);
            decimal totalPrice = lightsaberPrice * (studentsCount + xtraSabers) + beltPrice * (studentsCount - freeBelts) + robePrice * studentsCount;

            if (cash >= totalPrice)
            {
                Console.WriteLine($"The money is enough - it would cost {totalPrice:F2}lv.");

            }
            else
            {
                Console.WriteLine($"Ivan Cho will need {totalPrice - cash:F2}lv more.");
            }

        }
    }
}
