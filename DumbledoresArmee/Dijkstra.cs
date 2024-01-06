using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumbledoresArmee
{
	public enum EKnotenFarben
	{
		None, //Keine Farbe - noch offen
		gruen, //Wurde bereits vollständig abgearbeitet
		gelb //Wird demnächst abgearbeitet
	}

	public enum EKantenFarben
	{
		None, //Keine Farbe - noch offen
		rot, //Momentan aufspannender minimaler Baum
		gelb //Verworfene Kante, weil längerer Weg
	}

	class DijkstraKnoten : Knoten
	{
		/// <summary>
		/// Die Farbe dieses Knotens
		/// </summary>
		public EKnotenFarben Farben { get; set; }
		/// <summary>
		/// Die Distanz von diesem Knoten zum Startknoten v
		/// </summary>
		public int Distanz_zu_v {  get; set; }

		public DijkstraKnoten(string s) : base(s)
		{
			//this.Farben = EKnotenFarben.None;
			this.Farben = EKnotenFarben.gruen;
			this.Distanz_zu_v = 0;
		}
	}

	class DijkstraKnotenVisual : MyKnotenVisual
	{
		DijkstraKnoten _MyKnoten;

		public DijkstraKnotenVisual(DijkstraKnoten knoten,
			int x, int y, Control parent) :
			base(x, y, parent)
		{
			this._MyKnoten = knoten;

			if (this.Parent != null)
			{
				Graphics g = this.Parent.CreateGraphics();
				this.drawControl(g);
			}
		}

		protected override Font getFont()
		{
			return new Font("Times New Roman", 10);
		}

		private Rectangle createUpperRectangle()
		{
			int w = this.getBorderWidth();
			return new Rectangle(
				this.Left, this.Top + w, this.Width, this.Height / 2 - w);
		}

		private Rectangle createLowerRectangle()
		{
			int w = this.getBorderWidth();
			return new Rectangle(
				this.Left, this.Top + (this.Height / 2), this.Width, this.Height / 2 - w);
		}

		private void draw2Schrift(Graphics g)
		{
			Font font = this.getFont();
			Color c = getSchriftFarbe();
			Brush myBrush = new SolidBrush(c);

			StringFormat fo = new StringFormat();
			fo.Alignment = StringAlignment.Center;
			fo.LineAlignment = StringAlignment.Center;

			Rectangle upper = createUpperRectangle();
			//UNDONE: Beschriftung
			g.DrawString("A", font, myBrush, upper, fo);

			Rectangle lower = createLowerRectangle();
			//UNDONE: Beschriftung
			g.DrawString("A", font, myBrush, lower, fo);
		}

		public override void drawControl(Graphics g)
		{
			this.drawCircleBackground(g);
			this.drawBorder(g);
			this.draw2Schrift(g);
		}

		/// <summary>
		/// Bestimmt die Hintergrundfarbe
		/// </summary>
		/// <returns>Die Hintergrundfarbe für diesen Knoten</returns>
		private Color getBackColor()
		{
			if (this._MyKnoten == null)
				return this.Parent.BackColor;

			EKnotenFarben farbe = this._MyKnoten.Farben;
			switch (farbe)
			{
				case EKnotenFarben.gruen: return Color.Green;
				case EKnotenFarben.gelb: return Color.Yellow;
				default: return this.Parent.BackColor;
			}
		}

		private void drawCircleBackground(Graphics g)
		{
			Color c = getBackColor();
			SolidBrush myBrush = new SolidBrush(c);
			Rectangle rect = new Rectangle(this.Left, this.Top, this.Width, this.Height);
			g.FillEllipse(myBrush, rect);
		}
	}
}
