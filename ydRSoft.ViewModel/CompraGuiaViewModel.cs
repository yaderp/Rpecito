using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ydRSoft.Model;
namespace ydRSoft.ViewModel
{
    public class CompraGuiaViewModel
    {
        public int ID { set; get; }
        public string RUC { set; get; }
        public string Codigo { set; get; }
        public string Fecha { set; get; }
        public string RazSocial { set; get; }
        public string CodOrden { set; get; }
        public string Serie { set; get; }
        public string numero { set; get; }
        public CompraGuiaViewModel() {
            this.ID = 0;           
        }

        public CompraGuiaViewModel(int ID, string RUC, string RazSocial)
        {
            this.ID = ID;
            this.RUC = RUC;
            this.RazSocial = RazSocial;
        }
    }
}
