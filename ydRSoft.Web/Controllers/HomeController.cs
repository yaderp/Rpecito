using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ydRSoft.BL;
using ydRSoft.Model;
using ydRSoft.ViewModel;
using ydRSoft.ydR;

namespace ydRSoft.Web.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {

            ConexionBL conn = new ConexionBL();
            LoginModel mlog = new LoginModel();
            var mcon = conn.getConexion();
            if (mcon != null)
            {
                mlog.Nombre = mcon.Nombre;
                mlog.Error = mcon.Error;
            }

            return View(mlog);
        }

        public ActionResult LandingPage()
        {
            return View();

        }

        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session["objEmpleado"] = null;

            return RedirectToAction("Index");
        }
        
        public ActionResult Login()
        {
            ConexionBL conn = new ConexionBL();
            LoginModel mlog = new LoginModel();
            var mcon = conn.getConexion();
            if (mcon != null) {                
                mlog.Nombre = mcon.Nombre;
                mlog.Error = mcon.Error;
            }
            
            return View(mlog);
        }

        [HttpPost]
        public ActionResult Login(LoginModel mLogin)
        {
            if (mLogin.DNI == null)
            {
                TempData["Mensaje"] = "Usuario y/o Contraseña Incorrecta!!!";
                return View(mLogin);
            }
            else
            {
                EmpleadoBL bl = new EmpleadoBL();
                var empleado = bl.getLogin(mLogin);

                if (empleado !=null)
                {
                    if (empleado.ID == 2)
                    {
                        return View("ActClave", new LoginModel(empleado.DNI, empleado.Nombres));
                    }

                    if (empleado.ID == 1)
                    {                        
                        Session["objEmpleado"] = empleado;
                        return RedirectToAction("Dashboard", "Home");

                    }

                    TempData["Mensaje"] = "Usuario y/o Contraseña Incorrecta!!!";
                    
                    return View(mLogin);
                }
                else
                {
                    TempData["Mensaje"] = "Error de Conexion!!!";
                    return RedirectToAction("Login");
                }
            }
            
        }



        public ActionResult ActClave()
        {
            return View(new LoginModel());
        }


        [HttpPost]
        public ActionResult ActClave(LoginModel mLogin)
        {
            if (mLogin.Clave == mLogin.ReClave)
            {
                EmpleadoBL bl = new EmpleadoBL();

                if (bl.ActualizaClave(mLogin.DNI, mLogin.Clave) > 0)
                {
                    return View("Login", mLogin);
                }
                TempData["Mensaje"] = "Intente en Otro Momento!!!";
            }
            else
            {
                TempData["Mensaje"] = "Escriba la misma Contraseña en ambos Campos";
            }
            
            return View(mLogin);
        }
        
    }
}