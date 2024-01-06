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
		/// Verweis auf die bildliche Darstellung
		/// </summary>
		public MyKnotenVisual visual { get; set;  }

		/// <summary>
		/// Standard-Konstruktor
		/// </summary>
		/// <param name="beschriftung">Die Beschriftung für den Knoten</param>
		public Knoten(string beschriftung)
		{
			this._Beschriftung = beschriftung;
			this.visual = null;
		}

		/// <summary>
		/// Speicher die Beschriftung dieses Knotens zusammen mit 
		/// der Länge der Beschriftung, die vorangestellt wird
		/// </summary>
		/// <returns></returns>
		protected string BeschriftungToSaveString()
		{
			int n = this._Beschriftung.Length;
			StringBuilder result = new StringBuilder();
			result.Append(n.ToString());
			while (result.Length < Common.getMaxStringLengthStellen())
				result.Insert(0, ' ');
			result.Append(this._Beschriftung);
			return result.ToString();
		}

		/// <summary>
		/// Wandelt diesen Knoten in einen String zum Speichern um
		/// </summary>
		/// <returns></returns>
		public virtual string toSaveString()
		{
			return this.BeschriftungToSaveString();
		}
	} //Ende Klasse Knoten
} //Ende namespace DumbledoresArmee
