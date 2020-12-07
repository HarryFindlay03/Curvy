using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NEA_V1
{
	public enum Token
	{
        Empty,
		EOF,
		Number,
		Add,
		Subtract,
		Times,
		Divide,
		subIn,
		yVal,
		Equals,
		Exponent,
		Operator
	}

	public class Tokenizer
	{
		Stack<string> myStack;
		Token currentToken = Token.Empty;
		List<double> numbers = new List<double>();

		Stack<Token> tokens = new Stack<Token>();

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

		public Token Token
		{
			get { return currentToken; }
		}

		public List<double> getNumbers()
		{
			//Reverse numbers as they are added to the list in the reverse order
			numbers.Reverse();
			return numbers;
		}

		public double getSubInVal()
		{
			return subIn;
		}

		public void NextToken()
		{
			while (myStack.Count > 0)
			{
				string stackVar = myStack.Pop().ToString();
				if (stackVar == "+")
				{
					currentToken = Token.Add;
					tokens.Push(currentToken);
				}
				if (stackVar == "-")
				{
					currentToken = Token.Subtract;
					tokens.Push(currentToken);
				}
				if (stackVar == "*")
				{
					currentToken = Token.Times;
					tokens.Push(currentToken);
				}
				if (stackVar == "/")
				{
					currentToken = Token.Divide;
					tokens.Push(currentToken);
				}
				if (stackVar == "x")
				{
					currentToken = Token.subIn;
					numbers.Add(subIn);
					tokens.Push(currentToken);
				}
				if (stackVar == "y")
				{
					currentToken = Token.yVal;
					tokens.Push(currentToken);
				}
				if (stackVar == "=")
				{
					currentToken = Token.Equals;
					tokens.Push(currentToken);
				}
				if (stackVar == "^")
				{
					currentToken = Token.Exponent;
					tokens.Push(currentToken);
				}
				if (int.TryParse(stackVar, out int n))
				{
					numbers.Add(n);
					currentToken = Token.Number;
					tokens.Push(currentToken);
				}

			}

			if (myStack.Count == 0)
			{
				currentToken = Token.EOF;
				return; //Needs to do validation so we don't get a stack underflow I think. 
			}
			//throw new InvalidDataException($"Unexcpected Character:{currentChar}");

		}
		public Stack<Token> getTokens()
		{
			return tokens;
		}
		
		public static Token returnType(Token token)
		{
			switch(token)
			{
				case Token.Add:
				case Token.Subtract:
				case Token.Times:
				case Token.Divide:
				case Token.Exponent:
					return Token.Operator;
				case Token.Number:
				case Token.subIn:
				case Token.yVal:
					return Token.Number;
				default:
					return Token.EOF;
			}
		}
	}
	
}
