using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;

namespace DumbledoresArmee
{
	public static class MyMath
	{
		public static double calcDistance(Point a, Point b)
		{
			int h = a.X - b.X;
			int v = a.Y - b.Y;
			return Math.Sqrt(h * h + v * v);
		}
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

		public abstract QuadratischeGleichung createGleichung(Kreis k);

		public abstract Point getPoint(double x);

		public abstract void showGleichung();
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

		public override QuadratischeGleichung createGleichung(Kreis k)
		{
			double A = (this.a * this.a + 1);
			double B = 2 * this.a * (this.b - k.y) - 2 * k.x;
			double C = k.x * k.x + (b - k.y) * (b - k.y) - k.r * k.r;

			return new QuadratischeGleichung(A, B, C);
		}

		public override Point getPoint(double x)
		{
			double y = this.a * x + this.b;
			return new Point((int)x, (int)y);
		}

		public override void showGleichung()
		{
			MessageBox.Show(this.a.ToString() + " * x + " + this.b.ToString());
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
		public override QuadratischeGleichung createGleichung(Kreis k)
		{
			throw new NotImplementedException();
		}

		public override Point getPoint(double x)
		{
			//UNDONE
			return new Point((int)x, (int)x);
		}

		public override void showGleichung()
		{
			MessageBox.Show("x = " + this.x.ToString());
		}
	}

	public class Kreis
	{
		public double x;
		public double y;
		public double r;

		public Kreis(double x, double y, double r)
		{
			this.x = x;
			this.y = y;
			this.r = r;
		}
	}

	public class QuadratischeGleichung
	{
		public double a;
		public double b;
		public double c;

		public QuadratischeGleichung(double a, double b, double c)
		{
			this.a = a;
			this.b = b;
			this.c = c;
		}

		public List<double> calcLoesungen()
		{
			double diskriminante = this.b * this.b - 4 * this.a * this.c;
			if (diskriminante < 0) //Es gibt keine reelle Lösung
				return new List<double>(0);
			else if (diskriminante == 0) //Genau eine reelle Lösung
			{
				List<double> list = new List<double>(1);
				double x1 = (-this.b) / (2 * this.a);
				list.Add(x1);
				return list;
			}
			else //diskriminante > 0
			{
				//Zwei Lösungen
				List<double> list = new List<double>(2);
				double x1 = (-this.b + Math.Sqrt(diskriminante)) / (2 * this.a);
				list.Add(x1);
				double x2 = (-this.b - Math.Sqrt(diskriminante)) / (2 * this.a);
				list.Add(x2);
				return list;
			}
		}
	}
}
