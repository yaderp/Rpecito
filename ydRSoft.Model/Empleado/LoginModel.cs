using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ydRSoft.Model
{
    public class LoginModel
    {
        public string DNI { set; get; }
        public string Nombre { set; get; }
        public string Clave { set; get; }
        public string ReClave { set; get; }
        public bool Error { set; get; }
        public LoginModel() {
            this.Nombre = "Error de Conexion!!!";
            this.Error = true;
        }


        public LoginModel(string DNI,string Nombre) {
            this.DNI = DNI;
            this.Nombre = Nombre;
            
        }

    }
}
