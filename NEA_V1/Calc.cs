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
        public Calc(string str)
        {
            this.str = str;
        }

		public double trapeziumIntegrate(int lim1, int lim2)
		{
			//Finding the area under the curve
			//Change to double -> tokenizer recognising decimals. 
			double interval = (double)(lim2 - lim1) / (double)1000;
			List<double> vals = new List<double>();
			for(int i = 1; i <= 1000; i++)
			{
				Parser p = new Parser(new Tokenizer(str, (interval * i)));
				vals.Add(p.Eval());
			}

			double result = 0;
			for(int x = 1; x < vals.Count-2; x++)
			{
				result += vals[x];
			}
			Console.WriteLine(vals[0]);
			double finResult = 0.5 * interval * (vals[0] + vals[vals.Count - 1] + 2 * (result)); //trapezium rule 

			return finResult;
		}
		
    }
}
