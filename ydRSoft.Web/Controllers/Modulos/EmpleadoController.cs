using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ydRSoft.BL;
using ydRSoft.Model;
using ydRSoft.ViewModel;

namespace ydRSoft.Web.Controllers
{
    public class EmpleadoController : Controller
    {
        
        private List<TipoModel> ListaSexo()
        {
            try

            {
                List<TipoModel> lista = new List<TipoModel>();
                lista.Add(new TipoModel(1, "HOMBRE"));
                lista.Add(new TipoModel(2, "MUJER"));
                return lista;

            }
            catch
            {
                return null;
            }
        }

        public ActionResult Dashboard() {
            return View();
        }

        public ActionResult AddEmpleado(EmpleadoViewModel vmEmpleado)
        {
            if (Session["objEmpleado"] != null)
            {
                EmpleadoModel objEmpleado = (EmpleadoModel)Session["objEmpleado"];
                EmpleadoBL bl = new EmpleadoBL();
                ViewBag.ListaSexo = new SelectList(ListaSexo(), "ID", "Nombre");
                ViewBag.ListaCargo = new SelectList(bl.listaCargo(objEmpleado.ID_Cargo), "ID", "Nombre");
                if (vmEmpleado == null)
                    vmEmpleado = new EmpleadoViewModel();

                return View(vmEmpleado);
            }
            else {
                return RedirectToAction("Index","Home");
            }  
        }

        [HttpPost]
        public ActionResult AddEmpleado(EmpleadoViewModel vmEmpleado, int? Tipo)
        {
            if (!ModelState.IsValid) {
                TempData["Error"] = "Corrija los campos marcados !!!";
                return RedirectToAction("AddEmpleado",vmEmpleado);
            }

            EmpleadoBL bl = new EmpleadoBL();

            int IdEmpl = bl.AddEmpleado(vmEmpleado);

            if (IdEmpl <= 0)
            {
                TempData["Error"] = "Error de Conexion !!!";
                if (IdEmpl == 0)
                    TempData["Error"] = "Empleado No Guardado !!!";

                return View();
            }
            else
            {
                TempData["Mensaje"] = "Empleado Guardado";
                return RedirectToAction("AddEmpleado");
            }
        }


    }
}