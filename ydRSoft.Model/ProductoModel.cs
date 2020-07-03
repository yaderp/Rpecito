using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ydRSoft.Model
{
    public class ProductoModel
    {
        public int ID { get; set; }
        public string Codigo { get; set; }
        public string Area { get; set; }
        public string Nombre { get; set; }
        public decimal Stock { get; set; }
        public decimal Precio { get; set; }
        public bool ID_Img { get; set; }

        public ProductoModel() {
            this.ID_Img = false;
            this.Precio = 0;
        }        
    }
}
