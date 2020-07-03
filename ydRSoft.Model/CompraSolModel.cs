using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ydRSoft.Model
{
    public class CompraSolModel
    {
        public int ID { set; get; }
        public string Codigo { set; get; }
        public int Sede { set; get; }
        public string ID_Empl { set; get; }
        public int ID_Alma { set; get; }
        public string Fecha { set; get; }
        public string Nombre { set; get; }
        public decimal Cantidad { set; get; }
        public string Observacion { set; get; }
        public string Aprobado { set; get; }
    }
}
