using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MONKEYTOOLS.Calc;

public static class Evaluator
{

    public static double Evaluate(string input)
    {
        var tokens = Tokenizer.Tokenize(input);

        Console.WriteLine("🐒 tokens:");

        //DEBUG
        foreach (var t in tokens)
            Console.WriteLine(t);

        return 0;

    }
}
