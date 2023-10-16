using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
				this._Left = value;
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
				this._Top = value;
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
				if (this._Parent != null)
				{
					Rectangle r = new Rectangle(
						this.Left, this.Top, this.Width, this.Height);
					this._Parent.Invalidate(r);
				}
				this._Parent = value;
			}
		}


		public abstract void drawControl(Graphics g);

		public bool isInsideControl(int x, int y)
		{
			return true;
		}
	}

	public class MyKnotenVisual : MyControl
	{
		public MyKnotenVisual()
		{
			this.Width = 40;
			this.Height = 40;
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
			int x = this.Left + this.Width / 2;
			int y = this.Top + this.Height / 2;
			return new Point(x, y);
		}
	}

	public class MyKante : MyControl
	{
		Point Start;
		Point End;

		public MyKante(MyKnotenVisual from, MyKnotenVisual to)
		{
			this.Start = from.calcCenter();
			this.End = to.calcCenter();
		}

		public override void drawControl(Graphics g)
		{
			Pen myPen = new Pen(Color.Black);
			myPen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
			myPen.Width = 5;
			g.DrawLine(myPen, this.Start, this.End);
		}
	}
} //Ende namespace DumbledoresArmee
