using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ydRSoft.Model;
namespace ydRSoft.ViewModel
{
    public class ClienteViewModel:ClienteModel
    {
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }        
        public int Sede { get; set; }         
        public bool Error { get; set; }
        public string  Mensaje { get; set; }

        public ClienteViewModel() {
            this.Error = true;
            this.Mensaje = "Error de Conexion";
        }

        public ClienteViewModel(bool Error, string Mensaje)
        {
            this.Error = Error;
            this.Mensaje = Mensaje;
        }
        public ClienteViewModel(string Mensaje)
        {
            this.Error = true;
            this.Mensaje = Mensaje;
        }

    }
}
