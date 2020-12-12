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

			Parser p = new Parser(new Tokenizer(str));
			Console.WriteLine("Final Result: " + p.Eval());
		}

		private void Form1_Paint(object sender, PaintEventArgs e)
		{
			//Drawing the x and y axes
			//Origin = 800,400
			Pen startPen = new Pen(Color.Black, 3);
			e.Graphics.DrawLine(startPen, 500, 400, 1100, 400);
			e.Graphics.DrawLine(startPen, 800, 100, 800, 700);
		}

		private void Form1_MouseMove(object sender, MouseEventArgs e)
		{
			lbl_MousePos.Text = (e.Location.X + " : " + e.Location.Y);
		}
	}
}
