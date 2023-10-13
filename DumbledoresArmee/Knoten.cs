using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumbledoresArmee
{
	/// <summary>
	/// Basisklasse für alle Knoten
	/// </summary>
	public abstract class KnotenBase
	{
	}

	/// <summary>
	/// Ein simpler Knoten in einem Graphen
	/// </summary>
	public class Knoten : KnotenBase
	{
		/// <summary>
		/// Die Beschriftung des Knotens
		/// </summary>
		private string _Beschriftung;
		/// <summary>
		/// Lese-Zugriff auf die Beschriftung des Knotens
		/// </summary>
		public string Beschriftung
		{
			get
			{
				return _Beschriftung;
			}
		}

		/// <summary>
		/// Standard-Konstruktor
		/// </summary>
		/// <param name="beschriftung">Die Beschriftung für den Knoten</param>
		public Knoten(string beschriftung)
		{
			this._Beschriftung = beschriftung;
		}
	} //Ende Klasse Knoten
} //Ende namespace DumbledoresArmee
