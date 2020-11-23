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
		Exponent
	}
	
	public class Tokenizer
	{
		Stack<string> myStack;
		Token currentToken = Token.Empty;
		double number;

		List<Token> tokens = new List<Token>();

		double testVal = 0;

		public Tokenizer(string str)
		{
			myStack = InfixToPostfix.infixToPostfix(str);
			NextToken();
		}

		public Token Token
		{
			get { return currentToken; }
		}

		public double getNumber
		{
			get { return number; }
		}

		public double getSubInVal()
		{
			return testVal;
		}

		public double setSubInVal(double num)
		{
			testVal = num;
			return testVal;
		}

		public void NextToken()
		{
			while(myStack.Count > 0)
			{
				string stackVar = myStack.Pop().ToString();
				if(stackVar == "+")
				{
					currentToken = Token.Add;
					tokens.Add(currentToken);
				}
				if (stackVar == "-")
				{
					currentToken = Token.Subtract;
					tokens.Add(currentToken);
				}
				if (stackVar == "*")
				{
					currentToken = Token.Times;
					tokens.Add(currentToken);
				}
				if (stackVar == "/")
				{
					currentToken = Token.Divide;
					tokens.Add(currentToken);
				}
				if (stackVar == "x")
				{
					currentToken = Token.subIn;
					tokens.Add(currentToken);
				}
				if (stackVar == "y")
				{
					currentToken = Token.yVal;
					tokens.Add(currentToken);
				}
				if (stackVar == "=")
				{
					currentToken = Token.Equals;
					tokens.Add(currentToken);
				}
				if (stackVar == "^")
				{
					currentToken = Token.Exponent;
					tokens.Add(currentToken);
				}
				if (int.TryParse(stackVar, out int n))
				{
					number = n;
					currentToken = Token.Number;
					tokens.Add(currentToken);
				}
			}

			
		if(myStack.Count == 0)
		{
			currentToken = Token.EOF;
			return; //Needs to do validation so we don't get a stack underflow I think. 
		}
			//throw new InvalidDataException($"Unexcpected Character:{currentChar}");
		}

		public List<Token> returnTokens()
		{
			return tokens;
		}
	}
	
}
