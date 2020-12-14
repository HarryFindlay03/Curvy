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
			List<Point> points = pc.checkPoints();
			picBox.Image = new Bitmap(picBox.Width, picBox.Height);
			//Origin Point:
			Point centre = new Point(picBox.Width / 2, picBox.Height / 2);

			using (var g = Graphics.FromImage(picBox.Image))
			{
				//Inverting the y axes
				g.ScaleTransform(1.0F, -1.0F);
				g.TranslateTransform(0, -picBox.Height);
				Pen pen = new Pen(Color.Blue, 2);
				Pen penAxes = new Pen(Color.Black, 2);
				for (int i = 0; i < (points.Count - 1); i++)
				{
					//Temporary to draw lines, need a way to make this permanent when form is loaded and cannot be overrided.
					g.DrawLine(penAxes, 0, picBox.Height / 2, picBox.Width, picBox.Height / 2);
					g.DrawLine(penAxes, picBox.Width / 2, 0, picBox.Width / 2, picBox.Height);
					//
					Size s1 = new Size(centre);
					//Translating Points to the centre.
					Point p1 = Point.Add(points[i], s1);
					Point p2 = Point.Add(points[i + 1], s1);
					g.DrawLine(pen, p1, p2);
					picBox.Refresh();
				}
			}
		}
	}
}