using System;
using System.Diagnostics;
using System.Text;

namespace _03_RotateCharacters
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("\tThis program rotates the characters in a string by a given input and have the overflow appear at the beginning.");
            Console.WriteLine("\tPlease enter the String to be rotated");
            Console.Write("\t");
            string input = Console.ReadLine().Trim();

            Console.WriteLine("\tEnter the position from which the string needs to be rotated");
            Console.Write("\t");
            int position = Convert.ToInt32(Console.ReadLine().Trim());

            RotateCharacters(input, position);
        }

        private static void RotateCharacters(string input, int position)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            // Using Substring to get the required result. But in this approach we will have to use Substring twice.
            Console.WriteLine($"\t{input.Substring(input.Length - position)}{input.Substring(0, input.Length - position)}");
            sw.Stop();
            long noOfSubstringTicks = sw.ElapsedTicks;
            Console.WriteLine($"\tNumber of Ticks using Substring {noOfSubstringTicks}");
            sw.Reset();

            // A better alternative is to use the for loop and keep on appending the characters to string builder.
            sw.Start();

            // Creating string in place of string builder is also an option. But it will cause multiple string variables in memory (string is immutable)
            // This will cause a significant performance and memory loss.
            //string beforeString = string.Empty;
            //string afterString = string.Empty;

            StringBuilder beforeString = new StringBuilder();
            StringBuilder afterString = new StringBuilder();

            // This number will not change inside the for loop. So compute it, store it in a variable and use it inside the for loop
            int positionCheck = input.Length - position;

            for (int i = 0; i < input.Length; i++)
            {
                // Computing this inside the loop deteriorates the performance 
                //if(i < input.Length - position)

                if (i < positionCheck)
                {
                    // String concatenatation causes multiple string in memory. Should not be used.
                    //beforeString += input[i];

                    // Use String Builder instead
                    beforeString.Append(input[i]);
                }
                else
                {
                    // String concatenatation causes multiple string in memory. Should not be used.
                    //afterString += input[i];

                    // Use String Builder instead
                    afterString.Append(input[i]);
                }
            }
            //Console.WriteLine($"\t{afterString}{beforeString}");
            Console.WriteLine($"\t{afterString.ToString()}{beforeString.ToString()}");
            sw.Stop();
            long noOfForTicks = sw.ElapsedTicks;
            Console.WriteLine($"\tNumber of Ticks using For {noOfForTicks}");

            Console.WriteLine($"\tFor each Loop is around {noOfSubstringTicks / noOfForTicks} times faster than Substring");
        }
    }
}
