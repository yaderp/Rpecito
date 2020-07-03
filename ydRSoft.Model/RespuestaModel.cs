using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ydRSoft.Model
{
    public class RespuestaModel
    {
        public int ID { set; get; }
        public string Mensaje { set; get; }
        public bool Error { set; get; }
        public string Filtro { set; get; }

        public RespuestaModel() {
            this.ID = 0;
            this.Mensaje = "Error de Conexion!!!";
            this.Error = true;
        }

        public RespuestaModel(int ID, string Mensaje, bool Error,string Filtro)
        {
            this.ID = ID;
            this.Mensaje = Mensaje;
            this.Error = Error;
            this.Filtro = Filtro;

        }
        public RespuestaModel(int ID,string Mensaje,bool Error) {
            this.ID = ID;
            this.Mensaje = Mensaje;
            this.Error = Error;
            
        }

        public RespuestaModel(string Mensaje)
        {
            this.ID = 0;
            this.Mensaje = Mensaje;
            this.Error = true;

        }
        public RespuestaModel(int ID, string Mensaje)
        {
            this.ID = ID;
            this.Mensaje = Mensaje;
            this.Error = true;

        }

        public RespuestaModel(string Mensaje, bool Error)
        {
            this.Mensaje = Mensaje;
            this.Error = Error;

        }

    }
}
