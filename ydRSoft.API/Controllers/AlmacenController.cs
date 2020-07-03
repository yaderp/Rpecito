using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ydRSoft.Model;
using ydRSoft.ViewModel;
using ydRSoft.BL;
namespace ydRSoft.API.Controllers
{
    public class AlmacenController : ApiController
    {
        public List<ProductoModel> Get(int ID)
        {

            AlmacenBL bl = new AlmacenBL();

            return bl.ListaAlmacen(ID);
        }

        //public RespuestaModel Post(ProductoViewModel mProd)
        //{

        //    AlmacenBL bl = new AlmacenBL();

        //    var resultado = bl.AddAlmacen(mProd.ID_Area, mProd.Detalle, mProd.Img);
        //    RespuestaModel respuesta = new RespuestaModel();
        //    if (resultado > 0)
        //    {
        //        respuesta = new RespuestaModel(resultado, ydR.Mensaje.Save);
        //    }

        //    return respuesta;
        //}
    }
}
