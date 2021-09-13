using System;

namespace _01_Startup_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("This Program gives you an option to execute two programs.");
                Console.WriteLine("1. Above And below.");
                Console.WriteLine("2. Rotate Characters");
                Console.WriteLine("Press 1 to execute Above and Below and 2 to execute rotate characters. Enter quit or exit to terminate the program.");
                string inputtedOption = Console.ReadLine().Trim();

                if(inputtedOption.ToLower() == "quit" || inputtedOption.ToLower() == "exit")
                {
                    break;
                }

                if(int.TryParse(inputtedOption, out int option))
                {
                    switch (option)
                    {
                        case 1:
                            _02_AboveAndBelow.Program.Main();
                            break;
                        case 2:
                            _03_RotateCharacters.Program.Main();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Please enter valid integer value.");
                }
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
