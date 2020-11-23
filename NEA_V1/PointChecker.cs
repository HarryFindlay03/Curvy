using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NEA_V1
{
    
    class PointChecker
    {
        string myStr;
        int xRange;
        int yRange;
    
        //Very basic for now, only an expression and a y value. <-
        public PointChecker(string str, int x, int y)
        {
            myStr = str;
            xRange = x;
            yRange = y;
        }
        public PointChecker(string str)
        {
            //Default values for x and y range
            myStr = str;
            xRange = 100;
            yRange = 100;
        }

        public int[,] checkPoints()
        {
            int[,] onLine = new int[100, 100];
            Tokenizer myTokenizer = new Tokenizer(myStr);

            //The coordinates used to loop through will eventually be linked to a scale so they can be drawn!
            int arrTemp = 0;
            for(int x = 0; x < xRange; x++)
            {
                //x value being the setSubinval
                double temp = Parser.Parse(myStr, x).Eval();
             
                for(int y = 0; y < yRange; y++)
                {
                    if(temp == y)
                    {
                        Console.WriteLine("Point ({0}, {1}) is on the curve.", x, y);
                        onLine[arrTemp, 0] = x;
                        onLine[arrTemp, 1] = y;
                        arrTemp++;
                    }
                }
                
            }
            return onLine;

            /*
            How the above bit of code works. 
            y = 2x

            1 = 2(1) = false
            1 = 2(2) = false
            ...
            1 = 2(100) = false
            2 = 2(1) - true
            */
        }
    }
}
