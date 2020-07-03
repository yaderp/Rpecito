using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ydRSoft.Model
{
    public class PaginaModel
    {
        public int PagInicio { set; get; }
        public int PagFinal { set; get; }
        public int Index { set; get; } // posisicon de la pagina
        public int CantPagina { set; get; }  // total de paginas.

        public PaginaModel(int pagina, int CantTotal)
        {
            this.CantPagina = CantTotal / ydR.Dato.TotalPagina;
            if (CantTotal % ydR.Dato.TotalPagina > 0) {
                CantPagina++;
            }

            if (pagina == 0) {
                pagina = CantPagina;
            }

            this.Index = pagina;            
            this.PagInicio = (Index - 1) * ydR.Dato.TotalPagina;
            this.PagFinal = PagInicio + ydR.Dato.TotalPagina;

            if (PagFinal > CantTotal)
            {
                PagFinal = CantTotal;
            }
        }
    }
}
