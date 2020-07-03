using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ydRSoft.ydR
{
    public class Convertir
    {
        
        public static DateTime ToFECHA(string fecha) {
            try {
                return Convert.ToDateTime(fecha);
            } catch {

            return DateTime.Now;
            }
        }

        public static decimal ToDECIMAL(string numero)
        {
            try
            {
                return Convert.ToDecimal(numero);
            }
            catch
            {

                return 0;
            }
        }

        public static decimal ToDECIMAL(decimal numero,int cant)
        {
            try
            {
                numero = Math.Round(numero, cant, MidpointRounding.AwayFromZero);
                return numero;                
            }
            catch
            {

                return 0;
            }
        }

        public static int ToENTERO(string numero)
        {
            try
            {
                return Convert.ToInt32(numero);
            }
            catch
            {

                return 0;
            }
        }

        public static decimal toIGV(decimal total)
        {
            try
            {
                decimal igv = total * 18 / 118;

                return ToDECIMAL(igv, 2);
            }
            catch
            {
                return 0;
            }
        }


    }
}
