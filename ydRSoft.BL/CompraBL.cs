using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ydRSoft.Model;
using ydRSoft.DataBase;
namespace ydRSoft.BL
{
    public class CompraBL
    {

        ydRSoftEntities context = new ydRSoftEntities();

        //compra Estado 1 = Pendiente
        //compra Estado 3 = Aprobado
        public CompraModel CargarCompra(int IdGuia)
        {
            try
            {
                CompraModel mComp = null;
                var model = context.Compra.Where(x => x.ID == IdGuia).FirstOrDefault();

                if (model != null)
                {
                    mComp = new CompraModel(model.Fecha);
                    mComp.ID = model.ID;
                    mComp.RUC = model.Compra_Guia.ID_Prov;
                    mComp.RazSocial = model.Compra_Guia.Proveedor.RazSocial;
                    mComp.Serie = model.Serie;
                    mComp.Numero = model.Numero;
                    mComp.Estado = model.Estado;
                    mComp.Inafecta = model.Inafecta;
                    mComp.Total = model.Total;
                    return mComp;
                }


                var guia = context.Compra_Guia.Where(x => x.ID == IdGuia&&x.Estado==ydR.Estado.ENVIADO).FirstOrDefault();
                if (guia != null)
                {
                    mComp = new CompraModel();
                    mComp.ID = guia.ID;
                    mComp.RUC = guia.ID_Prov;
                    mComp.RazSocial = guia.Proveedor.RazSocial;
                    mComp.Codigo = guia.Serie + " - " + CompletaNumero(guia.Numero);
                }

                return mComp;
            }
            catch
            {
                return null;
            }
        }
        public RespuestaModel GetImgCompra(int IdComp)
        {
            try
            {
                var model = context.Compra.Where(x => x.ID == IdComp).FirstOrDefault();
                if (model != null)
                {
                    string filtro = Convert.ToBase64String(model.Img);
                    return new RespuestaModel(model.ID, model.Serie + " - " + model.Numero, false, filtro);
                }

                return new RespuestaModel("Sin Imagen");
            }
            catch
            {
                return new RespuestaModel();
            }
        }
        public RespuestaModel AddCompra(CompraModel mComp)
        {
            try
            {
                if (ValidaCompra(mComp.RUC, mComp.Serie.ToUpper(), mComp.Numero))
                {
                    return new RespuestaModel("Comprobante Duplicada");
                }
                var fecha = Convert.ToDateTime(mComp.Fecha);
                var resultado = new System.Data.Entity.Core.Objects.ObjectParameter("ID", 0);
                var temp = context.sp_Insert_Compra(mComp.ID, mComp.Sede, mComp.IdDoc, mComp.Serie.ToUpper(), mComp.Numero, fecha, mComp.ID_Empl,mComp.Inafecta,mComp.Total, mComp.Img, resultado);
                int objId = Convert.ToInt32(resultado.Value);
                if (objId > 0)
                    return new RespuestaModel(objId, ydR.Mensaje.Save, false);

                return new RespuestaModel(ydR.Mensaje.DontSave);
            }
            catch
            {
                return new RespuestaModel();
            }
        }

        public RespuestaModel AprobarCompra(int IdComp) {
            try
            {
                

                return new RespuestaModel(ydR.Mensaje.DontSave);
            }
            catch
            {
                return new RespuestaModel();
            }
        } 
        private bool ValidaCompra(string RUC, string Serie,string Numero) {

            var model = context.Compra.Where(x => x.Compra_Guia.ID_Prov == RUC && x.Serie == Serie && x.Numero == Numero).FirstOrDefault();
            if (model != null) {
                return true;
            }
            return false;
        }


        public List<CompraModel> ListaCompra(int IdEstado) {

            try {
                List<CompraModel> vmLista = new List<CompraModel>();

                var lista = context.Compra.Where(x => x.Estado == 1).ToList();

                if (lista != null) {
                    lista = lista.OrderBy(x => x.Fecha).ToList();
                    foreach (var item in lista) {
                        string cod = "";
                        int contador = 1;
                        CompraModel temp = new CompraModel();

                        cod = "" + contador;
                        if (contador < 10)
                            cod = "0" + contador;

                        temp.ID = item.ID;
                        temp.Codigo = cod;
                        temp.RUC = item.Compra_Guia.ID_Prov;
                        temp.RazSocial = item.Compra_Guia.Proveedor.RazSocial;
                        temp.Serie = item.Serie;
                        temp.Numero = CompletaNumero(item.Numero);
                        temp.Total = item.Total;
                        temp.Inafecta = item.Inafecta;

                        vmLista.Add(temp);
                    }
                }

                return vmLista;
            } catch { return null; }
        }

