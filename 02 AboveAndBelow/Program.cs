using System;
using System.Linq;
using System.Diagnostics;

namespace _02_AboveAndBelow
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("\tThis program prints the number of integers in an array that are above or below than the given input.");
            Console.WriteLine("\tEnter the array elements separated by space. To finish press Enter");
            Console.Write("\t");
            string arrayElements = Console.ReadLine();

            Console.WriteLine("\tEnter the element which needs to be searched in the array for above and below.");
            Console.Write("\t");
            int input = Convert.ToInt32(Console.ReadLine().TrimEnd());

            // We are not doing any sanity checks here and assuming, user is going to input all ints. But we can also perform sanity checks if required.
            int[] arrayOfInts = Array.ConvertAll(arrayElements.TrimEnd().Split(' '), int.Parse);

            printAboveAndBelow(arrayOfInts, input);
        }

        private static void printAboveAndBelow(int[] arrayOfInts, int input)
        {
            // A straight forward approach would be to use LINQ with appropriate where conditions.
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Console.WriteLine($"\tabove: {arrayOfInts.Where(x => x > input).Count()}");
            Console.WriteLine($"\tbelow: {arrayOfInts.Where(x => x < input).Count()}");
            sw.Stop();
            long noOfLINQTicks = sw.ElapsedTicks;
            Console.WriteLine($"\tNumber of Ticks using LINQ {noOfLINQTicks}");
            sw.Reset();
            // But using LINQ the compiler will have to loop through the array twice. Also LINQ does not have best of perfromance. 
            // It is taking around 95K ticks on my machine.

            // A better approach would be to use a simple for each loop just once and add appropriate conditions for both above and below 
            // inside the same for loop. This way we will have best of both worlds in which we will add multiple condition inside the same loop.
            sw.Start();
            int countOfAbove = 0;
            int countOfBelow = 0;
            foreach (var item in arrayOfInts)
            {
                if (item < input)
                    countOfBelow++;
                if (item > input)
                    countOfAbove++;
            }

            Console.WriteLine($"\tabove: {countOfAbove}");
            Console.WriteLine($"\tbelow: {countOfBelow}");
            sw.Stop();
            long noOfForTicks = sw.ElapsedTicks;
            Console.WriteLine($"\tNumber of Ticks using For {noOfForTicks}");
            // This is taking around 9k ticks. Which is around 10 times better than our first solution.
            Console.WriteLine($"\tFor each Loop is around {noOfLINQTicks / noOfForTicks} times faster than LINQ");
        }
    }
}
