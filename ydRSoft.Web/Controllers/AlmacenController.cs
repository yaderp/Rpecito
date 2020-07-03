using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ydRSoft.ViewModel;
using ydRSoft.Model;
using ydRSoft.BL;
using System.IO;
namespace ydRSoft.Web.Controllers
{
    public class AlmacenController : Controller
    {
        // GET: Almacen
        public ActionResult AddAlmacen()
        {
            AlmacenBL bl = new AlmacenBL();
            ViewBag.ListaTipo = new SelectList(bl.ListaTipo(), "ID", "Nombre");
            return View();
        }


        [HttpPost]
        public ActionResult AddAlmacen(int IdTipo, string Nombre, HttpPostedFileBase fileUpload)
        {
            try
            {
                byte[] imagenData = null;
                if (fileUpload != null && fileUpload.ContentLength > 0)
                {
                    using (var imagen = new BinaryReader(fileUpload.InputStream))
                    {
                        imagenData = imagen.ReadBytes(fileUpload.ContentLength);
                    }

                }

                TempData["Error"] = Nombre + " No Guardado";
                AlmacenBL bl = new AlmacenBL();

                if (bl.AddAlmacen(IdTipo, Nombre, imagenData) > 0)
                {
                    TempData["Mensaje"] = Nombre + " Guardado Satisfactoriamente";
                }
                
                ViewBag.ListaTipo = new SelectList(bl.ListaTipo(), "ID", "Nombre");
                ViewBag.ListaAlmacen = bl.ListaAlmacen(IdTipo);

                return PartialView("_ListaAlmacen");
            }
            catch
            {
                return View("AddAlmacen");
            }
            //return Json(new { Value = true, Message = "No se Guardo" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ListaAlmacen()
        {
            AlmacenBL bl = new AlmacenBL();
            ViewBag.ListaAlmacen = bl.ListaAlmacen(1);
            ViewBag.ListaTipo = new SelectList(bl.ListaTipo(), "ID", "Nombre");
            return View();
        }

        public ActionResult MostrarAlmacen(int IdTipo)
        {
            AlmacenBL bl = new AlmacenBL();
            ViewBag.ListaAlmacen = bl.ListaAlmacen(IdTipo);
            ViewBag.ListaTipo = new SelectList(bl.ListaTipo(), "ID", "Nombre");
            return PartialView("_ListaAlmacen");
        }

        public ActionResult EditAlmacen(int IdAlma, int IdTipo,string Nombre, HttpPostedFileBase fileUpload)
        {
            byte[] imagenData = null;
            if (fileUpload != null && fileUpload.ContentLength > 0)
            {
                using (var imagen = new BinaryReader(fileUpload.InputStream))
                {
                    imagenData = imagen.ReadBytes(fileUpload.ContentLength);
                }

            }

            TempData["Error"] = Nombre + " No Guardado";
            AlmacenBL bl = new AlmacenBL();
            var respuesta = bl.EditarAlmacen(IdAlma, IdTipo, Nombre, imagenData);
            if (respuesta.ID > 0)
            {
                TempData["Mensaje"] = Nombre + " Editado Satisfactoriamente";
            }

            ViewBag.ListaTipo = new SelectList(bl.ListaTipo(), "ID", "Nombre");
            ViewBag.ListaAlmacen = bl.ListaAlmacen(IdTipo);
            return PartialView("_ListaAlmacen");
        }


        public ActionResult DeleteAlmacen(int IdAlma, int IdTipo, string Nombre)
        {
           
            TempData["Error"] = Nombre + " No Guardado";
            AlmacenBL bl = new AlmacenBL();
            if (bl.DeleteAlmacen(IdAlma) > 0)
            {
                TempData["Mensaje"] = Nombre + " Eliminado Satisfactoriamente";
            }

            ViewBag.ListaTipo = new SelectList(bl.ListaTipo(), "ID", "Nombre");
            ViewBag.ListaAlmacen = bl.ListaAlmacen(IdTipo);
            return PartialView("_ListaAlmacen");
        }
        public JsonResult JsonAlmaLista(int IdTipo)
        {
            AlmacenBL bl = new AlmacenBL();
            return Json(bl.ListaAlmacen(IdTipo), JsonRequestBehavior.AllowGet);
        }
        

    }
}