        public RespuestaModel GetImgGuia(int IdGuia)
        {
            try
            {                
                var guia = context.Compra_Guia.Where(x => x.ID == IdGuia).FirstOrDefault();
                if (guia != null)
                {
                    string filtro = Convert.ToBase64String(guia.Img);
                    return new RespuestaModel(guia.ID, guia.Serie + " - " + guia.Numero, false, filtro);
                }

                return new RespuestaModel("Sin Imagen");
            }
            catch
            {
                return new RespuestaModel();
            }
        }
        public RespuestaModel AddGuia(CompraGuiaModel mGuia)
        {
            try
            {
                if (ValidaGuia(mGuia.RUC, mGuia.Serie.ToUpper(), mGuia.Numero)) {
                    return new RespuestaModel("Guia Duplicada");
                }
                var fecha = Convert.ToDateTime(mGuia.Fecha);
                var resultado = new System.Data.Entity.Core.Objects.ObjectParameter("ID", 0);
                var temp = context.sp_Insert_CompraGuia(mGuia.ID, mGuia.Sede, mGuia.RUC, mGuia.Serie.ToUpper(), mGuia.Numero, fecha, mGuia.ID_Empl, mGuia.Img, resultado);
                int objId = Convert.ToInt32(resultado.Value);
                if (objId > 0)
                    return new RespuestaModel(objId, ydR.Mensaje.Save, false);

                return new RespuestaModel(ydR.Mensaje.DontSave);
            }
            catch
            {
                return new RespuestaModel();
            }
        }

        private bool ValidaGuia(string RUC, string serie,string numero) {
            var model = context.Compra_Guia.Where(x => x.ID_Prov == RUC && x.Serie == serie && x.Numero == numero).FirstOrDefault();
            if (model != null) {
                return true;
            }
            return false;
        }

        public RespuestaModel AprobarGuia(int IdGuia, string IdEmpl) {
            try {

                if (EstadoGuia(IdGuia, IdEmpl, ydR.Estado.ENVIADO)) {

                    var lista = context.Compra_Detalle.Where(x => x.ID_Cuerpo == IdGuia).ToList();

                    if (lista != null) {
                        foreach (var item in lista) {
                            ActAlmacenGuia(item.ID_Alma, item.Cant_Real);
                        }
                    }
                    return new RespuestaModel(IdGuia, ydR.Mensaje.Save, false);
                }
                return new RespuestaModel(ydR.Mensaje.DontSave);
            }
            catch {
                return new RespuestaModel();
            }
        }

        private bool ActAlmacenGuia(int ID,decimal Cantidad) {
            try {
                var model = context.Almacen.Where(x => x.ID == ID).FirstOrDefault();
                if (model != null)
                {
                    model.Stock = model.Stock + Cantidad;
                    context.SaveChanges();
                }
                return true;
            } catch {
                return false;
            }
           
        }

        public bool EstadoGuia(int IdGuia, string IdEmpl,int IdEstado)
        {
            var model = context.Compra_Guia.Where(x => x.ID == IdGuia).FirstOrDefault();
            if (model != null)
            {
                model.ID_AProbado = IdEmpl;
                model.Estado = IdEstado;
                context.SaveChanges();

                return true;
            }
            return false;
        }

