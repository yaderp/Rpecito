using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ydRSoft.Model;
using ydRSoft.ViewModel;
using ydRSoft.DataBase;

namespace ydRSoft.BL
{
    public class ClienteBL
    {
        ydRSoftEntities context = new ydRSoftEntities();

        public int AddCliente(ClienteModel vmCliente) {
            try {
                var resultado = new System.Data.Entity.Core.Objects.ObjectParameter("ID", 0);
                var temp = context.sp_Insert_Cliente(vmCliente.RUC,vmCliente.RazSocial.ToUpper().ToUpper(),vmCliente.Direccion.ToUpper(),vmCliente.Pago
                                                    ,vmCliente.Credito,vmCliente.ID_Estado, resultado);
                int objId = Convert.ToInt32(resultado.Value);

                return objId;

            } catch { return -1; }
        }


        public ClienteViewModel getCliente(string RUC)
        {
            try {
                var objmodel = context.Cliente.Where(x => x.RUC == RUC).FirstOrDefault();
                
                if (objmodel != null)
                {
                    ClienteViewModel temp = new ClienteViewModel(false, ydR.Mensaje.ClienteSave);
                    temp.RUC = objmodel.RUC;
                    temp.RazSocial = objmodel.RazSocial;
                    temp.Direccion = objmodel.Direccion;
                    temp.Correo = objmodel.Correo;
                    temp.Pago = objmodel.Pago;
                    temp.Credito = objmodel.Credito;
                    temp.Telefono = objmodel.Telefono;
                    temp.Celular = objmodel.Celular;
                    temp.Sede = objmodel.Sede;
                    temp.ID_Estado = objmodel.ID_Estado;

                    return temp;
                }

                return new ClienteViewModel(ydR.Mensaje.DontSave);
            } catch {
                return new ClienteViewModel();
            }
            
        }
        
    }
}
