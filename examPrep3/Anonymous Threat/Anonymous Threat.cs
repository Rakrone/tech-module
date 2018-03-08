using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;

namespace Anonymous_Threat
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> elements = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            string input = Console.ReadLine();
            while (input != "3:1")
            {
                string[] data = input.Split();
                string command = data[0];
                switch (command)
                {
                    case "merge":
                        int startIndex = int.Parse(data[1]);
                        int endIndex = int.Parse(data[2]);
                        startIndex = ValidateIndex(startIndex, elements.Count);
                        endIndex = ValidateIndex(endIndex, elements.Count);

                        string concatElements = "";
                        for (int i = startIndex; i <= endIndex; i++)
                        {
                            concatElements += elements[i];
                        }
                        for (int i = startIndex; i <= endIndex; i++)
                        {
                            elements.RemoveAt(startIndex);
                        }
                        elements.Insert(startIndex, concatElements);
                        
                        break;
                    case "divide":
                        int index = int.Parse(data[1]);
                        int partitionsCount = int.Parse(data[2]);

                        List<string> partitions = SplittedEqually(elements[index], partitionsCount);
                        elements.RemoveAt(index);
                        elements.InsertRange(index, partitions);
                        break;
                    default:
                        break;
                }
                input = Console.ReadLine();
                
            }
            Console.WriteLine(string.Join(" ", elements));
        }
        private static int ValidateIndex(int index, int length)
        {
            if(index <0)
            {
                index = 0;
            }
            if (index > length - 1)
            {
                index = length - 1;
            }
            return index;
        }
        private static List<string> SplittedEqually(string word, int partitionCount)
        {
            List<string> result = new List<string>();
            int part = word.Length / partitionCount;
            while (word.Length >= part)
            {
                result.Add(word.Substring(0, part));
                word = word.Substring(part);
            }
            if(word != "")
            {
                result.Add(word);
            }
            if(result.Count == partitionCount)
            {
                return result;
            }
            else
            {
                string concatLastTwoElements = result[result.Count - 2] + result[result.Count - 1];
                result.RemoveRange(result.Count - 2, 2);
                result.Add(concatLastTwoElements);
                return result;
            }

            
        }
    }
}