        public CompraGuiaModel CargarGuia(int IdOrd)
        {
            try
            {
                CompraGuiaModel vmGuia = null;
                var model = context.Compra_Guia.Where(x => x.ID == IdOrd).FirstOrDefault();

                if (model != null) {
                    vmGuia = new CompraGuiaModel();
                    vmGuia.Fecha = model.Fecha.ToShortDateString();
                    vmGuia.ID = model.ID;
                    vmGuia.RUC = model.ID_Prov;
                    vmGuia.RazSocial = model.Proveedor.RazSocial;
                    vmGuia.Serie = model.Serie;
                    vmGuia.Numero = model.Numero;
                    vmGuia.Estado = model.Estado;
                    vmGuia.Codigo = "OC - " + CompletaNumero(model.ID.ToString());
                    return vmGuia;
                }

                
                var orden = context.Compra_Orden.Where(x => x.ID == IdOrd&&x.Estado==ydR.Estado.ENVIADO).FirstOrDefault();
                if (orden != null) {
                    vmGuia = new CompraGuiaModel();
                    vmGuia.ID = orden.ID;
                    vmGuia.RUC = orden.ID_Prov;
                    vmGuia.RazSocial = orden.Proveedor.RazSocial;
                    vmGuia.Codigo = "OC - " + CompletaNumero(orden.ID.ToString());
                }

                return vmGuia;
            }
            catch
            {
                return null;
            }
        }

        public int EditDetGuia(CompraDetModel mDet)
        {
            try
            {
                var model = context.Compra_Detalle.Where(x => x.ID == mDet.ID).FirstOrDefault();

                if (model != null) {
                    model.Observ = mDet.Observ;
                    model.Cant_Real = mDet.Cantidad;
                    context.SaveChanges();

                    return model.ID_Cuerpo;
                }

                return 0;
            }
            catch
            {
                return -1;
            }
        }
        public List<CompraGuiaModel> ListaGuia(int Estado)
        {
            try
            {
                List<CompraGuiaModel> vmLista = new List<CompraGuiaModel>();
                var lista = context.Compra_Guia.Where(x => x.Estado == Estado).ToList();

                if (lista != null) {
                    lista = lista.OrderBy(x => x.Fecha).ToList();
                    int contador = 1;
                    string cod = "";
                    foreach (var item in lista) {
                        CompraGuiaModel temp = new CompraGuiaModel();
                        cod = "" + contador;
                        if (contador < 10) {
                            cod = "0" + contador;
                        }

                        temp.ID = item.ID;
                        temp.Codigo = cod;
                        temp.RUC = item.ID_Prov;
                        temp.RazSocial = item.Proveedor.RazSocial;
                        temp.Serie = item.Serie;
                        temp.Numero = item.Numero;
                        temp.Fecha = item.Fecha.ToShortDateString();
                        temp.Estado = item.Estado;
                        vmLista.Add(temp);
                        contador++;
                    }
                }

                return vmLista;
            }
            catch
            {
                return null;
            }
        }
        #region Orden Compra

        public RespuestaModel AddOrden(CompraOrdModel mOrden)
        {
            try
            {
                var model = context.Compra_Orden.Where(x => x.ID_Empleado == mOrden.ID_Empl && x.Estado == ydR.Estado.NUEVO && x.ID_Prov == mOrden.RUC).FirstOrDefault();

                if (model == null) {
                    if (AddProveedor(mOrden.RUC, mOrden.RazSocial))
                    {
                        var resultado = new System.Data.Entity.Core.Objects.ObjectParameter("ID", 0);
                        var temp = context.sp_Insert_CompraOrden(mOrden.Sede, mOrden.RUC, mOrden.ID_Empl, mOrden.Moneda, mOrden.Cambio, resultado);
                        int objId = Convert.ToInt32(resultado.Value);

                        if (objId > 0)
                        {
                            return new RespuestaModel(objId, ydR.Mensaje.Save, false, "OC - "+CompletaNumero(objId.ToString()));
                        }

                        return new RespuestaModel(ydR.Mensaje.DontSave);
                    }

                    return new RespuestaModel(mOrden.RUC + " Proveedor no Registrado");
                }

                return new RespuestaModel(model.ID, "Cotinuar Orden Compra", false, "OC - " + CompletaNumero(model.ID.ToString()));
            }
            catch
            {
                return new RespuestaModel();
            }
        }

        private string CompletaNumero(string Numero) {
            try {
                int cont = Numero.ToString().Count();
                string Letra = "";

                for (int i = cont; i < 8; i++) {
                    Letra = Letra + "0";
                }
                Letra = Letra + Numero;

                return Letra;

            } catch { return Numero.ToString(); }
        }
        
