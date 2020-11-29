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
			double result = 0; //Temp result that is used when operating on the operands
			double finalResult = 0; //Result that is going to be returned
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
					val1 = tokenizerNumbers[temp];
					temp++;
					val2 = tokenizerNumbers[temp];
					temp++;
					switch (tempOp)
					{
						case Token.Add:
							result = val1 + val2;
							break;
						case Token.Subtract:
							result = val1 - val2;
							break;
						case Token.Times:
							result = val1 * val2;
							break;
						case Token.Divide:
							result = val1 / val2;
							break;
						case Token.Exponent:
							result = Math.Pow(val1, val2);
							break;
					}
					results.Add(result);
				}
			}
			if(finalOperators.Count > 0)
			{
				//Will have to check if * is final operator as finalresult cannot start as 0. 
				for(int i = 0; i < finalOperators.Count; i++)
				{
					if(finalOperators[i] == Token.Add)
					{
;						finalResult += (results[i] + results[i + 1]); 
						//Value for final result will not work when we have more than 2 values in results...
						//They need their own temp int to loop through, otherwise next i == i+1.
					}
					if (finalOperators[i] == Token.Subtract)
					{
						finalResult += (results[i] - results[i + 1]);
					}
				}
			}
			return finalResult;
		}
	}   

}
