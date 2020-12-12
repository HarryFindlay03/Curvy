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

		public double Eval()
		{
			double l, r, ans;
			Stack<double> result = new Stack<double>();

			for(int i = 0; i < tokens.Count; i++)
			{
				string c = tokens[i].Type;
				if(c == "*")
				{
					l = result.Pop();
					r = result.Pop();
					ans = l * r;
					result.Push(ans);
				}
				else if (c == "/")
				{
					l = result.Pop();
					r = result.Pop();
					ans = l / r;
					result.Push(ans);
				}
				else if (c == "+")
				{
					l = result.Pop();
					r = result.Pop();
					ans = l + r;
					result.Push(ans);
				}
				else if (c == "-")
				{
					l = result.Pop();
					r = result.Pop();
					ans = l - r;
					result.Push(ans);
				}
				else if(c == "^")
				{
					l = result.Pop();
					r = result.Pop();
					ans = Math.Pow(l, r);
					result.Push(ans);
				}
				else //is a number
				{
					result.Push(tokens[i].Data);
				}
			}

			return result.Pop();
		}
	}   
}
