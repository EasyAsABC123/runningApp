using System;

namespace RunningApp
{
    internal class Program
    {
        static void EnterNewRun()
        {
            Console.WriteLine("\tDid you run Today? Y/N");
            var responseDidTheyRun = Console.ReadKey().KeyChar;
            var run = new Run();

            if (responseDidTheyRun == 'y')
            {
                run.Ran = true;
                Console.WriteLine("Thanks for running!");
            }
            else if (responseDidTheyRun == 'n')
            {
                run.Ran = false;
                Console.WriteLine("You should run more.");
            }
            else
            {
                Console.WriteLine("You entered an invalid option, logging error and quitting");
                // Log error to txt file
                return;
            }

            if (run.Ran == false) { return; }

            Console.WriteLine("Since you ran, how far did you run? Enter Distance in Miles");
            var responseHowFarRan = Console.ReadLine();
            if (!decimal.TryParse(responseHowFarRan, out decimal howFarRan))
            {
                Console.WriteLine("You entered an invalid option, logging error and quitting");
                return;
            }
            run.Distance = howFarRan;

            Console.WriteLine("How long did it take you to run?");
            if (!TimeSpan.TryParse(Console.ReadLine(), out TimeSpan howLongRan))
            {
                Console.WriteLine("You entered an invalid option, logging error and quitting");
                return;
            }
            run.Duration = howLongRan;

            Console.WriteLine(run);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Our Running App!!");
            Console.WriteLine("1. Enter a new run");
            Console.WriteLine("2. Exit");

            char keyPressed;
            do
            {
                keyPressed = Console.ReadKey().KeyChar;

                switch (keyPressed)
                {
                    case '1':
                        EnterNewRun();
                        break;
                }
            } while (keyPressed != '2');
        }
    }
}