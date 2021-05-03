using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEA_V1
{
    class Calc
    {
        string str;
        List<string> tokens;
        public Calc(string str)
        {
            this.str = str;
			tokens = new List<string>();
			tokenize();
        }


        private void tokenize()
        {
			//Have to tokenize the string, as the tokenizer tokenizes after putting string into postfix.
			//Postfix notation makes it very tricky to find the numbers we need.
			var delimiters = new[] { '+', '-', '*', '/', '=', '^', '(', ')', 'x', 'y' };
			string buffer = string.Empty;
			foreach (var c in str)
			{
				if (delimiters.Contains(c))
				{
					if (buffer.Length > 0) tokens.Add(buffer);
					tokens.Add(c.ToString());
					buffer = string.Empty;
				}
				else
				{
					buffer += c;
				}
			}
			tokens.Add(buffer); //Adding the last number if there is one.
		}
		
		public string diff()
		{
			int pos = tokens.IndexOf("x");
			List<string> rList = tokens.GetRange(pos, (tokens.Count - pos));

			//Copy over the right side of the list to a new list. Find the first number.
			//Find the number before the x.
			//Times numbers from right and left side. Then -1 from number on the right side./

			return "";
		}

		public double trapeziumIntegrate(int lim1, int lim2)
		{
			//Finding the area under the curve
			//Change to double -> tokenizer recognising decimals. 
			int interval = (lim2 - lim1) / 10;
			List<double> vals = new List<double>();
			for(int i = 0; i <= 10; i++)
			{
				Parser p = new Parser(new Tokenizer(str, (interval * i)));
				vals.Add(p.Eval());
			}

			double result = 0;
			for(int x = 1; x < vals.Count-1; x++)
			{
				result = result + vals[x];
			}
			double finResult = 0.5 * interval * (vals[0] + vals[vals.Count - 1] + 2 * (result)); //trapezium rule 

			return finResult;
		}
		
    }
}
