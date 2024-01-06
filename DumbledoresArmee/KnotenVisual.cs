using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumbledoresArmee
{
	/// <summary>
	/// Basisklasse für alle graphisch darstellbaren Knoten
	/// </summary>
	//public abstract class KnotenVisualBase
	//{
	//	/// <summary>
	//	/// Verweis auf den Knoten, der dargestellt wird
	//	/// </summary>
	//	protected Knoten myKnoten;
	//	/// <summary>
	//	/// Das Control, auf dem der Knoten dargestellt wird
	//	/// </summary>
	//	protected Panel myControl;
	//	public Panel MYControl
	//	{
	//		get { return myControl; }
	//	}

	//	/// <summary>
	//	/// Standard-Konstruktor
	//	/// </summary>
	//	/// <param name="knoten">Verweis auf den Knoten, der dargestellt wird</param>
	//	/// <param name="parent">Das Fenster oder Panel, wo der Knoten dargestellt wird</param>
	//	/// <param name="x">Die x-Koordinate für die linke obere Ecke des Controls</param>
	//	/// <param name="y">Die y-Koordinate für die linke obere Ecke des Controls</param>
	//	public KnotenVisualBase(Knoten knoten, Control parent,
	//		int x, int y)
	//	{
	//		this.myKnoten = knoten;
	//		knoten.visual = this;
	//		this.myControl = new Panel();
	//		setControl(x, y, parent);
	//	}

	//	/// <summary>
	//	/// Nimmt die nötigen Einstellungen am Control vor
	//	/// </summary>
	//	/// <param name="x">Die x-Koordinate für die linke obere Ecke des Controls</param>
	//	/// <param name="y">Die y-Koordinate für die linke obere Ecke des Controls</param>
	//	/// <param name="parent">Der Verweis auf das Form oder Panel, wo der Knoten dargestellt wird</param>
	//	protected abstract void setControl(int x, int y, Control parent);
	//} //Ende Klasse KnotenVisualBase

	/// <summary>
	/// Ein simpler Knoten in einem Graphen
	/// </summary>
	//public class KnotenVisual : KnotenVisualBase
	//{
	//	/// <summary>
	//	/// Die Seitenlänge des Knotens in Pixel
	//	/// </summary>
	//	private const int length = 40;
	//	/// <summary>
	//	/// Die Breite des Ringrandes in Pixel
	//	/// </summary>
	//	private const int rand = 5;
	//	/// <summary>
	//	/// Die Farbe des Randes
	//	/// </summary>
	//	private static Color RandFarbe = Color.Black;
	//	/// <summary>
	//	/// Die Farbe der Beschriftung
	//	/// </summary>
	//	private static Color TextFarbe = Color.Blue;

	//	/// <summary>
	//	/// Standard-Konstruktor
	//	/// </summary>
	//	/// <param name="knoten">Verweis auf den Knoten, der dargestellt wird</param>
	//	/// <param name="parent">Das Fenster oder Panel, wo der Knoten dargestellt wird</param>
	//	/// <param name="x">Die x-Koordinate für die linke obere Ecke des Controls</param>
	//	/// <param name="y">Die y-Koordinate für die linke obere Ecke des Controls</param>
	//	public KnotenVisual(Knoten knoten, Control parent,
	//		int x, int y) :
	//		base(knoten, parent, x, y)
	//	{
	//	}

	//	/// <summary>
	//	/// Nimmt die nötigen Einstellungen am Control vor
	//	/// </summary>
	//	/// <param name="x">Die x-Koordinate für die linke obere Ecke des Controls</param>
	//	/// <param name="y">Die y-Koordinate für die linke obere Ecke des Controls</param>
	//	/// <param name="parent">Der Verweis auf das Form oder Panel, wo der Knoten dargestellt wird</param>
	//	protected override void setControl(int x, int y, Control parent)
	//	{
	//		this.myControl.Left = x;
	//		this.myControl.Top = y;
	//		this.myControl.Width = length;
	//		this.myControl.Height = length;
	//		this.myControl.Paint += MyControl_Paint;
	//		this.myControl.Parent = parent;
	//	}

	//	/// <summary>
	//	/// Wird aufgerufen, wenn das Control neu gezeichnet wird
	//	/// </summary>
	//	/// <param name="sender"></param>
	//	/// <param name="e"></param>
	//	private void MyControl_Paint(object? sender, PaintEventArgs e)
	//	{
	//		Pen myPen = new Pen(RandFarbe);
	//		Graphics g = e.Graphics;

	//		for (int i = 0; i < rand; i++)
	//			g.DrawEllipse(myPen, i, i, length - 1 - 2 * i, length - 1 - 2 * i);

	//		Font font = new Font("Times New Roman", 14);
	//		Brush myBrush = new SolidBrush(TextFarbe);
	//		Rectangle rect = new Rectangle(0, 0, this.myControl.Width, this.myControl.Height);
	//		StringFormat fo = new StringFormat();
	//		fo.Alignment = StringAlignment.Center;
	//		fo.LineAlignment = StringAlignment.Center;
	//		g.DrawString(this.myKnoten.Beschriftung, font, myBrush, rect, fo);
	//	}
	//} //Ende Klasse KnotenVisual
} //Ende Klasse namespace DumbledoresArmee