        private bool AddProveedor(string RUC, string RazSocial) {

            var prov = context.Proveedor.Where(x => x.RUC == RUC).FirstOrDefault();
            if (prov != null) return true;

            ProveedorBL bl = new ProveedorBL();
            if (bl.AddProveedor(RUC, RazSocial, "") > 0) return true;

            return false;
        }
        
        public RespuestaModel AddDetalle(CompraDetModel mDetalle)
        {
            try
            {
                var model = context.Compra_Detalle.Where(x => x.ID_Alma == mDetalle.ID_Alma && x.ID_Cuerpo == mDetalle.ID_Cuerpo && x.Estado != 0).FirstOrDefault();

                if (model == null) {
                    var resultado = new System.Data.Entity.Core.Objects.ObjectParameter("ID", 0);
                    var temp = context.sp_Insert_CompraDetalle(mDetalle.ID_Cuerpo, mDetalle.ID_Alma, mDetalle.Cantidad, mDetalle.Precio, mDetalle.Total, resultado);
                    int objId = Convert.ToInt32(resultado.Value);

                    if (objId > 0)
                    {
                        return new RespuestaModel(objId, ydR.Mensaje.Save, false);
                    }
                    return new RespuestaModel(ydR.Mensaje.DontSave);
                }
                return new RespuestaModel("Producto Duplicado");
            }
            catch
            {
                return new RespuestaModel();
            }
        }

        public RespuestaModel EditDetalle(CompraDetModel mDetalle)
        {
            try
            {
                var model = context.Compra_Detalle.Where(x => x.ID == mDetalle.ID).FirstOrDefault();
                if (model != null) {
                    model.ID_Alma = mDetalle.ID_Alma;
                    model.Precio = mDetalle.Precio;
                    model.Cantidad = mDetalle.Cantidad;
                    model.Cant_Real = mDetalle.Cantidad;
                    model.Total = mDetalle.Total;

                    context.SaveChanges();

                    return new RespuestaModel(ydR.Mensaje.Edit,false);
                }

                return new RespuestaModel(ydR.Mensaje.DontEdit);
            }
            catch
            {
                return new RespuestaModel();
            }
        }

        public RespuestaModel DeleteDetalle(int IdDet)
        {
            try
            {
                var model = context.Compra_Detalle.Where(x => x.ID == IdDet).FirstOrDefault();
                if (model != null)
                {
                    model.Estado = 0;
                    context.SaveChanges();

                    return new RespuestaModel(ydR.Mensaje.Delete, false);
                }

                return new RespuestaModel(ydR.Mensaje.DontDelete);
            }
            catch
            {
                return new RespuestaModel();
            }
        }
        
        public List<CompraDetModel> ListaDetalle(int IdCuerpo) {
            try {

                List<CompraDetModel> mLista = new List<CompraDetModel>();
                var lista = context.Compra_Detalle.Where(x => x.ID_Cuerpo == IdCuerpo && x.Estado != 0).ToList();

                if (lista != null) {
                    int contador = 1;
                    string cod = "";
                    foreach (var item in lista) {
                        cod = "" + contador;
                        if (contador < 10) {
                            cod = "0" + contador;
                        }

                        CompraDetModel temp = new CompraDetModel();
                        temp.ID = item.ID;
                        temp.Codigo = cod;
                        temp.Nombre = item.Almacen.Nombre;
                        temp.Precio = item.Precio;
                        temp.Cantidad = item.Cant_Real;
                        temp.Total = item.Total;
                        temp.Observ = item.Observ;
                        mLista.Add(temp);
                        contador++;
                    }
                }

                
                return mLista;
            } catch {
                return null;
            }
        }

        public RespuestaModel SerndOrden(int IdOrden) {
            try {
                var model = context.Compra_Orden.Where(x => x.ID == IdOrden).FirstOrDefault();

                if (model != null) {
                    
                    var lista = context.Compra_Detalle.Where(x => x.ID_Cuerpo == IdOrden).ToList();
                    decimal monto = 0;
                    if (lista != null)
                    {
                        foreach (var item in lista)
                        {
                            ActualizaAlmacen(item.ID_Alma, item.Cantidad);
                            monto = monto + item.Total;
                        }
                    }

                    model.Total = monto;
                    model.Estado = ydR.Estado.ENVIADO;
                    context.SaveChanges();
                    return new RespuestaModel(model.ID, ydR.Mensaje.Save, false);
                }
                return new RespuestaModel(ydR.Mensaje.DontSave);
            } catch { return new RespuestaModel(); }
        }
        
