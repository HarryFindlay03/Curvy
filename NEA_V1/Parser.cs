using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NEA_V1
{
    public class Node
    {
        public Token Data;
        public Node Left;
        public Node Right;

        public Node()
        {

        }
        public Node(Token data)
        {
            this.Data = data;
        }
    }

    public class Parser
    {
        Stack<Token> myTokens;
		List<double> numbers;

		public Parser(Tokenizer tokenizer)
        {
            myTokens = tokenizer.getTokens();
			numbers = tokenizer.getNumbers(); //List of numbers in the correct order with the operations.
		}

		
		public double Eval()
		{
			Stack<double> resultStack = new Stack<double>();
			int temp = 0; //keeping track of where the numbers are
			double finalResult = 0;
			while(myTokens.Count > 0)
			{
				if(Tokenizer.returnType(myTokens.Peek()) == Token.Number)
				{
					double firstNum = numbers[temp];
					myTokens.Pop();
					temp++;
					double secNum = numbers[temp];
					myTokens.Pop();
					temp++;
					Token op = myTokens.Pop(); //need to add in validation
					if(op == Token.Add)
					{
						double result = firstNum + secNum;
						resultStack.Push(result);
					}
					else if(op == Token.Subtract)
					{
						double result = secNum - firstNum;
						resultStack.Push(result);
					}
					else if (op == Token.Times)
					{
						double result = firstNum * secNum;
						resultStack.Push(result);
					}
					else if (op == Token.Divide)
					{
						double result = secNum / firstNum;
						resultStack.Push(result);
					}
				}
				else if(Tokenizer.returnType(myTokens.Peek()) == Token.Operator)
				{
					double firstVal = 0;
					double secondVal = 0;
					Token op = myTokens.Pop();
					if (op == Token.Add)
					{
						firstVal = resultStack.Pop();
						secondVal = resultStack.Pop();
						finalResult = firstVal + secondVal;
					}
					else if (op == Token.Subtract)
					{
						firstVal = resultStack.Pop();
						secondVal = resultStack.Pop();
						finalResult = firstVal - secondVal;
					}
					else if (op == Token.Times)
					{
						firstVal = resultStack.Pop();
						secondVal = resultStack.Pop();
						finalResult = firstVal * secondVal;
					}
					else if (op == Token.Divide)
					{
						firstVal = resultStack.Pop();
						secondVal = resultStack.Pop();
						finalResult = firstVal / secondVal;
					}
				}
			}
			return finalResult;
		}
    }



    /*
	public class Parser
	{
		Tokenizer myTokenizer;
		public Parser(Tokenizer tokenizer, double setVal)
		{
			myTokenizer = tokenizer;
			myTokenizer.setSubInVal(setVal);
		}

		public Parser(Tokenizer tokenizer)
		{
			myTokenizer = tokenizer;
		}

		public Node ParseLeaf()
		{
			if(myTokenizer.Token == Token.Number)
			{
				var num = new NodeNumber(myTokenizer.getNumber);
				myTokenizer.NextToken();
				return num;
			}
			if(myTokenizer.Token == Token.subIn)
			{
				var num = new NodeNumber(myTokenizer.getSubInVal());
				myTokenizer.NextToken();
				return num;
			}
			if(myTokenizer.Token == Token.yVal)
			{
				myTokenizer.NextToken();
			}
			//This will change, needs to take into fact the exponent operator (if(myTokenizer.Token == Token.Exponent))...same for subIn Token.
			throw new Exception($"Unexpected Token: {myTokenizer.Token}");
		}

		public Node ParseNodes()
		{
			var lhs = ParseLeaf();
			//there is an operator found

			while (true)
			{
				Func<double, double, double> op = null;

				if (myTokenizer.Token == Token.Add)
				{
					op = (a, b) => a + b;
				}
				else if (myTokenizer.Token == Token.Subtract)
				{
					op = (a, b) => a - b;
				}
				else if (myTokenizer.Token == Token.Times)
				{
					op = (a, b) => a * b;
				}
				else if (myTokenizer.Token == Token.Divide)
				{
					op = (a, b) => a / b;
				}
                else if(myTokenizer.Token == Token.Exponent)
                {
                    op = (a, b) => a * a;
                }
				//Has an operator been found?
				if (op == null)
				{
					//No one has not been found
					return lhs;
				}
				//skip the operator
				myTokenizer.NextToken();
				
				var rhs = ParseLeaf();
				lhs = new NodeFunctions(lhs, rhs, op);
				
			}
		}

		public Node ParseExpression()
		{
			var expression = ParseNodes();
			//Commented 
			if(myTokenizer.Token == Token.subIn )
			{
				return expression;
			}
			//commented 
			if(myTokenizer.Token != Token.EOF)
			{
				throw new Exception($"Unexpected Characters at the end of expression!");
			}

			return expression;
		}

		public static Node Parse(string str, double setVal)
		{
			var myParser = new Parser(new Tokenizer(str), setVal);
			return myParser.ParseExpression();
		}

		public static Node Parse(Tokenizer tokenizer, double setVal)
		{
			var myParser = new Parser(tokenizer, setVal);
			return myParser.ParseExpression();
		}
	}
    

	public abstract class Node
	{
		public abstract double Eval();
	}
	
	public class NodeNumber : Node
	{
		double myNumber;
		public NodeNumber(double number)
		{
			myNumber = number;
		}

		public override double Eval()
		{
			return myNumber;
		}
	}

	public class NodeFunctions : Node
	{
		Node myLhs;
		Node myRhs;

		Func<double, double, double> myOperator;

		public NodeFunctions(Node lhs, Node rhs, Func<double, double, double> op)
		{
			myLhs = lhs;
			myRhs = rhs;
			myOperator = op;
		}

		public override double Eval()
		{
			var lhsVal = myLhs.Eval();
			var rhsVal = myRhs.Eval();
			var result = myOperator(lhsVal, rhsVal);

			return result;
		}
	}
    */

    

}
