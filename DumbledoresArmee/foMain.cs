namespace DumbledoresArmee
{
	public partial class foMain : Form
	{
		public foMain()
		{
			InitializeComponent();
		}

		private void buTest1_Click(object sender, EventArgs e)
		{
			//this.BackColor = Color.Red;
			//MessageBox.Show("Hallo Welt!");

			Knoten knA = new Knoten("A");
			KnotenVisual knotenA = new KnotenVisual(knA, this, 200, 200);

			Knoten knB = new Knoten("B");
			KnotenVisual knotenB = new KnotenVisual(knB, this, 300, 250);

			KantenBase kante1 = new KantenBase(knA, knB);
			KantenVisualBase kanteV1 = new KantenVisualBase(kante1, this);

			MyKnotenVisual test = new MyKnotenVisual();
			Graphics g = this.CreateGraphics();
			//test.drawControl(g);

			MyKnotenVisual test2 = new MyKnotenVisual();
			test2.Left = 100;
			//Graphics g = this.CreateGraphics();
			//test2.drawControl(g);

			MyKante kante = new MyKante(test, test2);
			kante.drawControl(g);

			Point p1 = new Point(100, 150);
			Point p2 = new Point(130, 180);
			GeradenGleichungBase gl = GeradenGleichungBase.createGleichung(p1, p2);
			gl.drawGerade(g, this.Bounds);
			Brush myBrush = new SolidBrush(Color.Purple);
			g.FillRectangle(myBrush, p1.X, p1.Y, 5, 5);
			g.FillRectangle(myBrush, p2.X, p2.Y, 5, 5);
		}
	}
}