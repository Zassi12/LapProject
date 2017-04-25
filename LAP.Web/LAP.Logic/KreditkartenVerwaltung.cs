using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAP.Logic
{
    public class KreditkartenVerwaltung
    {
        /// <summary>
        /// Kreditkarten LUHN Berechnung
        /// </summary>
        /// <param name="KKNumber">Kreditkartennummer</param>
        /// <returns>True wenn Kartennummer in Ordnung</returns>
        public static bool CheckLUHN(string KKNumber)
        {
            int intWert = 0, intX = 0;

            if (KKNumber.Length > 0)
            {
                for (int intPos = KKNumber.Length - 1; intPos >= 0; intPos--)
                {
                    intX = Convert.ToInt32(KKNumber.Substring(intPos, 1));
                    intWert += ((KKNumber.Length - 1 - intPos) % 2) == 0 ? intX : Quersumme(Convert.ToString(intX * 2));
                }

                return ((intWert % 10) == 0);
            }
            else
                return false;
        }

       
        /// <summary>
        /// Berechnet Quersumme anhand eines Zahlenstrings
        /// </summary>
        /// <param name="Wert">Zahlenstrings z.B. "12345"</param>
        /// <returns>Quersumme z.B. 15</returns>
        public static int Quersumme(string Wert)
        {
            int intReturn = 0;

            while (Wert != "")
            {
                intReturn += Convert.ToInt32(Wert.Substring(0, 1));
                Wert = Wert.Substring(1);
            }
            return intReturn;
        }
    }
}
