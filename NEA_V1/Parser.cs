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
			bool tempAdd = true; //So result doesn't become 1 for each time multiple suims are added together 
			int i = 0;
			int j = 0;
			int x = 0;
			while(tokens.Count > 0)
			{
				if(Tokenizer.returnType(tokens.Peek()) == Token.Operator)
				{
					op = tokens.Pop();
					if(doubleOP == true)
					{
						if(tempStack.Count > 0)
						{
							resultTemp.Push(tempStack.Pop());
						}

						j = 0;
						doubleOP = false;
						while(resultTemp.Count > 0)
						{
							if(op == Token.Add)
							{
								j=1;
								finalresult += resultTemp.Pop();
							}
							if(op == Token.Times)
							{
								finalresult *= resultTemp.Pop();
							}
						}
						if(j == 1)
						{
							result = finalresult - 1;
						}
						else
						{
							result = finalresult;
						}
					}
					else
					{
						while (x < 2)
						{
							//Only pop 2 values off the stack unless empty then break.
							if (tempStack.Count == 0) break; 
							x++; 

							double tempVal = tempStack.Pop();
							if (op == Token.Add)
							{
								result = result + tempVal;
								if (j == 0)
								{
									result = result - 1;
								}
							}
							else if(op == Token.Subtract)
							{
								//Needs to be finished
							}
							else if(op == Token.Times)
							{
								//When there are more (2*5+3*5+4*5) This breaks. 
								//This should be easy to fix, just need to check the double op functions.
								//Check the postfix class to see how the tokens returns.
								if (j > 1 && tempAdd == true)
								{
									Console.WriteLine("test");
									tempAdd = false;
									result = 1;
								}
								result = result * tempVal;
							}
							else if(op == Token.Divide)
							{
								//Needs to be finsihed
							}
							else if(op == Token.Exponent)
							{
								x = 2;
								if(j == 0)
								{
									result = tempVal;
									result = Math.Pow(tempStack.Pop(), result);
								}
							}
							j++;
						}
						resultTemp.Push(result);
					}
					doubleOP = true;
					x = 0;
					//For adding times it is still using the same result I need to figure out a way to stop this 
				}
				else if(Tokenizer.returnType(tokens.Peek()) == Token.Number)
				{
					doubleOP = false;
					while (tokens.Peek() == Token.Number)
					{
						tokens.Pop();
						tempStack.Push(tokenizerNumbers[i]);
						i++;
					}
					//If the number of numbers is odd then do not reset result to 1 in the times statement.
					//It has to be reset to 1 for 2*5+4*5 otherwise the second value on finaltemp will be incorrect
					if(i % 2 != 0)
					{
						tempAdd = false;
					}
				}
			}

			return result;
		}
	}   
}