        private bool ActualizaAlmacen(int IdAlma,decimal cantidad) {
            try {
                var alma = context.Almacen.Where(x => x.ID == IdAlma).FirstOrDefault();

                if (alma != null) {
                    var cantAct = alma.Cantidad_Orden - cantidad;
                    if (cantAct < 0)
                        cantAct = 0;
                    alma.Cantidad_Orden = cantAct;
                    context.SaveChanges();
                    return true;
                }

                return false;
            } catch {
                return false;
            }

        }
        
        public List<CompraOrdModel> ListaOrden(int Estado)
        {
            try
            {
                List<CompraOrdModel> mLista = new List<CompraOrdModel>();
                var lista = context.Compra_Orden.Where(x => x.Estado == Estado).ToList();

                if (lista != null)
                {
                    int contador = 1;
                    string cod = "";
                    foreach (var item in lista)
                    {
                        cod = "" + contador;
                        if (contador < 10)
                        {
                            cod = "0" + contador;
                        }

                        CompraOrdModel temp = new CompraOrdModel();
                        temp.ID = item.ID;
                        temp.Codigo = cod;
                        temp.RazSocial = item.Proveedor.RazSocial;
                        temp.Fecha = item.Fecha_Reg.ToShortDateString();
                        temp.Cambio = item.Total;
                        temp.Doc = "OC - "+CompletaNumero(item.ID.ToString());
                        temp.ID_Empl = item.ID_Empleado;
                        mLista.Add(temp);
                        contador++;
                    }
                }
                return mLista;
            }
            catch
            {
                return null;
            }
        }

        #endregion
        #region Solicitud COmpra
        public RespuestaModel AddSolicitud(CompraSolModel mSol) {
            try {

                var prod = context.Compra_Solicitud.Where(x => x.ID_Alma == mSol.ID_Alma && x.ID_Empleado == mSol.ID_Empl && x.Estado == 1).FirstOrDefault();

                if (prod == null)
                {
                    var resultado = new System.Data.Entity.Core.Objects.ObjectParameter("ID", 0);
                    var temp = context.sp_Insert_CompraSol(mSol.Sede, mSol.ID_Empl, mSol.ID_Alma, mSol.Cantidad, resultado);
                    int objId = Convert.ToInt32(resultado.Value);

                    if (objId > 0)
                    {
                        return new RespuestaModel(objId, ydR.Mensaje.Save, false);
                    }

                    return new RespuestaModel(ydR.Mensaje.DontSave);
                }

                return new RespuestaModel(ydR.Mensaje.ProductDuplicado);                
            } catch {
                return new RespuestaModel();
            }
        }

        public RespuestaModel EditSolicitud(CompraSolModel mSol)
        {
            try
            {
                var model = context.Compra_Solicitud.Where(x => x.ID == mSol.ID).FirstOrDefault();

                if (model != null) {
                    model.ID_Alma = mSol.ID_Alma;
                    model.Cantidad = mSol.Cantidad;

                    context.SaveChanges();
                    return new RespuestaModel(model.ID, ydR.Mensaje.Edit, false);
                }

                return new RespuestaModel(ydR.Mensaje.DontEdit);
            }
            catch
            {
                return new RespuestaModel();
            }
        }

        public List<CompraSolModel> ListaDetSol(string IdEmpl) {
            try {
                List<CompraSolModel> mLista = new List<CompraSolModel>();
                var lista = context.Compra_Solicitud.Where(x => x.ID_Empleado == IdEmpl && x.Estado == 1).ToList();
                
                if (lista != null)
                {
                    string cod = "";
                    int contador = 1;
                    foreach (var item in lista) {
                        cod = "" + contador;
                        if (contador < 10)
                            cod = "0" + contador;
                        CompraSolModel temp = new CompraSolModel();
                        temp.ID = item.ID;
                        temp.Codigo = cod;
                        temp.Fecha = item.Fecha_Reg.ToShortDateString();
                        temp.Nombre = item.Almacen.Nombre;
                        temp.Cantidad = item.Cantidad;

                        mLista.Add(temp);
                        contador++;
                    }

                }
                return mLista;
            } catch {
                return null;
            }
        }
        
