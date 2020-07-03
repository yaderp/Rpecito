using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ydRSoft.BL;
using ydRSoft.Model;
using ydRSoft.ViewModel;
namespace ydRSoft.Web.Controllers
{
    public class CompraController : Controller
    {
        #region Solicitud Compra
        
        public ActionResult Solicitud()
        {

            TipoBL bl = new TipoBL();
            ViewBag.TipoAlma = new SelectList(bl.ListaTipoAlma(), "ID", "Nombre");            
            ViewBag.Sede = new SelectList(bl.ListaSede(), "ID", "Nombre");
            

            return View();
        }

        [HttpPost]
        public ActionResult AddCompraSol(CompraSolModel mSol) {

            CompraBL bl = new CompraBL();

            var resultado = bl.AddSolicitud(mSol);

            TempData["Error"] = resultado.Mensaje;
            if (!resultado.Error) {
                TempData["Mensaje"] = resultado.Mensaje;
            }
            TipoBL tbl = new TipoBL();
            ViewBag.ListaDetalle = bl.ListaDetSol(mSol.ID_Empl);
            ViewBag.TipoAlma = new SelectList(tbl.ListaTipoAlma(), "ID", "Nombre");
            return PartialView("_ListaDetalleSol");

        }

        [HttpPost]
        public ActionResult EditCompraSol(CompraSolModel mSol)
        {
            CompraBL bl = new CompraBL();
            var resultado = bl.EditSolicitud(mSol);

            TempData["Error"] = resultado.Mensaje;
            if (!resultado.Error)
            {
                TempData["Mensaje"] = resultado.Mensaje;
            }

            TipoBL tbl = new TipoBL();
            ViewBag.ListaDetalle = bl.ListaDetSol(mSol.ID_Empl);
            ViewBag.TipoAlma = new SelectList(tbl.ListaTipoAlma(), "ID", "Nombre");
            return PartialView("_ListaDetalleSol");
        }

        public ActionResult ListaDetSol()
        {
            EmpleadoModel objEmpleado = (EmpleadoModel)Session["objEmpleado"];
            if (objEmpleado == null)
                objEmpleado = new EmpleadoModel();

            CompraBL bl = new CompraBL();            
            TipoBL tbl = new TipoBL();
            ViewBag.ListaDetalle = bl.ListaDetSol(objEmpleado.DNI);
            ViewBag.TipoAlma = new SelectList(tbl.ListaTipoAlma(), "ID", "Nombre");
            return PartialView("_ListaDetalleSol");
        }


        public ActionResult SendSol()
        {
            EmpleadoModel objEmpleado = (EmpleadoModel)Session["objEmpleado"];

            if (objEmpleado != null) {
                CompraBL bl = new CompraBL();

                bl.EnviarSolicitud(objEmpleado.DNI);
            }

            return RedirectToAction("Solicitud");
        }

        public ActionResult ListaSol()
        {
            return View();
        }

        public ActionResult getListaSol(int IdDet)
        {
            CompraBL bl = new CompraBL();

            ViewBag.ListaSol = bl.ListaSolicitud(ydR.Estado.ENVIADO);

            return PartialView("_ListaSol");
        }
        
        public ActionResult AprobarSol(int IdSol)
        {
            CompraBL bl = new CompraBL();
            EmpleadoModel objEmpleado = (EmpleadoModel)Session["objEmpleado"];

            RespuestaModel resultado = new RespuestaModel(ydR.Mensaje.DontSave);
            if (objEmpleado != null) {
                resultado = bl.OpcSolicitud(IdSol, objEmpleado.DNI, ydR.Estado.APROBADO, "");
            }

            TempData["Error"] = resultado.Mensaje;
            if (!resultado.Error)
            {
                TempData["Mensaje"] = resultado.Mensaje;
            }

            ViewBag.ListaSol = bl.ListaSolicitud(ydR.Estado.ENVIADO);
            return PartialView("_ListaSol");
        }

        public ActionResult CancelSol(int IdSol,string Obser)
        {
            CompraBL bl = new CompraBL();
            EmpleadoModel objEmpleado = (EmpleadoModel)Session["objEmpleado"];

            RespuestaModel resultado = new RespuestaModel(ydR.Mensaje.DontSave);
            if (objEmpleado != null)
            {
                resultado = bl.OpcSolicitud(IdSol, objEmpleado.DNI, ydR.Estado.RECHAZADO, Obser);
            }

            TempData["Error"] = resultado.Mensaje;
            if (!resultado.Error)
            {
                TempData["Mensaje"] = resultado.Mensaje;
            }

            ViewBag.ListaSol = bl.ListaSolicitud(ydR.Estado.ENVIADO);
            return PartialView("_ListaSol");
        }
        
        #endregion

        #region Orden Compra

        public ActionResult OrdenCompra()
        {
            TipoBL bl = new TipoBL();
            ViewBag.Moneda = new SelectList(bl.ListaMoneda(), "ID", "Nombre");
            ViewBag.Sede = new SelectList(bl.ListaSede(), "ID", "Nombre");

            return View();
        }

