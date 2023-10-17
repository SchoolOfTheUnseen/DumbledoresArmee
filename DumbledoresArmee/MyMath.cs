using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DumbledoresArmee
{
	public static class MyMath
	{
	}

	public abstract class GeradenGleichungBase
	{
		public static GeradenGleichungBase createGleichung(
			Point p1, Point p2)
		{
			if (p1.X == p2.X)
				return new SenkrechteGerade(p1.X);
			else
			{
				double a = (double)(p2.Y - p1.Y) / (double)(p2.X - p1.X);
				double b = p1.Y - a * p1.X;
				return new GeradenGleichung(a, b);
			}
		}

		public abstract void drawGerade(Graphics g, Rectangle r);
	}

	/// <summary>
	/// Repräsentiert eine nicht-senkrechte Gerade mit der Gleichung y = a*x+b
	/// </summary>
	class GeradenGleichung : GeradenGleichungBase
	{
		double a;
		double b;

		public GeradenGleichung(double a, double b)
		{
			this.a = a;
			this.b = b;
		}

		public override void drawGerade(Graphics g, Rectangle r)
		{
			Brush myBrush = new SolidBrush(Color.Green);
			for (int x = 0; x < r.Right; x++)
			{
				double y = this.a * x + this.b;
				g.FillRectangle(myBrush, x, (int)y, 1, 1);
			}
		}
	}

	class SenkrechteGerade : GeradenGleichungBase
	{
		int x;

		public SenkrechteGerade(int x)
		{
			this.x = x;
		}

		public override void drawGerade(Graphics g, Rectangle r)
		{
			Pen myPen = new Pen(Color.Green);
			g.DrawLine(myPen, this.x, 0, this.x, r.Bottom);
		}
	}
}
