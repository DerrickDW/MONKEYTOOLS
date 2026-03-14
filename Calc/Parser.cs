using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace MONKEYTOOLS.Calc;

public class Parser
{
    private readonly List<Token> _tokens;
    private int _position = 0;
    private Token Current => _tokens[_position];
    private Token Advance()
    {
        if (_position < _tokens.Count)
            _position++;
        return _tokens[_position - 1];
    }
    public Parser(List<Token> tokens)
    {
        _tokens = tokens;
    }
    private Token Consume(TokenType type, string message)
    {
        if (Current.Type == type)
            return Advance();
        throw new Exception(message);
    }
    bool Match(TokenType type)
    {
        if (Current.Type == type)
        {
            Advance();
            return true;
        }
        return false;
    }
    public Ast ParseExpression()
    {
        Ast left = ParseTerm();
        while (Current.Type == TokenType.Plus || Current.Type == TokenType.Minus)
        {
            Token op = Advance();
            Ast right = ParseTerm();
            left = new BinaryNode(left, op.Type, right);
        }
        return left;
    }

    Ast ParseTerm()
    {
        Ast left = ParseFactor();
        while (Current.Type == TokenType.Multiply || Current.Type == TokenType.Divide)
        {
           Token op = Advance();
            Ast right = ParseFactor();
            left = new BinaryNode(left, op.Type, right);
        }
            return left;
    }

    Ast ParseFactor()
    {
        Ast left = ParsePrimary();
        if (Match(TokenType.Power))
        {
            Token op = _tokens[_position - 1];
            Ast right = ParseFactor();
            return new BinaryNode(left, op.Type, right);
        }
        return left;
    }

    Ast ParsePrimary()
    {
        //Ast left = ParseExpression();

        if (Current.Type == TokenType.Number)
        {
            var token = Advance();
            return new NumberNode(double.Parse(token.Value));
        }
        if (Match(TokenType.LeftParen))
        {
            Ast expr = ParseExpression();
            Consume(TokenType.RightParen, "Expected ')'");
            return expr;
        }
        throw new Exception($"Unexpected token: {Current.Type}");
    }
           
}

