using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;
using System.Numerics;

namespace Exam03._04._18
{
    class Program
    {
        static void Main(string[] args)
        {
            int sequenceLength = int.Parse(Console.ReadLine());
           
            List<int[]> samples = new List<int[]>();
            List<int> sums = new List<int>();
            for (int i = 0; i < 101; i++)
            {
                sums.Add(0);
            }
            string[] input = Console.ReadLine().Split(new char[] { '!' }, StringSplitOptions.RemoveEmptyEntries);
            int lengthCount = 0, finalLength = int.MinValue;
            int tempSum = 0, innerIndex = sequenceLength,index = 0,finalIndex = sequenceLength;
            string bestSequence = "";
            while (input[0] != "Clone them")
            {
                int[] sampleNum = input.Select(int.Parse).ToArray();
                samples.Add(sampleNum);

                input = Console.ReadLine().Split(new char[] { '!' }, StringSplitOptions.RemoveEmptyEntries);
            }
            for (int i = 0; i < samples.Count; i++)
            {

                
                for (int j = 1; j < sequenceLength; j++)
                {
                    if(samples[i][j-1] == 1)
                    {
                        sums[i] += 1;
                        if (samples[i][j-1] == samples[i][j])
                        {
                            lengthCount++;
                            if (innerIndex > j)
                            {
                                innerIndex = j;
                            }

                            
                        }

                        

                    }




                }
                if (samples[i][sequenceLength - 1] == 1)
                {
                    sums[i]++;
                }

                if (finalLength == lengthCount)
                {

                    if (finalIndex > innerIndex)
                    {
                        finalIndex = innerIndex;
                        index = i + 1;
                        tempSum = sums[index-1];
                    }
                    else if (finalIndex == innerIndex)
                    {
                        for (int s = 0; s < sums.Count; s++)
                        {
                            if (tempSum < sums[s])
                            {
                                
                                index = s + 1;
                                tempSum = sums[s];
                            }
                        }
                        
                    }

                }
                else if (finalLength < lengthCount)
                {

                    if (finalIndex > innerIndex)
                    {
                        finalIndex = innerIndex;
                    }
                    finalLength = lengthCount;
                    index = i+1;
                    tempSum = sums[index - 1];
                }
                
                
                lengthCount = 0;
            
                    
                
            }
            bestSequence = string.Join(' ', samples[index-1]);
            Console.WriteLine($"Best DNA sample {index} with sum: {tempSum}.");
            Console.WriteLine(bestSequence);
        }
    }
}
