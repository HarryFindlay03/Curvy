using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NEA_V1
{
	public class Parser
	{
		List<Token> finalOperators = new List<Token>();
		List<double> results = new List<double>();
		Stack<Token> tokens;
		List<double> tokenizerNumbers;

		Stack<Token> tempStack = new Stack<Token>();


		public Parser(Tokenizer tokenizer)
		{
			tokens = tokenizer.getTokens();
			tokenizerNumbers = tokenizer.getNumbers(); //This list may be in the wrong order
		}

		public double Eval()
		{
			double val1 = 0;
			double val2 = 0;
			int temp = 0; //Looping through the numbers List returned by the tokenizer
			double result = 0;
			Token tempOp = Token.Empty;

			while(tokens.Count > 0)
			{
				if(Tokenizer.returnType(tokens.Peek()) == Token.Operator)
				{
					tempStack.Push(tokens.Pop());
					if (Tokenizer.returnType(tokens.Peek()) == Token.Operator)
					{
						finalOperators.Add(tempStack.Pop());
						tempOp = tokens.Pop();
					}
					else //only one operator
					{
						tempOp = tempStack.Pop();
					}
				}
				if(Tokenizer.returnType(tokens.Peek()) == Token.Number)
				{
					tokens.Pop(); tokens.Pop(); //get rid of the 2 number tokens off the stack
					val1 = tokenizerNumbers[0]; 
					temp++;
					val2 = tokenizerNumbers[1];
					temp++;
					switch (tempOp)
					{
						case Token.Add:
							result = val1 + val2;
							break;
						case Token.Subtract:
							result = val2 - val1;
							break;
						case Token.Times:
							result = val1 * val2;
							break;
						case Token.Divide:
							result = val2 / val1;
							break;
						//Add in an exponent operator then just keep timesing val 1 together for val2 times. 
					}
				}
			}
			Console.WriteLine(result);
			return 0;
		}
	}   

}
