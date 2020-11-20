using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NEA_V1
{
	public enum Token
	{
        Empty,
		EOF,
		Number,
		Add,
		Subtract,
		Times,
		Divide,
		subIn,
		yVal,
		Equals,
		Exponent
	}
	
	public class Tokenizer
	{
		TextReader myReader;
		char currentChar;
		Token currentToken = Token.Empty;
		double number;

		double testVal = 0;

		public Tokenizer(TextReader reader)
		{
			myReader = reader;
			NextChar();
			NextToken();
		}

		public Token Token
		{
			get { return currentToken; }
		}

		public double getNumber
		{
			get { return number; }
		}

		public double getSubInVal()
		{
			return testVal;
		}

		public double setSubInVal(double num)
		{
			testVal = num;
			return testVal;
		}

		public void NextChar()
		{
			int character = myReader.Read();
			if(character < 0)
			{
				currentChar = '\0';
			}
			else
			{
				currentChar = (char)character;
			}
		}

		public void NextToken()
		{
			while (char.IsWhiteSpace(currentChar))
			{
				NextChar();
			}

			switch (currentChar)
			{
				case '\0':
					currentToken = Token.EOF;
					return;
				case '+':
					NextChar();
					currentToken = Token.Add;
					return;
				case '-':
					NextChar();
					currentToken = Token.Subtract;
					return;
				case '*':
					NextChar();
					currentToken = Token.Times;
					return;
				case '/':
					NextChar();
					currentToken = Token.Divide;
					return;
				case 'x':
					NextChar();
					currentToken = Token.subIn; //need to create subIn as a number then I can substitute in other numbers into it by replacing it (-number + newNumber)
					return;
				case 'y':
					NextChar();
					currentToken = Token.subIn;
					return;
				case '=':
					NextChar();
					currentToken = Token.Equals;
					return;
				case '^':
					NextChar();
					currentToken = Token.Exponent;
					return;
			}

			if(char.IsDigit(currentChar) || currentChar == '.')
			{
				//If nextchar is then equal to x then shove a times in the middle. 
				var sb = new StringBuilder();
				bool hasDecPoint = false;
				while (char.IsDigit(currentChar) || (!hasDecPoint && currentChar == '.'))
				{
					sb.Append(currentChar);
					hasDecPoint = currentChar == '.';
					NextChar();
				}
				number = double.Parse(sb.ToString());
				currentToken = Token.Number;
				return;
			}

			throw new InvalidDataException($"Unexcpected Character:{currentChar}");
		}

        public List<Token> ReturnTokens()
        {
            List<Token> tokens = new List<Token>();
            while(currentChar != '\0')
            {
                tokens.Add(currentToken);
                NextToken();
            }
            tokens.Add(currentToken);
            return tokens;
        }
	   
	}
	
}
