using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ydRSoft.Model
{
    public class CompraDetModel
    {
        public int ID { set; get; }
        public string Codigo { set; get; }
        public int ID_Cuerpo { set; get; }
        public int ID_Alma { set; get; }
        public string Nombre { set; get; }
        public string Observ { set; get; }
        public decimal Cantidad { set; get; }
        public decimal Precio { set; get; }
        public decimal Total { set; get; }

    }
}
