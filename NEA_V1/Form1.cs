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
		}

		private void btn_submit_Click(object sender, EventArgs e)
		{

			string str = txtBox_input.Text;

			Tokenizer tokenizer = new Tokenizer(str, 3);

			Parser p = new Parser(tokenizer);
			Console.WriteLine(p.Eval());

		}
	}
}
