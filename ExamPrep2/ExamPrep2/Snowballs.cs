using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;
using System.Numerics;

namespace ExamPrep2
{
    class Snowballs
    {
        static void Main(string[] args)
        {
            int snowballNum = int.Parse(Console.ReadLine());
            int snowballSnow, snowballTime, snowballQuality;
            BigInteger snowballValue = 0;
            BigInteger maxValue = int.MinValue;
            string output = "";
            for (int i = 0; i < snowballNum; i++)
            {
                snowballSnow = int.Parse(Console.ReadLine());
                snowballTime = int.Parse(Console.ReadLine());
                snowballQuality = int.Parse(Console.ReadLine());
                snowballValue = BigInteger.Pow((snowballSnow / snowballTime), snowballQuality);
                if (snowballValue > maxValue)
                {
                    maxValue = snowballValue;
                    output = $"{snowballSnow} : {snowballTime} = {maxValue} ({snowballQuality})";
                }
            }
            Console.WriteLine(output);
        }
    }
}
