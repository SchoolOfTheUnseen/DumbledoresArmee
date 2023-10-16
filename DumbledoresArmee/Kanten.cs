using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumbledoresArmee
{
	/// <summary>
	/// Basisklasse für alle Arten von Kanten
	/// </summary>
	public class KantenBase
	{
		/// <summary>
		/// Der Ausgansknoten
		/// </summary>
		public Knoten From { get; set; }
		/// <summary>
		/// Der Zielknoten
		/// </summary>
		public Knoten To { get; set;}

		public KantenBase(Knoten from, Knoten to)
		{
			From = from;
			To = to;
		}
	} //Ende Klasse KantenBase
} //Ende namespace DumbledoresArmee
