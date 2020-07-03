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
    public class ProductoController : ApiController
    {
        public List<ProductoModel> Get(int ID) {

            ProductoBL bl = new ProductoBL();

            return bl.ListaProducto(ID);
        }

        //public RespuestaModel Post(ProductoViewModel mProd)
        //{

        //    ProductoBL bl = new ProductoBL();

        //    var resultado = bl.AddProducto(mProd.ID_Area, mProd.Nombre, mProd.Img);
        //    RespuestaModel respuesta = new RespuestaModel();
        //    if (resultado > 0) {
        //        respuesta = new RespuestaModel(resultado,ydR.Mensaje.Save);
        //    }

        //    return respuesta;
        //}

    }
}
