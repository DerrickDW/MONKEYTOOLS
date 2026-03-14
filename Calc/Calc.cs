using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
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
        double lastResult = 0;

        while (true)
        {
            Console.Write("> ");
            string input = Console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(input))
                continue;
            if (input.ToLower() == "exit")
                break;
            if (input.ToLower() == "clear")
            {
                lastResult = 0;
                Console.WriteLine("🐒 memory wiped");
                continue;
            }
            if (input.ToLower() == "help")
            {
                Console.WriteLine("🐒 count yer banana's supports + - * / parentheses () exponents ^ last result as 'ans' clear memory 'clear'");
                continue;
            }
            try
            {
                input = input.Replace("ans", lastResult.ToString());
                var tokens = Tokenizer.Tokenize(input);
                var parser = new Parser(tokens);
                var ast = parser.ParseExpression();
                //PrintAst(ast);

                double result = Evaluator.Evaluate(ast);
                Console.WriteLine(result);
                lastResult = result;

            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("🚬🐒 anyone tell you not to divide by zero?");
            }
            catch (Exception ex)
            {
                Console.WriteLine("🚬🐒 ya broke it again");
                Console.WriteLine(ex);
            }
        }

    }
    static void PrintAst(Ast ast, string indent = "")
    {
        if (ast is NumberNode num)
        {
            Console.WriteLine($"{indent}Number({num.Value})");
            return;
        }
        if (ast is BinaryNode bin)
        {
            Console.WriteLine($"{indent}Binary({bin.Operator})");
            PrintAst(bin.Left, indent + "  ");
            PrintAst(bin.Right, indent + "  ");
        }
    }


}
