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
			//drawAxes();
			//pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
		}

		private void btn_submit_Click(object sender, EventArgs e)
		{

			int x = int.Parse(txt_xRange.Text);
			int y = int.Parse(txt_yRange.Text);


			Calc c = new Calc(txtBox_input1.Text);
			c.diff();

			//calls the paint event
			this.Invalidate();


		}

		private void drawAxes(PaintEventArgs e)
		{
			Pen pen = new Pen(Color.Black, 3);
			//Main axes through the centre
			e.Graphics.DrawLine(pen, 0, this.Height / 2, this.Width, this.Height / 2);
			e.Graphics.DrawLine(pen, this.Width / 2, 0, this.Width / 2, this.Height);

			//Smaller sub gridlines
			for(int i = 1; i < 10; i++)
			{
				e.Graphics.DrawLine(Pens.Gray, 0, this.Height / 10 * i, this.Width, this.Height / 10 * i);
				e.Graphics.DrawLine(Pens.Gray, this.Width / 10 * i, 0, this.Width / 10 * i, this.Height);
			}
		}

		private void Form1_MouseMove(object sender, MouseEventArgs e)
		{
			lbl_MousePos.Text = (e.Location.X + " : " + e.Location.Y);
		}

		private void btn_integrate_Click(object sender, EventArgs e)
		{
			int lim1 = int.Parse(txt_lim1.Text);
			int lim2 = int.Parse(txt_lim2.Text);

			Calc c = new Calc(txtBox_input1.Text);
			Console.WriteLine(c.trapeziumIntegrate(lim1, lim2));
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			//this.Paint += Form1_Paint;
		}

		private void Form1_Paint(object sender, PaintEventArgs e)
		{
			drawAxes(e);
			Draw.DrawerTest(e, txtBox_input1.Text, int.Parse(txt_xRange.Text), int.Parse(txt_yRange.Text), this.Width, this.Height);
		}
	}
}
