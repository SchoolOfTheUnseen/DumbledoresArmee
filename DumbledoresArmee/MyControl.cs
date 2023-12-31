﻿using System;
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
					LocationChangedArgs e = new LocationChangedArgs(
						this._Left, this._Top);
					this._Left = value;
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
					LocationChangedArgs e = new LocationChangedArgs(
						this._Left, this._Top);
					this._Top = value;
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
					this.Parent.Paint += Parent_Paint;
				}
			}
		}

		private Color _BackColor;
		public Color BackColor
		{
			get
			{
				return this._BackColor;
			}
			set
			{
				this._BackColor = value;
			}
		}

		public MyControl(Control par = null)
		{
			this._Parent= par;
			if (par != null)
			{
				this._BackColor= par.BackColor;
				Graphics g = par.CreateGraphics();
				this.drawControl(g);
			}
			this.LocationChanged += MyControl_LocationChanged;
		}

		private void MyControl_LocationChanged(object sender, LocationChangedArgs e)
		{
			if (this.Parent != null)
			{
				Rectangle r = new Rectangle(
					e.oldLeft, e.oldTop, this._Width, this._Height);
				this.Parent.Invalidate(r);

				Graphics g = this.Parent.CreateGraphics();
				this.drawControl(g);
			}
		}

		public delegate void delegateLocation(object sender, LocationChangedArgs e);
		public event delegateLocation LocationChanged;

		public abstract void drawControl(Graphics g);

		public bool isInsideControl(int x, int y)
		{
			return true;
		}

		protected void drawBackGround(Graphics g)
		{
			SolidBrush myBrush = new SolidBrush(this.BackColor);
			Rectangle r = new Rectangle(this.Left, this.Top, this._Width, this._Height);
			g.FillRectangle(myBrush, r);
		}

		private void Parent_Paint(object? sender, PaintEventArgs e)
		{
			drawControl(e.Graphics);
		}
	}

	public class LocationChangedArgs : EventArgs
	{
		private int _oldLeft;

		public int oldLeft
		{
			get
			{
				return this._oldLeft;
			}
		}

		private int _oldTop;

		public int oldTop
		{
			get
			{
				return this._oldTop;
			}
		}

		public LocationChangedArgs(int oldLeft, int oldTop)
		{
			this._oldLeft = oldLeft;
			this._oldTop = oldTop;
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

		protected virtual Color getBorderColor()
		{
			return Color.Black;
		}

		protected virtual int getBorderWidth()
		{
			return 5;
		}

		protected void drawBorder(Graphics g)
		{
			Color c = getBorderColor();
			Pen myPen = new Pen(c);

			//for (int i = 0; i < 5; i++)
			//	g.DrawEllipse(myPen, i + this.Left, i + this.Top,
			//		40 - 1 - 2 * i, 40 - 1 - 2 * i);
			int w = this.getBorderWidth();
			for (int i = 0; i < w; i++)
				g.DrawEllipse(myPen, i + this.Left, i + this.Top,
					40 - 1 - 2 * i, 40 - 1 - 2 * i);
		}

		protected virtual Font getFont()
		{
			return new Font("Times New Roman", 14);
		}

		protected Color getSchriftFarbe()
		{
			return Color.Black;
		}

		protected void drawSchrift(Graphics g)
		{
			Font font = this.getFont();
			Color c = getSchriftFarbe();
			Brush myBrush = new SolidBrush(c);
			Rectangle rect = new Rectangle(
				this.Left, this.Top, this.Width, this.Height);
			StringFormat fo = new StringFormat();
			fo.Alignment = StringAlignment.Center;
			fo.LineAlignment = StringAlignment.Center;

			//UNDONE: Beschriftung
			g.DrawString("A", font, myBrush, rect, fo);
		}

		public override void drawControl(Graphics g)
		{
			drawBorder(g);
			drawSchrift(g);
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
		private const int PenWidth = 5;

		public MyKante(MyKnotenVisual from, MyKnotenVisual to)
		{
			this.Start = from;
			this.End = to;
			from.LocationChanged += LocationChanged;
			to.LocationChanged += LocationChanged;
			this.BackColor = Color.Purple;
			this.setBounds();
		}

		private void LocationChanged(object sender, LocationChangedArgs e)
		{
			Graphics g = this.Parent.CreateGraphics();
			this.drawControl(g);
			this.setBounds();
		}

		public override void drawControl(Graphics g)
		{
			//this.drawBackGround(g);
			Pen myPen = new Pen(Color.Black);
			myPen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
			myPen.Width = PenWidth;
			List<Point> liste = MyKnotenVisual.calcConnectionPoints(this.Start, this.End);
			g.DrawLine(myPen, liste[0], liste[1]);
		}

		private void setBounds()
		{
			List<Point> liste = MyKnotenVisual.calcConnectionPoints(this.Start, this.End);
			Point p1 = liste[0];
			Point p2 = liste[1];
			if (p1.X <= p2.X)
			{
				this.Left = p1.X;
				this.Width = p2.X - p1.X;
			}
			else
			{
				this.Left = p2.X;
				this.Width = p1.X - p2.X;
			}

			if (p1.Y <= p2.Y)
			{
				this.Top = p1.Y;
				this.Height = p2.Y - p1.Y;
			}
			else
			{
				this.Top = p2.Y;
				this.Height = p1.Y - p2.Y;
			}

			//Die Ränder werden sonst unschön
			this.Left -= PenWidth;
			this.Top -= PenWidth;
			this.Width += 2 * PenWidth;
			this.Height += 2 * PenWidth;
		}
	}
} //Ende namespace DumbledoresArmee
