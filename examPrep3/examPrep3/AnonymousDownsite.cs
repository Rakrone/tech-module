using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;

namespace examPrep3
{
    class AnonymousDownsite
    {
        static void Main(string[] args)
        {
            int websiteCount = int.Parse(Console.ReadLine());
            int securityKey = int.Parse(Console.ReadLine());
            
            decimal totalLoss = 0.0m;
            for (int i = 0; i < websiteCount; i++)
            {
                string[] input = Console.ReadLine().Split();
                string siteName = input[0];
                decimal siteVisit = decimal.Parse(input[1]);
                decimal siteCommercialPricePerVisit = decimal.Parse(input[2]);


                decimal siteLoss = siteVisit * siteCommercialPricePerVisit;
                totalLoss += siteLoss;
                Console.WriteLine(siteName);

            }
            Console.WriteLine($"Total Loss: {totalLoss:F20}");
            Console.WriteLine($"Security Token: {BigInteger.Pow(securityKey, websiteCount)}");
        }
    }
}
