using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace NEA_V1
{
	public class Draw
	{
		public static void DrawerTest(PaintEventArgs e, string eq, int x, int y, int width, int height)
		{
			List<Point> points = new List<Point>();
			PointChecker pc = new PointChecker(eq, x, y);
			points = pc.checkPoints();

			Point centre = new Point(width / 2, height / 2);

			e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

			e.Graphics.ScaleTransform(1.0F, -1.0F);
			e.Graphics.TranslateTransform(0, -height);

			Size s1 = new Size(centre);

			Point p1, p2;
			for(int i = 0; i < points.Count - 1; i++)
			{
				p1 = Point.Add(points[i], s1);
				p2 = Point.Add(points[i + 1], s1);
				e.Graphics.DrawLine(Pens.Red, p1, p2);
			}
		}
	}
}	