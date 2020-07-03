using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ydRSoft.Model
{
    public class ClienteModel
    {
        public string RUC { get; set; }
        public string RazSocial { get; set; }
        public string Direccion { get; set; }
        public string Pago { get; set; }
        public int Credito { get; set; }
        public int ID_Estado { get; set; }

        public ClienteModel() {

        }
        public ClienteModel(string RUC, string RazSocial, string Direccion)
        {
            this.RUC = RUC;
            this.RazSocial = RazSocial;
            this.Direccion = Direccion;
            this.Pago = "CONTADO";
            this.Credito = 0;
            this.ID_Estado = 1;
        }
    }
}