        public RespuestaModel EnviarSolicitud(string IdEmpl) {
            try {

                var lista = context.Compra_Solicitud.Where(x => x.ID_Empleado == IdEmpl && x.Estado == ydR.Estado.NUEVO).ToList();
                int contador = lista.Count();
                int Index = 0;
                if (lista != null) {
                    foreach (var item in lista) {
                        if (EstadoSol(item.ID, ydR.Estado.ENVIADO)) {
                            Index++;
                        }                        
                    }
                    string mensaje = ydR.Mensaje.Save;
                    if (Index != contador)
                    {
                        mensaje = (contador - Index).ToString() + "Sin Guardar";
                    }

                    return new RespuestaModel(1, mensaje, false);
                }
                return new RespuestaModel(ydR.Mensaje.DontSave);
            } catch {
                return new RespuestaModel();
            }
        }

        public RespuestaModel OpcSolicitud(int IdSol, string IdEmpl, int Estado, string Observ)
        {
            try
            {
                var model = context.Compra_Solicitud.Where(x => x.ID == IdSol).FirstOrDefault();
                if (model != null)
                {
                    model.ID_Aprobado = IdEmpl;
                    model.Estado = Estado;
                    model.Observacion = Observ;
                    context.SaveChanges();

                    if (Estado == ydR.Estado.APROBADO) {
                        CantOrdenAlma(model.ID_Alma, model.Cantidad);
                    }
                    
                    return new RespuestaModel(model.ID, ydR.Mensaje.Save, false);
                   
                }
                
                return new RespuestaModel(ydR.Mensaje.DontSave);
            }
            catch
            {
                return new RespuestaModel();
            }
        }

        
        private bool EstadoSol(int IdSol,int Estado) {
            try {

                var objmodel = context.Compra_Solicitud.Where(x => x.ID == IdSol).FirstOrDefault();

                if (objmodel != null) {
                    objmodel.Estado = Estado;
                    context.SaveChanges();
                    return true;
                }                
                return false;
            } catch {
                return false;
            }
        }

        private int CantOrdenAlma(int IdAlma, decimal Cantidad)
        {
            try
            {
                var objmodel = context.Almacen.Where(x => x.ID == IdAlma).FirstOrDefault();
                if (objmodel != null)
                {
                    objmodel.Cantidad_Orden = objmodel.Cantidad_Orden + Cantidad;
                    context.SaveChanges();
                    return 1;
                }
                return 0;
            }
            catch
            {
                return 0;
            }
        }

        public List<CompraSolModel> ListaAlmaSol()
        {
            try
            {
                List<CompraSolModel> mLista = new List<CompraSolModel>();
                var lista = context.Almacen.Where(x => x.Cantidad_Orden > 0).ToList();

                if (lista != null)
                {
                    foreach (var item in lista)
                    {
                        CompraSolModel temp = new CompraSolModel();
                        temp.ID = item.ID;
                        temp.Nombre = item.Nombre;
                        temp.Cantidad = item.Cantidad_Orden;
                        mLista.Add(temp);
                    }

                }
                return mLista;
            }
            catch
            {
                return null;
            }
        }
        
        public List<CompraSolModel> ListaSolicitud(int IdEstado)
        {
            try
            {
                List<CompraSolModel> mLista = new List<CompraSolModel>();
                var lista = context.Compra_Solicitud.Where(x => x.Estado == IdEstado).ToList();

                if (lista != null)
                {
                    string cod = "";
                    int contador = 1;
                    foreach (var item in lista)
                    {
                        cod = "" + contador;
                        if (contador < 10)
                            cod = "0" + contador;
                        CompraSolModel temp = new CompraSolModel();
                        temp.ID = item.ID;
                        temp.Codigo = cod;
                        temp.ID_Empl = item.ID_Empleado;
                        temp.Fecha = item.Fecha_Reg.ToShortDateString();
                        temp.Nombre = item.Almacen.Nombre;
                        temp.Cantidad = item.Cantidad;
                        temp.Observacion = item.Observacion;
                        temp.Aprobado = item.ID_Aprobado;
                        mLista.Add(temp);
                        contador++;
                    }

                }
                return mLista;
            }
            catch
            {
                return null;
            }
        }
        #endregion
    }
}