        public JsonResult JsonaListaSol(int ID_Tipo)
        {
            CompraBL bl = new CompraBL();
            return Json(bl.ListaAlmaSol(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddOrden(CompraOrdModel mOrden)
        {
            CompraBL bl = new CompraBL();
            var resultado = bl.AddOrden(mOrden);   
            
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        
        [HttpPost]
        public ActionResult AddDetalle(CompraDetModel mDetalle)
        {
            CompraBL bl = new CompraBL();

            var resultado = bl.AddDetalle(mDetalle);
            TempData["Error"] = resultado.Mensaje;
            if (!resultado.Error) {
                TempData["Mensaje"] = resultado.Mensaje;
            }

            ViewBag.ListaDetalle = bl.ListaDetalle(mDetalle.ID_Cuerpo);
            return PartialView("_ListaDetalle");
        }


        [HttpPost]
        public ActionResult EditDetalle(CompraDetModel mDetalle)
        {
            CompraBL bl = new CompraBL();

            var resultado = bl.EditDetalle(mDetalle);
            TempData["Error"] = resultado.Mensaje;
            if (!resultado.Error)
            {
                TempData["Mensaje"] = resultado.Mensaje;
            }


            ViewBag.ListaDetalle = bl.ListaDetalle(mDetalle.ID_Cuerpo);
            return PartialView("_ListaDetalle");
        }

        public ActionResult DeleteDetalle(int IdDet,int IdCuerpo)
        {
            CompraBL bl = new CompraBL();
            var resultado = bl.DeleteDetalle(IdDet);
            TempData["Error"] = resultado.Mensaje;
            if (!resultado.Error)
            {
                TempData["Mensaje"] = resultado.Mensaje;
            }

            ViewBag.ListaDetalle = bl.ListaDetalle(IdCuerpo);

            return PartialView("_ListaDetalle");
        }

        public ActionResult GetDetalle(int IdCuerpo)
        {
            CompraBL bl = new CompraBL();           
            ViewBag.ListaDetalle = bl.ListaDetalle(IdCuerpo);
            return PartialView("_ListaOrden");
        }

        public ActionResult JsonSendOrd(int IdOrden) {

            CompraBL bl = new CompraBL();
            var resultado = bl.SerndOrden(IdOrden);

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ListaOrden()
        {
            CompraBL bl = new CompraBL();
            ViewBag.ListaOrden = bl.ListaOrden(ydR.Estado.ENVIADO);
            return View();
        }

        public ActionResult getListaOrden()
        {
            CompraBL bl = new CompraBL();

            ViewBag.ListaOrden = bl.ListaOrden(ydR.Estado.ENVIADO);
            return PartialView("_ListaOrden");
        }

        #endregion

        #region Guia COmpra
        public ActionResult Guia(int? Id)
        {
            if (Id.HasValue) {
                TipoBL tbl = new TipoBL();
                ViewBag.Sede = new SelectList(tbl.ListaSede(), "ID", "Nombre");
                CompraBL bl = new CompraBL();
                var vmGuia = bl.CargarGuia(Id.Value);
                if (vmGuia != null) {
                    if (vmGuia.Estado == 0) {
                        return View(vmGuia);
                    }                        
                }
            }

            return RedirectToAction("ListaOrden");
        }

       

        [HttpPost]
        public ActionResult AddGuia(CompraGuiaModel mGuia, HttpPostedFileBase fileUpload)
        {
            RespuestaModel resultado = new RespuestaModel();
            try
            {
                byte[] imagenData = null;
                
                if (fileUpload != null && fileUpload.ContentLength > 0)
                {
                    using (var imagen = new BinaryReader(fileUpload.InputStream))
                    {
                        imagenData = imagen.ReadBytes(fileUpload.ContentLength);
                    }

                    EmpleadoModel objEmpleado = (EmpleadoModel)Session["objEmpleado"];

                    mGuia.ID_Empl = objEmpleado.DNI;
                    mGuia.Img = imagenData;
                    CompraBL bl = new CompraBL();
                    resultado = bl.AddGuia(mGuia);
                }

                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            
        }

        public ActionResult ApruebaGuia(int IdGuia)
        {
            CompraBL bl = new CompraBL();

            EmpleadoModel objEmpleado = (EmpleadoModel)Session["objEmpleado"];
            RespuestaModel resultado = new RespuestaModel();
            if (objEmpleado != null) {
                resultado = bl.AprobarGuia(IdGuia, objEmpleado.DNI);
            }

            ViewBag.vmLista = bl.ListaGuia(ydR.Estado.NUEVO);

            return PartialView("_ListaGuia");
        }
        
        public ActionResult EditGuiaDetalle(CompraDetModel mDet)
        {
            CompraBL bl = new CompraBL();
            var resultado = bl.EditDetGuia(mDet);

            ViewBag.vmLista = bl.ListaDetalle(resultado);
            ViewBag.IdGuia = mDet.Codigo;
            return PartialView("_GuiaDetalle");
        }

        public ActionResult GuiaDetalle(int IdCuerpo, string Codigo)
        {
            CompraBL bl = new CompraBL();
            ViewBag.vmLista = bl.ListaDetalle(IdCuerpo);
            if (Codigo.Count() > 0)
            {
                ViewBag.IdGuia = Codigo;
            }
            return PartialView("_GuiaDetalle");
        }
        

        public ActionResult ListaNewGuia()
        {
            CompraBL bl = new CompraBL();
            ViewBag.vmLista = bl.ListaGuia(ydR.Estado.NUEVO);
            return View();
        }
        
        public ActionResult getNewGuia()
        {
            CompraBL bl = new CompraBL();
            ViewBag.vmLista = bl.ListaGuia(ydR.Estado.NUEVO);
            return PartialView("_ListaNewGuia");
        }

        //guias enviadas
        public ActionResult GuiaApro()
        {
            return View();
        }

        public ActionResult ListaGuia()
        {
            return View();
        }

        public ActionResult getListaGuia(int IdEstado)
        {
            CompraBL bl = new CompraBL();
            ViewBag.vmLista = bl.ListaGuia(IdEstado);
            return PartialView("_ListaGuia");
        }

        public ActionResult VerGuia(int? Id)
        {
            CompraGuiaModel vmGuia = new CompraGuiaModel();
            if (Id.HasValue)
            {
                TipoBL tbl = new TipoBL();
                ViewBag.Sede = new SelectList(tbl.ListaSede(), "ID", "Nombre");
                CompraBL bl = new CompraBL();
                vmGuia = bl.CargarGuia(Id.Value);
                ViewBag.vmLista = bl.ListaDetalle(Id.Value);
            }

            return PartialView("_VerGuia", vmGuia);
        }

        public JsonResult VerImgGuia(int IdGuia)
        {
            RespuestaModel resultado = new RespuestaModel();
            try
            {
                CompraBL bl = new CompraBL();

                resultado = bl.GetImgGuia(IdGuia);

                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }

        }

        #endregion

        #region comprobante


        public ActionResult AddCompra(int? Id)
        {
            if (Id.HasValue)
            {
                TipoBL tbl = new TipoBL();
                ViewBag.Sede = new SelectList(tbl.ListaSede(), "ID", "Nombre");
                ViewBag.Doc = new SelectList(tbl.ListaDocumento(), "ID", "Nombre");
                CompraBL bl = new CompraBL();
                var vmComp = bl.CargarCompra(Id.Value);
                if (vmComp != null)
                {
                    if (vmComp.Estado == 0)
                    {
                        ViewBag.ListaDetalle = bl.ListaDetalle(Id.Value);
                        return View(vmComp);
                    }
                }
            }

            return RedirectToAction("GuiaApro");
        }

        [HttpPost]
        public ActionResult AddCompra(CompraModel mComp, HttpPostedFileBase fileUpload)
        {
            RespuestaModel resultado = new RespuestaModel();
            try
            {
                byte[] imagenData = null;

                if (fileUpload != null && fileUpload.ContentLength > 0)
                {
                    using (var imagen = new BinaryReader(fileUpload.InputStream))
                    {
                        imagenData = imagen.ReadBytes(fileUpload.ContentLength);
                    }

                    EmpleadoModel objEmpleado = (EmpleadoModel)Session["objEmpleado"];

                    mComp.ID_Empl = objEmpleado.DNI;
                    mComp.Img = imagenData;
                    CompraBL bl = new CompraBL();
                    resultado = bl.AddCompra(mComp);
                }

                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult CompDetalle(int IdComp)
        {
            CompraBL bl = new CompraBL();
            ViewBag.vmLista = bl.ListaDetalle(IdComp);
            
            return PartialView("_GuiaDetalle");
        }

        public ActionResult ListaComp()
        {
            CompraBL bl = new CompraBL();

            ViewBag.vmLista = bl.ListaCompra(ydR.Estado.NUEVO);

            return View();
        }

        public ActionResult getListaComp(int IdEstado)
        {
            CompraBL bl = new CompraBL();
            ViewBag.vmLista = bl.ListaCompra(IdEstado);
            return PartialView("_ListaComp");
        }

        public ActionResult AprobarComp(int IdComp)
        {
            CompraBL bl = new CompraBL();
            var resultado = bl.AprobarCompra(IdComp);
            ViewBag.vmLista = bl.ListaCompra(ydR.Estado.NUEVO);
            return PartialView("_ListaComp");
        }

        public ActionResult VerComp(int? Id)
        {
            CompraModel mComp = new CompraModel();
            if (Id.HasValue)
            {
                TipoBL tbl = new TipoBL();
                ViewBag.Sede = new SelectList(tbl.ListaSede(), "ID", "Nombre");
                CompraBL bl = new CompraBL();
                mComp = bl.CargarCompra(Id.Value);
                ViewBag.vmLista = bl.ListaDetalle(Id.Value);
            }

            return PartialView("_VerComp", mComp);
        }

        public JsonResult VerImgComp(int Idcomp)
        {
            RespuestaModel resultado = new RespuestaModel();
            try
            {
                CompraBL bl = new CompraBL();

                resultado = bl.GetImgCompra(Idcomp);

                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }

        }



        #endregion

        
      
    }
}