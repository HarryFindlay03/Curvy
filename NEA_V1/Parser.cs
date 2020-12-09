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
		List<Token> tokens;
		public Parser(Tokenizer tokenizer)
		{
			tokens = tokenizer.getTokens();
		}


		//Issue if there is a double op I cannot use the result double as this makes it way too large. 
		public double Eval()
		{
			Stack<double> numbers = new Stack<double>();
			Stack<double> finalNumbers = new Stack<double>();
			double result = 1;
			double doubleResult = 1;
			double prevResult = 1;
			bool doubleOp = false;
			bool doubleRan = false;
			bool addition = false;


			for (int pos = 0; pos < tokens.Count; pos++)
			{
				if (Tokenizer.isOp(tokens[pos]) == true) //if current pos is operator
				{
					string op = tokens[pos].Type;
					if (op == "+") addition = true;
					if (pos > 2) addition = false;
					while (numbers.Count > 0)
					{
						double tempVal = numbers.Pop();
						if (op == "+")
						{
							result += tempVal; //Used when there are not multiple operations
							prevResult += tempVal; 
						}
						if(op == "*")
						{
							result *= tempVal;
							prevResult *= tempVal;
						}
					}
					if (addition == true)
					{
						prevResult -= 1;
						result -= 1;
					}
					finalNumbers.Push(prevResult);
					prevResult = 1; //Reset so when adding multiple multiplications it does not get exponentially bigger. 
					addition = false;

					//Checking if the next token is an operator, and if so operating on the values in the finalNumbers stack4
					try
					{
						if (Tokenizer.isOp(tokens[pos + 1]) == true)
						{
							doubleOp = true;
							pos++;
							op = tokens[pos].Type;
							double temp = 0;
							if (op == "+") addition = true;
							while (finalNumbers.Count > 0)
							{
								double tempVal = finalNumbers.Pop();
								if (op == "+")
								{
									temp += tempVal;
								}
							}
							//Having to use a different result value as if result is used then it will still have the values of ALL the multiplications within it
							doubleResult += temp;
							if(addition == true && doubleRan == false)
							{
								doubleResult -= 1;
							}
							doubleRan = true;
						}
					}
					catch
					{
						break; //This needs to be updated to stop using this really 
					}
				}
				//Adding numbers onto the temp stack to be dealt with
				if (tokens[pos].Type == "Number")
				{
					numbers.Push(tokens[pos].Data);
				}
			}
			//Returning depening on what type of operations had to take place
			if (doubleOp == true)
			{
				return doubleResult;
			}
			else
			{
				return result;
			}
		}
	}   
}
