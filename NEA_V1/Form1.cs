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

			Tokenizer tokenizer = new Tokenizer(str);


			Parser p = new Parser(tokenizer);
			double result = p.Eval();
			Console.WriteLine(result);
	
			/*
			PointChecker pCheck;
			if (String.IsNullOrEmpty(txt_xRange.Text) || String.IsNullOrEmpty(txt_yRange.Text))
			{
				pCheck = new PointChecker(str);
			}
			else
			{
				int xRange = int.Parse(txt_xRange.Text);
				int yRange = int.Parse(txt_yRange.Text);
				pCheck = new PointChecker(str, xRange, yRange);
			}

			pCheck.checkPoints();
			*/
		}
	}
}
