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
			this.BackColor = Color.Red;
			MessageBox.Show("Hallo Welt!");
		}
	}
}