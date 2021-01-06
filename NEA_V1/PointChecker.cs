using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace NEA_V1
{
	class PointChecker
	{
		String myString;
		int xRange;
		int yRange;
	
		//Very basic for now, only an expression and a y value. <-
		public PointChecker(string str, int x, int y)
		{
			myString = str;
			xRange = x;
			yRange = y;
		}
		
		public List<Point> checkPoints()
		{
			List<Point> onLine = new List<Point>(); //Need a dynamic size hence why using a list. 

			//The coordinates used to loop through will eventually be linked to a scale so they can be drawn!
			int arrTemp = 0;
			for (int x = -xRange; x < xRange; x++)
			{
				//x value being the setSubinval
				Parser p = new Parser(new Tokenizer(myString, x));
				double temp = p.Eval();
				for(int y = -yRange; y < yRange; y++)
				{
					if(temp == y)
					{
						//Console.WriteLine("Point ({0}, {1}) is on the curve.", x, y);
						onLine.Add(new Point(x, y)); 
						arrTemp++;
					}
				}
				
			}
			return onLine;   
		}
		
	}

}
