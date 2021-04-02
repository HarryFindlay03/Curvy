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
		PictureBox picBox;
		List<string> equations;
		int x, y;

		public Draw(PictureBox picBox, List<string> equations, int x, int y)
		{
			this.picBox = picBox;
			this.x = x;
			this.y = y;
			this.equations = equations; //get a list of all the point arrays and draw the lines using this.
		}
		
		public void Drawer()
		{
			List<List<Point>> points = new List<List<Point>>(); //List of point lists created by point checker.
			for(int i = 0; i < equations.Count; i++)
			{
				PointChecker pc = new PointChecker(equations[i], x, y);
				points.Add(pc.checkPoints());
			}

			Bitmap bmp = new Bitmap(@"E:\Main Files\School\Computer Science\NEA\NEA Upload\NEA_V1\NEA_V1\NEA_V1\temp\temp.bmp"); //Needs to just be the root. 
			picBox.Image = bmp; //new Bitmap(picBox.Width, picBox.Height);
			//Origin Point:
			Point centre = new Point(picBox.Width / 2, picBox.Height / 2);

			using (var g = Graphics.FromImage(bmp))
			{
				g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
				//Inverting the y axes
				g.ScaleTransform(1.0F, -1.0F);
				g.TranslateTransform(0, -picBox.Height);
				Pen pen = new Pen(Color.Blue, 2);
				Pen penAxes = new Pen(Color.Black, 2);

				for(int j = 0; j <= points.Count - 1; j++)
				{
					for(int i = 0; i < (points[j].Count - 1); i++)
					{
						Size s1 = new Size(centre); //Translating the points to the centre
						Point p1 = Point.Add(points[j][i], s1);
						Point p2 = Point.Add(points[j][i + 1], s1);
						g.DrawLine(pen, p1, p2);
					}
				}
			}
		}
	}
}