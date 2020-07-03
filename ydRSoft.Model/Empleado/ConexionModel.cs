using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ydRSoft.Model
{
    public class ConexionModel
    {
        public string RUC { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public bool Error { set; get; }
        public ConexionModel() {
            this.Error = true;
            this.Nombre = "Error de Conexion!!!";
        }
    }
}
