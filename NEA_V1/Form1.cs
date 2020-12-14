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
			drawAxes();
			//pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
		}

		private void btn_submit_Click(object sender, EventArgs e)
		{

			string str = txtBox_input.Text;
			int x = int.Parse(txt_xRange.Text);
			int y = int.Parse(txt_yRange.Text);

			Draw d = new Draw(pictureBox1, str, x, y);
			d.Drawer();
		}

		private void drawAxes()
		{
			//Need a way to make this permanent.
			pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
			Pen pen = new Pen(Color.Black, 3);
			using(var g = Graphics.FromImage(pictureBox1.Image))
			{
				//Drawing Axes
				g.DrawLine(pen, 0, pictureBox1.Height / 2, pictureBox1.Width, pictureBox1.Height / 2);
				g.DrawLine(pen, pictureBox1.Width / 2, 0, pictureBox1.Width / 2, pictureBox1.Height);
				//Draw GridLines
			}
		}

		private void Form1_MouseMove(object sender, MouseEventArgs e)
		{
			lbl_MousePos.Text = (e.Location.X + " : " + e.Location.Y);
		}
	}
}
