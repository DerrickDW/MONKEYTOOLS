using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace MONKEYTOOLS.Calc;

public static class Calc
{
    public static void Run()
    {
        Console.WriteLine("MONKEY CALC");
        Console.WriteLine("🐒 go ahead calculate something");
        Console.WriteLine("Type 'exit' to quit");

        while (true)
        {
            Console.Write("> ");
            string input = Console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(input))
                continue;

            if (input.ToLower() == "exit")
                break;

            try
            {
                double result = Evaluator.Evaluate(input);
                Console.WriteLine(result);

            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("🚬🐒 anyone tell you not to divide by zero?");
            }
            catch (Exception ex)
            {
                Console.WriteLine("🚬🐒 ya broke it again");
            }
        }

    }


}
