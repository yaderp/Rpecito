using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ydRSoft.Model
{
    public class ComprobanteModel
    {
        public int ID { set; get; }
        public string RUC { set; get; }
        public string RazSocial { set; get; }
        public string Direccion { set; get; }
        public string Documento { set; get; }
        public string Serie { set; get; }
        public int Numero { set; get; }
        public string Fecha { set; get; }
        public string NComp { set; get; }
        public string Sede { set; get; }
        public bool isImg { set; get; }
    }
}
