using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ydRSoft.Model
{
    public class TipoModel
    {
        public int ID { set; get; }
        public string Nombre { set; get; }

        public TipoModel(int ID, string Nombre)
        {
            this.ID = ID;
            this.Nombre = Nombre;
        }

        public TipoModel() { }
    }
}
