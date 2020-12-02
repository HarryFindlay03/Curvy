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
			int x = int.Parse(txt_xRange.Text);
			int y = int.Parse(txt_yRange.Text);

			PointChecker pointCheck = new PointChecker(str, x, y);

			pointCheck.checkPoints();

		}
	}
}
