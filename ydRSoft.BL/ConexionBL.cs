using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ydRSoft.Model;
using ydRSoft.DataBase;
namespace ydRSoft.BL
{
    public class ConexionBL
    {
        ydRSoftEntities context = new ydRSoftEntities();

        public ConexionModel getConexion()
        {
            try
            {
                ConexionModel mConexion = new ConexionModel();
                var objModel = context.Conexion.First();
                if (objModel != null)
                {
                    mConexion = new ConexionModel();
                    mConexion.RUC = objModel.RUC;
                    mConexion.Nombre = objModel.Nombre;
                    mConexion.Correo = objModel.Correo;
                    mConexion.Error = false;
                }

                //EmpleadoBL bl = new EmpleadoBL();
                //EmpleadoViewModel empl = new EmpleadoViewModel();
                //empl.DNI = "43114343";
                //empl.Correo = "yaderch@gmail.com";
                //empl.Nombres = "yader phool";
                //empl.Apellidos = "coñas hospino";
                //empl.ID_Cargo = 9;
                //empl.ID_Sexo = 1;
                //bl.AddEmpleado(empl);

                return mConexion;
            }
            catch
            {
                return null;
            }
        }

    }
}
