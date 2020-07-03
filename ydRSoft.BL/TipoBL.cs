using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ydRSoft.Model;
using ydRSoft.DataBase;

namespace ydRSoft.BL
{
    public class TipoBL
    {
        ydRSoftEntities context = new ydRSoftEntities();

        public List<TipoModel> ListaSede() {
            try {
                List<TipoModel> lista = new List<TipoModel>();
                var listaModel = context.Sede.ToList();
                if (listaModel != null) {
                    foreach (var item in listaModel) {
                        TipoModel temp = new TipoModel(item.ID,item.Nombre);
                        lista.Add(temp);
                    }
                }

                return lista;
            } catch {
                return null;
            }
        }

        public List<TipoModel> ListaDocumento()
        {
            try
            {
                List<TipoModel> lista = new List<TipoModel>();
                var listaModel = context.Documento.ToList();
                if (listaModel != null)
                {
                    foreach (var item in listaModel)
                    {
                        TipoModel temp = new TipoModel(item.ID, item.Nombre);
                        lista.Add(temp);
                    }
                }

                return lista;
            }
            catch
            {
                return null;
            }
        }

        public List<TipoModel> ListaTipo_Gasto()
        {
            try
            {
                List<TipoModel> lista = new List<TipoModel>();
                var listaModel = context.Gasto_Tipo.ToList();
                if (listaModel != null)
                {
                    foreach (var item in listaModel)
                    {
                        TipoModel temp = new TipoModel(item.ID, item.Nombre);
                        lista.Add(temp);
                    }
                }

                return lista;
            }
            catch
            {
                return null;
            }
        }

        public List<TipoModel> ListaMoneda()
        {
            try
            {
                List<TipoModel> lista = new List<TipoModel>();
                var listaModel = context.Moneda.ToList();
                if (listaModel != null)
                {
                    foreach (var item in listaModel)
                    {
                        TipoModel temp = new TipoModel(item.ID, item.Nombre);
                        lista.Add(temp);
                    }
                }

                return lista;
            }
            catch
            {
                return null;
            }
        }

        public List<TipoModel> ListaTipoAlma()
        {
            try
            {
                List<TipoModel> vmLista = new List<TipoModel>();

                var lista = context.Alma_Tipo.ToList();

                if (lista != null)
                {
                    for (int i = 1; i < lista.Count(); i++)
                    {
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
    }
}
