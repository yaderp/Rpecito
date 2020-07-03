using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ydRSoft.Model;
using ydRSoft.BL;

namespace ydRSoft.API.Controllers
{
    public class AreaController : ApiController
    {
        // GET: api/Area
        public List<TipoModel> Get()
        {
            ProductoBL bl = new ProductoBL();
            var lista = bl.ListaArea();
            return lista;
        }
    }
}
