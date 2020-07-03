using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ydRSoft.Model
{
    public class CompraOrdModel
    {
        public int ID { set; get; }
        public string Codigo { set; get; }
        public int Sede { set; get; }
        public string RUC { set; get; }
        public string RazSocial { set; get; }
        public int Moneda { set; get; }
        public decimal Cambio { set; get; }
        public string ID_Empl { set; get; }
        public string Fecha { set; get; }
        public string Doc { set; get; }
    }
}
