using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ydRSoft.Model;
namespace ydRSoft.ViewModel
{
    public class LstaGastoViewModel
    {
        public int ID_Tipo { set; get; }
        public PaginaModel mPagina { set; get; }
        public List<GastoViewModel> mLista { set; get; }

        public LstaGastoViewModel()
        {
            this.ID_Tipo = 0;
            this.mLista = new List<GastoViewModel>();
        }
    }
}
