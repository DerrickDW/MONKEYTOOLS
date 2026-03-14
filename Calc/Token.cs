using System;
using System.Collections.Generic;
using System.Text;

namespace MONKEYTOOLS.Calc;

 
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
        EOF,

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


