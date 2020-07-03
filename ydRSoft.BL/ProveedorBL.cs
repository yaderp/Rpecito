using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ydRSoft.DataBase;
using ydRSoft.Model;
namespace ydRSoft.BL
{
    public class ProveedorBL
    {
        ydRSoftEntities context = new ydRSoftEntities();
        public int AddProveedor(string RUC, string RazSocial, string Direccion)
        {
            try
            {
                var resultado = new System.Data.Entity.Core.Objects.ObjectParameter("ID", 0);
                var temp = context.sp_Insert_Proveedor(RUC, RazSocial, Direccion, resultado);
                int objId = Convert.ToInt32(resultado.Value);

                return objId;
            }
            catch { return -1; }
        }

        public ProveedorModel getProveedor(string RUC) {
            try {
                var objmodel = context.Proveedor.Where(x => x.RUC == RUC).FirstOrDefault();
                if (objmodel != null) {
                    return new ProveedorModel(objmodel.RUC, objmodel.RazSocial, objmodel.Direccion);
                }

                return new ProveedorModel("No Registrado!!!");
            } catch {
                return new ProveedorModel();
            }
        }

    }
}
