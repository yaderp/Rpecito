using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ydRSoft.Model;
namespace ydRSoft.ViewModel
{
    public class EmpleadoViewModel : EmpleadoModel
    {
        
        public string Clave { set; get; }
        public DateTime Fecha_Nac { set; get; }
        public string Direccion { set; get; }
        public string  Sexo { set; get; }

        public EmpleadoViewModel() {
            this.ID_Cargo = 1;
            this.Fecha_Nac = DateTime.Now;
            this.ID_Sexo = 0;
        }
        
    }
}
