using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEA_V1
{
    class InfixToPostfix
    {
        private static int Prec(char c)
        {
            switch (c)
            {
                case '+':
                case '-':
                    return 1;
                case '*':
                case '/':
                    return 2;
                case '^':
                    return 3;
                default:
                    return -1;
            }
        }

        public static Stack<string> infixToPostfix(string exp)
        {
            Stack<char> stack = new Stack<char>();
            Stack<string> postfix = new Stack<string>();

            string result = "";

            for(int i = 0; i < exp.Length; i++)
            {
                char c = exp[i];

                if (char.IsLetterOrDigit(c))
                {
                    result += c;
                }

                else if (c == '(')
                {
                    postfix.Push(result);
                    result = "";
                    stack.Push(c);
                }
                else if (c == ')')
                {
                    postfix.Push(result);
                    result = "";
                    while (stack.Count > 0 && stack.Peek() != '(')
                    {
                        postfix.Push(stack.Pop().ToString());
                    }
                    if (stack.Count > 0 && stack.Peek() != '(')
                    {
                        Console.WriteLine("Invalid Expression");
                        return new Stack<string>();
                    }
                    else
                    {
                        stack.Pop();
                    }
                }

                else //an operator is found
                {
                    postfix.Push(result);
                    result = "";
                    while(stack.Count > 0 && Prec(c) <= Prec(stack.Peek()))
                    {
                        postfix.Push(stack.Pop().ToString());
                    }
                    stack.Push(c);
                }
            }

            postfix.Push(result);
            result = "";
            while(stack.Count > 0)
            {
                postfix.Push(stack.Pop().ToString());
            }
            return postfix;
        }

        public static void showStack(Stack<string> stack)
        {
            string data = "";
            while (stack.Count > 0)
            {
                data = stack.Pop() + data;
            }
            Console.WriteLine(data);
        }
    }
}
