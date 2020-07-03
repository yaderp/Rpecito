using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ydRSoft.BL;
namespace ydRSoft.Web.Controllers
{
    public class EmpresaController : Controller
    {
        public JsonResult JsonCliente(string RUC)
        {
            ClienteBL obl = new ClienteBL();
            return Json(obl.getCliente(RUC), JsonRequestBehavior.AllowGet);
        }

        public JsonResult JsonProveedor(string RUC)
        {
            ProveedorBL bl = new ProveedorBL();
            return Json(bl.getProveedor(RUC), JsonRequestBehavior.AllowGet);
        }
    }
}