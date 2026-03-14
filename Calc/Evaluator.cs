using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MONKEYTOOLS.Calc;

public static class Evaluator
{
 
    public static double Evaluate(Ast node)
    {
        if (node is NumberNode num)
        {
            return num.Value;
        }

        if (node is BinaryNode bin)
        {
            double left = Evaluate(bin.Left);
            double right = Evaluate(bin.Right);

            switch (bin.Operator)
            {
                case TokenType.Plus:
                    return left + right;

                    case TokenType.Minus:
                    return left - right;

                    case TokenType.Multiply:
                    return left * right;

                    case TokenType.Divide:
                    if (right == 0)
                        throw new DivideByZeroException();
                    return left / right;

                    case TokenType.Power:
                    return Math.Pow(left, right);

            }
        }
        throw new Exception("Unknown AST node");
        
        //var tokens = Tokenizer.Tokenize(input);
        //var parser = new Parser(tokens);
        //Ast ast = parser.ParseExpression();

        //Console.WriteLine(ast);

        //Console.WriteLine("🐒 tokens:");

        //DEBUG
        //foreach (var t in tokens)
            //Console.WriteLine(t);

        //return 0;

    }
}
