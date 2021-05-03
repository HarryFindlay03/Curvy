using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NEA_V1
{

	public class Token
	{
		public string Type { get; private set; }
		public double Data { get; private set; }

		public Token(string type, double data)
		{
			this.Type = type;
			this.Data = data;
		}
		public Token(string type)
		{
			this.Type = type;
		}
	}
	
	public class Tokenizer
	{
		Stack<string> myStack;

		List<Token> tokens = new List<Token>();

		double subIn;

		public Tokenizer(string str, double subIn)
		{
			myStack = InfixToPostfix.infixToPostfix(str);
			this.subIn = subIn;
			NextToken();
		}
		public Tokenizer(string str)
		{
			myStack = InfixToPostfix.infixToPostfix(str);
			this.subIn = 1; //Default value of subin
			NextToken();
		}

		public void NextToken()
		{
			while (myStack.Count > 0)
			{
				string stackVar = myStack.Pop().ToString();
				if (stackVar == "+")
				{
					tokens.Add(new Token("+"));
				}
				if (stackVar == "-")
				{
					tokens.Add(new Token("-"));
				}
				if (stackVar == "*")
				{
					tokens.Add(new Token("*"));
				}
				if (stackVar == "/")
				{
					tokens.Add(new Token("/"));
				}
				if (stackVar == "x")
				{
					tokens.Add(new Token("x", subIn));
				}
				if (stackVar == "y")
				{
					tokens.Add(new Token("y"));
				}
				if (stackVar == "=")
				{
					tokens.Add(new Token("="));
				}
				if (stackVar == "^")
				{
					tokens.Add(new Token("^"));
				}
				if (double.TryParse(stackVar, out double n))
				{
					tokens.Add(new Token("n", n));
				}

			}

		}

		public List<Token> getTokens()
		{
			tokens.Reverse();
			return tokens;
		}

		public static bool isOp(Token token)
		{
			switch(token.Type)
			{
				case "+":
				case "-":
				case "*":
				case "/":
				case "^":
					return true;
				default:
					return false;
			}
		}
	}
	
}
