using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        string expression = "{7+(8*5)-[(9-7)+(4+1)]}";
        bool isBalanced = IsBalanced(expression);
        Console.WriteLine($"La expresión '{expression}' está balanceada: {isBalanced}");
    }

    static bool IsBalanced(string expression)
    {
        Stack<char> stack = new Stack<char>();
        foreach (char c in expression)
        {
            if (c == '{' || c == '(' || c == '[')
            {
                stack.Push(c);
            }
            else if (c == '}' || c == ')' || c == ']')
            {
                if (stack.Count == 0) return false;
                char top = stack.Pop();
                if (!IsMatchingPair(top, c)) return false;
            }
        }
        return stack.Count == 0;
    }

    static bool IsMatchingPair(char open, char close)
    {
        return (open == '{' && close == '}') ||
               (open == '(' && close == ')') ||
               (open == '[' && close == ']');
    }
}