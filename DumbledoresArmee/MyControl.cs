using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace DumbledoresArmee
{
	public abstract class MyControl
	{
		/// <summary>
		/// Entspricht dem Abstand zwischen dem linken Rand des Steuerelements und dem linken Rand des Clientbereichs 
		/// des zugehörigen Containers in Pixel
		/// </summary>
		private int _Left;
		/// <summary>
		/// Eigenschaft für den Left-Wert
		/// </summary>
		public int Left
		{
			get
			{
				return _Left;
			}
			set
			{
				if (_Left != value)
				{
					this._Left = value;
					EventArgs e = new EventArgs();
					if (this.LocationChanged != null)
						this.LocationChanged(this, e);
				}
			}
		}

		/// <summary>
		/// Entspricht dem Abstand zwischen dem oberen Rand des Steuerelements und dem oberen Rand des Clientbereichs 
		/// des zugehörigen Containers in Pixel
		/// </summary>
		private int _Top;
		/// <summary>
		/// Eigenschaft für den Top-Wert
		/// </summary>
		public int Top
		{
			get
			{
				return _Top;
			}
			set
			{
				if (_Top != value)
				{
					this._Top = value;
					EventArgs e = new EventArgs();
					if (this.LocationChanged != null)
						this.LocationChanged(this, e);
				}
			}
		}

		/// <summary>
		/// Die Breite dieses Steuerelements
		/// </summary>
		private int _Width;
		/// <summary>
		/// Eigenschaft für die Breite
		/// </summary>
		public int Width
		{
			get
			{
				return _Width;
			}
			set
			{
				this._Width = value;
			}
		}

		/// <summary>
		/// Die Höhe dieses Steuerelements
		/// </summary>
		private int _Height;
		/// <summary>
		/// Eigenschaft für die Höhe
		/// </summary>
		public int Height
		{
			get
			{
				return _Height;
			}
			set
			{
				this._Height = value;
			}
		}

		/// <summary>
		/// Eigenschaft für die rechte Begrenzung dieses Steuerelements
		/// </summary>
		public int Right
		{
			get
			{
				return this.Left + this.Width;
			}
			set
			{
				this.Left = value - this.Width;
			}
		}

		/// <summary>
		/// Eigenschaft für die untere Begrenzung dieses Steuerelements
		/// </summary>
		public int Bottom
		{
			get
			{
				return this.Top + this.Height;
			}
			set
			{
				this.Top = value - this.Height;
			}
		}

		/// <summary>
		/// Das Control, auf dem dieses Steuerelement dargestellt wird
		/// </summary>
		private Control _Parent;
		/// <summary>
		/// Eigenschaft für den Parent
		/// </summary>
		public Control Parent
		{
			get
			{
				return _Parent;
			}
			set
			{
				//Dieses Control auf dem alten Parent "löschen"
				if (this._Parent != null)
				{
					Rectangle r = new Rectangle(
						this.Left, this.Top, this.Width, this.Height);
					this._Parent.Invalidate(r);
				}

				this._Parent = value;
				if (this._Parent != null)
				{
					Graphics g = this._Parent.CreateGraphics();
					this.drawControl(g);
				}
			}
		}

		public MyControl(Control par = null)
		{
			this._Parent= par;
			if (par != null)
			{
				Graphics g = par.CreateGraphics();
				this.drawControl(g);
			}
		}

		public delegate void delegateLocation(object sender, EventArgs e);
		public event delegateLocation LocationChanged;

		public abstract void drawControl(Graphics g);

		public bool isInsideControl(int x, int y)
		{
			return true;
		}
	}

	public class MyKnotenVisual : MyControl
	{
		public MyKnotenVisual(int x, int y, Control parent)
			//base(parent)
		{
			this.Left = x;
			this.Top = y;
			this.Width = 40;
			this.Height = 40;
			this.Parent = parent;
			this.Parent.Paint += Parent_Paint;
		}

		private void Parent_Paint(object? sender, PaintEventArgs e)
		{
			drawControl(e.Graphics);
		}

		public override void drawControl(Graphics g)
		{
			Pen myPen = new Pen(Color.Black);
			//Graphics g = e.Graphics;

			for (int i = 0; i < 5; i++)
				g.DrawEllipse(myPen, i + this.Left, i + this.Top,
					40 - 1 - 2 * i, 40 - 1 - 2 * i);

			Font font = new Font("Times New Roman", 14);
			Brush myBrush = new SolidBrush(Color.Black);
			Rectangle rect = new Rectangle(
				this.Left, this.Top, this.Width, this.Height);
			StringFormat fo = new StringFormat();
			fo.Alignment = StringAlignment.Center;
			fo.LineAlignment = StringAlignment.Center;
			g.DrawString("A", font, myBrush, rect, fo);
		}

		public Point calcCenter()
		{
			int x = this.Left + (this.Width / 2);
			int y = this.Top + (this.Height / 2);
			return new Point(x, y);
		}

		public static GeradenGleichungBase createGleichung(
			MyKnotenVisual a, MyKnotenVisual b)
		{
			Point p1 = a.calcCenter();
			Point p2 = b.calcCenter();
			return GeradenGleichungBase.createGleichung(p1, p2);
		}

		public static List<Point> calcSchnittpunkte(
			MyKnotenVisual a, MyKnotenVisual b)
		{
			GeradenGleichungBase gerade = createGleichung(a, b);
			//gerade.showGleichung();

			int r = a.Width / 2;
			Kreis A = new Kreis(a.Left + r, a.Top + r, r);
			QuadratischeGleichung gleichungA = gerade.createGleichung(A);
			Kreis B = new Kreis(b.Left + r, b.Top + r, r);
			QuadratischeGleichung gleichungB = gerade.createGleichung(B);

			List<Point> result = new List<Point>(4);

			List<double> lA = gleichungA.calcLoesungen();
			for (int  i = 0; i < lA.Count; i++)
			{
				double x = lA[i];
				Point p = gerade.getPoint(x);
				result.Add(p);
			}

			List<double> lB = gleichungB.calcLoesungen();
			for (int i = 0; i < lB.Count; i++)
			{
				double x = lB[i];
				Point p = gerade.getPoint(x);
				result.Add(p);
			}

			return result;
		}

		private static Point findNearest(Point a, Point b, Point center)
		{
			double da = MyMath.calcDistance(a, center);
			double db = MyMath.calcDistance(b, center);
			if (da < db)
				return a;
			else
				return b;
		}

		private static Point createNearestPoint(double solution1, double solution2,
			GeradenGleichungBase gerade, Point center)
		{
			Point p1 = gerade.getPoint(solution1);
			Point p2 = gerade.getPoint(solution2);
			return findNearest(p1, p2, center);
		}

		public static List<Point> calcConnectionPoints(
			MyKnotenVisual a, MyKnotenVisual b)
		{
			GeradenGleichungBase gerade = createGleichung(a, b);
			//gerade.showGleichung();

			int r = a.Width / 2;
			Kreis A = new Kreis(a.Left + r, a.Top + r, r);
			QuadratischeGleichung gleichungA = gerade.createGleichung(A);
			Kreis B = new Kreis(b.Left + r, b.Top + r, r);
			QuadratischeGleichung gleichungB = gerade.createGleichung(B);

			List<Point> result = new List<Point>(4);

			List<double> lA = gleichungA.calcLoesungen();
			//for (int i = 0; i < lA.Count; i++)
			//{
			//	double x = lA[i];
			//	Point p = gerade.getPoint(x);
			//	result.Add(p);
			//}
			Point center1 = b.calcCenter();
			Point p1 = createNearestPoint(lA[0], lA[1], gerade, center1);
			result.Add(p1);

			List<double> lB = gleichungB.calcLoesungen();
			//for (int i = 0; i < lB.Count; i++)
			//{
			//	double x = lB[i];
			//	Point p = gerade.getPoint(x);
			//	result.Add(p);
			//}
			Point center2 = a.calcCenter();
			Point p2 = createNearestPoint(lB[0], lB[1], gerade, center2);
			result.Add(p2);

			return result;
		}

	}

	public class MyKante : MyControl
	{
		MyKnotenVisual Start;
		MyKnotenVisual End;

		public MyKante(MyKnotenVisual from, MyKnotenVisual to)
		{
			this.Start = from;
			this.End = to;
			from.LocationChanged += LocationChanged;
			to.LocationChanged += LocationChanged;
		}

		private void LocationChanged(object sender, EventArgs e)
		{
			Graphics g = this.Parent.CreateGraphics();
			this.drawControl(g);
		}

		public override void drawControl(Graphics g)
		{
			Pen myPen = new Pen(Color.Black);
			myPen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
			myPen.Width = 5;
			List<Point> liste = MyKnotenVisual.calcConnectionPoints(this.Start, this.End);
			g.DrawLine(myPen, liste[0], liste[1]);
		}
	}
} //Ende namespace DumbledoresArmee
