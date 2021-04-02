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
			List<string> strs = new List<string>();

			int x = int.Parse(txt_xRange.Text);
			int y = int.Parse(txt_yRange.Text);

			//****Check if the text box is not empty if so -> add the text of textbox to the strs List.****

			if(!string.IsNullOrEmpty(txtBox_input1.Text))
			{
				strs.Add(txtBox_input1.Text);
			}
			if (!string.IsNullOrEmpty(txtBox_input2.Text))
			{
				strs.Add(txtBox_input2.Text);
			}
			if (!string.IsNullOrEmpty(txtBox_input3.Text))
			{
				strs.Add(txtBox_input3.Text);
			}
			if (!string.IsNullOrEmpty(txtBox_input4.Text))
			{
				strs.Add(txtBox_input4.Text);
			}

			Calc c = new Calc(strs[0]);
			c.diff();

			Draw d = new Draw(pictureBox1, strs, x, y);
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
			Bitmap bmp = new Bitmap(pictureBox1.ClientSize.Width, pictureBox1.ClientSize.Height);
			pictureBox1.DrawToBitmap(bmp, pictureBox1.ClientRectangle);
			bmp.Save(@"E:\Main Files\School\Computer Science\NEA\NEA Upload\NEA_V1\NEA_V1\NEA_V1\temp\temp.bmp");
			bmp.Dispose();
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
	}
}
