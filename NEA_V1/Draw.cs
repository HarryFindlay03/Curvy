using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace NEA_V1
{
	public class Draw
	{
		PictureBox picBox;
		string str;
		int x, y;

		public Draw(PictureBox picBox, string str, int x, int y)
		{
			this.picBox = picBox;
			this.str = str;
			this.x = x;
			this.y = y;
		}

		public void Drawer()
		{
			PointChecker pc = new PointChecker(str, x, y);
			Point[] points = pc.checkPoints();
			picBox.Image = new Bitmap(picBox.Width, picBox.Height);

			using (var g = Graphics.FromImage(picBox.Image))
			{
				Pen pen = new Pen(Color.Red, 3);
				for (int i = 0; i < (points.Length - 1); i++)
				{
					Point p1 = points[i];
					Point p2 = points[i + 1];
					g.DrawLine(pen, p1, p2);
					picBox.Refresh();
				}
			}
		}
	}
}
