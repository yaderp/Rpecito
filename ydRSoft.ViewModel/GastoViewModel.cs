using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ydRSoft.ViewModel
{
    public class GastoViewModel
    {
        public int ID { set; get; }
        public string Codigo { set; get; }
        public string Tipo { set; get; }
        public string Doc { set; get; }
        public string RUC { set; get; }
        public string RazSocial { set; get; }
        public string SerieNum { set; get; }
        public string Fecha { set; get; }
        public decimal Monto { set; get; }
        public string Total { set; get; }
    }
}
