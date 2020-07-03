using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ydRSoft.Model;
namespace ydRSoft.ViewModel
{
    public class ComprobanteViewModel:ComprobanteModel
    {
        public int ID_Documento{ set; get; }
        public int ID_Padre { set; get; }
        public byte[] Img { set; get; }

        
    }
}
