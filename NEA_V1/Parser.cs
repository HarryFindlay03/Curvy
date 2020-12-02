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
		Stack<Token> tokens;
		Stack<double> tempStack = new Stack<double>();
		Stack<double> resultTemp = new Stack<double>();
		List<double> tokenizerNumbers;

		public Parser(Tokenizer tokenizer)
		{
			tokens = tokenizer.getTokens();
			tokenizerNumbers = tokenizer.getNumbers(); 
		}

		public double Eval()
		{
			Token op = Token.Empty;
			bool doubleOP = false;
			double result = 1;
			double finalresult = 1;
			double output = 1;
			int i = 0;
			int j = 0;
			while(tokens.Count > 0)
			{
				if(Tokenizer.returnType(tokens.Peek()) == Token.Operator)
				{
					op = tokens.Pop();
					if(doubleOP == true)
					{
						j = 0;
						doubleOP = false;
						while(resultTemp.Count > 0)
						{
							if(op == Token.Add)
							{
								finalresult += resultTemp.Pop();
							}
						}
						result = finalresult - 1;
					}
					else
					{
						while (tempStack.Count > 0)
						{
							double tempVal = tempStack.Pop();
							if (op == Token.Add)
							{
								result = result + tempVal;
								output = output + tempVal;
								if (j == 0)
								{
									result = result - 1;
									output = output - 1;
								}
							}
							else if(op == Token.Subtract)
							{
								//Needs to be finished
							}
							else if(op == Token.Times)
							{
								result = result * tempVal;
								output = output * tempVal;
							}
							else if(op == Token.Divide)
							{
								//Needs to be finsihed
							}
							j++;
						}
						resultTemp.Push(result);
						result = 1;
					}
					doubleOP = true;
				}
				else if(Tokenizer.returnType(tokens.Peek()) == Token.Number)
				{
					tokens.Pop();
					if(Tokenizer.returnType(tokens.Peek()) == Token.Number)
					{
						tokens.Pop();
						doubleOP = false;
						tempStack.Push(tokenizerNumbers[i]);
						i++;
						tempStack.Push(tokenizerNumbers[i]);
						i++;
					}
					else
					{
						doubleOP = false;
						tempStack.Push(tokenizerNumbers[i]);
						i++;
					}
				}
			}
			if(j == 0) //reusing j to see whether the double op if statement has been triggered
			{
				return result;
			}
			else
			{
				return output;
			}
		}
	}   
}
