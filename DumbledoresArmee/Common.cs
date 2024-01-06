using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumbledoresArmee
{
	internal class Common
	{
		/// <summary>
		/// Die maximale Länge einer Beschriftung, gemessen an der Anzahl Stellen der Anzahl der Schriftzeichen im String
		/// </summary>
		/// <returns>Die maximale Länge</returns>
		public static int getMaxStringLengthStellen()
		{
			//D.h.: Kein String darf länger sein als 99999 Zeichen
			return 5;
		}
	}
}
