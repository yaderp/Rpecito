using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ydRSoft.Model;
using ydRSoft.DataBase;

namespace ydRSoft.BL
{
    public class AlmacenBL
    {
        ydRSoftEntities context = new ydRSoftEntities();

        public int AddAlmacen(int IdTipo, string Nombre, byte[] Img)
        {
            try
            {
                var resultado = new System.Data.Entity.Core.Objects.ObjectParameter("ID", 0);
                var temp = context.sp_Insert_Almacen(IdTipo, Nombre.ToUpper(), "", Img, resultado);

                int objId = Convert.ToInt32(resultado.Value);
                return objId;
            }
            catch
            {
                return -1;
            }
        }

        public RespuestaModel EditarAlmacen(int ID,int IdTipo, string Nombre, byte[] Img)
        {
            try
            {
                var objmodel = context.Almacen.Where(x => x.ID == ID).FirstOrDefault();
                if (objmodel != null) {
                    objmodel.ID_Tipo = IdTipo;
                    objmodel.Nombre = Nombre.ToUpper();
                    objmodel.Img = Img;
                    context.SaveChanges();

                    return new RespuestaModel(IdTipo, Nombre + " Guardado Satisfactoriamente!!!", false);
                }
                return new RespuestaModel("Error al editar " + Nombre); ;
            }
            catch
            {
                return new RespuestaModel();
            }
        }

        public int DeleteAlmacen(int ID)
        {
            try
            {
                var objmodel = context.Almacen.Where(x => x.ID == ID && x.Estado > 0).FirstOrDefault();
                if (objmodel != null)
                {
                    objmodel.Estado = 0; 
                    context.SaveChanges();

                    return objmodel.ID;
                }
                return 0;
            }
            catch
            {
                return -1;
            }
        }

        public List<TipoModel> ListaTipo()
        {
            try
            {
                List<TipoModel> vmLista = new List<TipoModel>();

                var lista = context.Alma_Tipo.ToList();

                if (lista != null)
                {
                    for (int i = 1; i < lista.Count(); i++) {
                        TipoModel temp = new TipoModel(lista[i].ID, lista[i].Nombre);
                        vmLista.Add(temp);
                    }

                    TipoModel otros = new TipoModel(lista[0].ID, lista[0].Nombre);
                    vmLista.Add(otros);

                }

                return vmLista;
            }
            catch { return null; }
        }


        public List<ProductoModel> ListaAlmacen(int IdTipo)
        {
            try
            {
                var lista = context.Almacen.Where(x => x.ID_Tipo == IdTipo && x.Estado > 0).ToList();

                List<ProductoModel> vmLista = new List<ProductoModel>();
                
                if (lista != null)
                {
                    int conta = 1;
                    string cod = "";

                    lista = lista.OrderBy(x => x.Nombre).ToList();

                    foreach (var item in lista)
                    {
                        if (conta < 10)
                        {
                            cod = "0" + conta;
                        }
                        else {
                            cod = "" + conta;
                        }

                        ProductoModel temp = new ProductoModel();
                        temp.ID = item.ID;
                        temp.Codigo = cod;
                        temp.Area = item.Alma_Tipo.Nombre;
                        temp.Nombre = item.Nombre;
                        temp.Stock = item.Stock;
                        if (item.Img != null)
                            temp.ID_Img = true;

                        vmLista.Add(temp);
                        conta++;
                    }
                }

                return vmLista;
            }
            catch { return null; }
        }
    }
}
