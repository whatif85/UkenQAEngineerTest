using System;
using System.Collections.Generic;
using System.IO;

/*
1. Create a C# script that can open up a text file
    (files can be found in src folder),
    and tell us the number that has repeated the fewest number of times.
    Each number is on it's own line and is an integer.
2. If two numbers have the same frequency count,
    return the smaller of the two numbers.
3. Upload the final project to github. 
*/

namespace C_SharpChallenge
{
    class Program
    {
        private static Dictionary<int, uint> numberList = new Dictionary<int, uint>();

        static int FindLeastCommonNumber()
        {
            int leastCommonNumber = 0;
            uint lowestNumber = 0;

            // Pass through the dictionary and find the highest values first
            // for initialization purposes
            foreach (var number in numberList)
            {
                if (number.Value > lowestNumber)
                {
                    lowestNumber = number.Value;
                    leastCommonNumber = number.Key;
                }
            }

            // Second pass to find lowest key
            foreach (var number in numberList)
            {
                Console.Out.WriteLine(number);

                if (number.Value < lowestNumber)
                {
                    leastCommonNumber = number.Key;
                    lowestNumber = number.Value;
                }
                else if (number.Value == lowestNumber && number.Key < leastCommonNumber)
                {
                    leastCommonNumber = number.Key;
                    lowestNumber = number.Value;
                }
            }

            return leastCommonNumber;
        }

        static void Main(string[] args)
        {
            int parsedInt;

            Console.Out.WriteLine("Enter file name (Please include extension, such as 1.txt)");
            string fileName = Console.ReadLine();

            Console.Out.WriteLine(fileName);
            bool bFileValid = File.Exists(fileName);

            if (bFileValid)
            {
                StreamReader textFile = new StreamReader(fileName);

                while (textFile.EndOfStream == false)
                {
                    if (int.TryParse(textFile.ReadLine(), out parsedInt))
                    {
                        if (numberList.ContainsKey(parsedInt))
                        {
                            numberList[parsedInt]++;
                        }
                        else                        
                        {
                            numberList.Add(parsedInt, 1);
                        }
                    }
                }

                int lowestNumber = FindLeastCommonNumber();
                Console.Out.WriteLine(lowestNumber);
            }
            else
            {
                Console.Out.WriteLine("File not found");
            }

            Console.ReadKey();
        }
    }
}
