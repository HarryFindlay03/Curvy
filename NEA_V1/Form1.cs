using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace NEA_V1
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			//pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
		}

		private void btn_submit_Click(object sender, EventArgs e)
		{

			string str = txtBox_input.Text;
			int x = int.Parse(txt_xRange.Text);
			int y = int.Parse(txt_yRange.Text);

			//Stack<string> stack = InfixToPostfix.infixToPostfix(str);

			//while(stack.Count > 0)
			//{
				//Console.WriteLine(stack.Pop());
			//}

			Parser p = new Parser(new Tokenizer(str));
			Console.WriteLine(p.Eval());

			//Draw d = new Draw(pictureBox1, str, x, y);
			//d.Drawer();
		}
	}
}
