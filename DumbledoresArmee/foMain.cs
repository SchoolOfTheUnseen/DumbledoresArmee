using System.ComponentModel;

namespace DumbledoresArmee
{
	public partial class foMain : Form
	{
		public foMain()
		{
			InitializeComponent();
		}

		private static void drawPoint(Point p, Graphics g)
		{
			Brush myBrush = new SolidBrush(Color.Purple);
			g.FillRectangle(myBrush, p.X, p.Y, 5, 5);
		}

		private static void showPoint(Point p)
		{
			MessageBox.Show("X = " + p.X + ", Y = " + p.Y);
		}

		private void buTest1_Click(object sender, EventArgs e)
		{
			//this.BackColor = Color.Red;
			//MessageBox.Show("Hallo Welt!");

			Knoten knA = new Knoten("A");
			// KnotenVisual knotenA = new KnotenVisual(knA, this, 200, 200);
			MyKnotenVisual knotenA = new MyKnotenVisual(200, 200, this);

			Knoten knB = new Knoten("B");
			//KnotenVisual knotenB = new KnotenVisual(knB, this, 300, 250);
			MyKnotenVisual knotenB = new MyKnotenVisual(300, 250, this);

			//KantenBase kante1 = new KantenBase(knA, knB);
			//KantenVisualBase kanteV1 = new KantenVisualBase(kante1, this);

			//MyKnotenVisual test = new MyKnotenVisual();
			Graphics g = this.CreateGraphics();
			////test.drawControl(g);

			//MyKnotenVisual test2 = new MyKnotenVisual();
			//test2.Left = 100;
			////Graphics g = this.CreateGraphics();
			////test2.drawControl(g);

			//MyKante kante = new MyKante(test, test2);
			//kante.drawControl(g);

			//Point p1 = new Point(100, 150);
			//Point p2 = new Point(130, 180);
			//GeradenGleichungBase gl = GeradenGleichungBase.createGleichung(p1, p2);
			//gl.drawGerade(g, this.Bounds);
			//Brush myBrush = new SolidBrush(Color.Purple);
			//g.FillRectangle(myBrush, p1.X, p1.Y, 5, 5);
			//g.FillRectangle(myBrush, p2.X, p2.Y, 5, 5);

			//Point p3 = new Point(190, 180);
			//Point p4 = new Point(310, 260);
			//drawPoint(p3, g);
			//drawPoint(p4, g);

			//GeradenGleichungBase gl2 = GeradenGleichungBase.createGleichung(p3, p4);
			//gl2.drawGerade(g, this.Bounds);
			//gl2.showGleichung();

			//List<Point> schnitt = MyKnotenVisual.calcSchnittpunkte(knotenA, knotenB);
			//List<Point> schnitt = MyKnotenVisual.calcConnectionPoints(knotenA, knotenB);
			//for (int i = 0; i < schnitt.Count; i++)
			//{
				//drawPoint(schnitt[i], g);
				//showPoint(schnitt[i]);
			//}

			Point c1 = knotenA.calcCenter();
			Point c2 = knotenB.calcCenter();
			GeradenGleichungBase gl3 = GeradenGleichungBase.createGleichung(c1, c2);
			//gl3.drawGerade(g, this.Bounds);

			//MyKante kante1 = new MyKante(knotenA, knotenB);
			//kante1.Parent = this;
			MyKante kante1 = new MyKante(knotenB, knotenA);
			kante1.Parent = this;
		}
	}
}