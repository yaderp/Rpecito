using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ydRSoft.Model
{
    public class ProveedorModel
    {
        public string RUC { get; set; }
        public string RazSocial { get; set; }
        public string Direccion { get; set; }
        public  bool Error { get; set; }
        public string Mensaje { get; set; }
        public ProveedorModel(string RUC,string RazSocial, string Direccion) {
            this.RUC = RUC;
            this.RazSocial = RazSocial;
            this.Direccion = Direccion;
            this.Error = false;
            this.Mensaje = "Exito!!!";
        }

        public ProveedorModel()
        {
            this.Mensaje = "Error de Conexion!!!";
            this.Error = true;
        }

        public ProveedorModel(string Mensaje)
        {
            this.Mensaje = Mensaje;
            this.Error = true;
        }

    }
}
