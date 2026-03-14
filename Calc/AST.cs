using MONKEYTOOLS.Calc;
using System;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Text;

namespace MONKEYTOOLS.Calc;

public abstract class Ast
{
}
   public class NumberNode : Ast
    {
        public double Value;
        public NumberNode(double value)
        {
            Value = value;
        }
    }

public class BinaryNode : Ast
{
    public Ast Left;
    public TokenType Operator;
    public Ast Right;

    public BinaryNode(Ast left, TokenType op, Ast right)

    
        {
            Left = left;
            Operator = op;
            Right = right;
        }
}

