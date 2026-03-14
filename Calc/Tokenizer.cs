using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;

namespace MONKEYTOOLS.Calc;

public static class Tokenizer
{

   public enum TokenType
    {
        Number,
        Plus,
        Minus,
        Multiply,
        Divide,
        Power,
        LeftParen,
        RightParen,

    }
    public class Token
    {
        public TokenType Type { get; set; }
        public string Value { get; set; } = "";
        public override string ToString()
        {

            return $"{Type}: {Value}";
        }

    }

    public static List<Token> Tokenize(string input)
    {
        List<Token> tokens = new();
        int i = 0;
        while (i < input.Length)
        {
            char c = input[i];

            //Skip Spaces
            if (char.IsWhiteSpace(c))
            {
                i++;
                continue;
            }

            //Read Number
            if (char.IsDigit(c) || c == '.')
            {
                int start = i;
                bool seenDot = (c == '.');
                i++;

                while (i < input.Length)
                {
                    char next = input[i];

                    if (char.IsDigit(next))
                    {
                        i++;
                        continue;

                    }

                    if (next == '.' && !seenDot)
                    {
                        seenDot = true;
                        i++;
                        continue;
                    }

                    break;
                }
                string numberText = input.Substring(start, i - start);
                tokens.Add(new Token
                {
                    Type = TokenType.Number,
                    Value = numberText
                });

                continue;
            }

            //Single-Char tokens
            switch (c)
            {
                case '+':
                    tokens.Add(new Token { Type = TokenType.Plus, Value = "+" });
                    break;
                case '-':
                    tokens.Add(new Token { Type = TokenType.Minus, Value = "-" });
                    break;
                case '*':
                    tokens.Add(new Token { Type = TokenType.Multiply, Value = "*" });
                    break;
                case '/':
                    tokens.Add(new Token { Type = TokenType.Divide, Value = "/" });
                    break;
                case '^':
                    tokens.Add(new Token { Type = TokenType.Power, Value = "^" });
                    break;
                case '(':
                    tokens.Add(new Token { Type = TokenType.LeftParen, Value = "(" });
                    break;
                case ')':
                    tokens.Add(new Token { Type = TokenType.RightParen, Value = ")" });
                    break;
                default:
                    throw new Exception($"🚬🐒 What in the hell did you even type?: '{c}' ");
            }

            i++;
        }

        return tokens;
    }
    
}
