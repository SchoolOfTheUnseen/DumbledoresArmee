using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumbledoresArmee
{
	/// <summary>
	/// Basisklasse für alle graphisch darstellbaren Kanten
	/// </summary>
	public class KantenVisualBase
	{
		protected KantenBase myKante;
		/// <summary>
		/// Das Control, auf dem die Kante dargestellt wird
		/// </summary>
		protected Panel myControl;
		public Panel MYControl
		{
			get { return myControl; }
		}


		public KantenVisualBase(KantenBase kante, Control parent)
		{
			this.myKante = kante;
			this.myControl = new Panel();
			placeKante(parent);
		}

		protected void placeKante(Control parent)
		{
			int left;
			if (myKante.From.visual.MYControl.Left <= myKante.To.visual.MYControl.Left)
				left = myKante.From.visual.MYControl.Left;
			else
				left = myKante.To.visual.MYControl.Left;

			int top;
			if (myKante.From.visual.MYControl.Top <= myKante.To.visual.MYControl.Top)
				top = myKante.From.visual.MYControl.Top;
			else
				top = myKante.To.visual.MYControl.Top;

			int width = myKante.To.visual.MYControl.Left - myKante.From.visual.MYControl.Left;
			if (width < 0)
				width = -width;

			int height = myKante.To.visual.MYControl.Top - myKante.From.visual.MYControl.Top;
			if (height < 0)
				height = -height;

			this.myControl.Left = left;
			this.myControl.Top = top;
			this.myControl.Width = width;
			this.myControl.Height = height;
			this.myControl.Parent = parent;

			this.myControl.BackColor = Color.RebeccaPurple;
		}
	}
} //Ende namespace DumbledoresArmee

