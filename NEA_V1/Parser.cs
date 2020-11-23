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
			/*
			if(myTokenizer.Token == Token.subIn )
			{
				return expression;
			}
			*/
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


}
