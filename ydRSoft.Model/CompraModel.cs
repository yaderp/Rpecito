using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ydRSoft.Model
{
    public class CompraModel
    {
        public int ID { set; get; }
        public string Codigo { set; get; }
        public int Sede { set; get; }
        public string RUC { set; get; }
        public string RazSocial { set; get; }
        public int IdDoc { set; get; }
        public string Serie { set; get; }
        public string Numero { set; get; }
        public string ID_Empl { set; get; }
        public string Fecha { set; get; }
        public decimal Inafecta { set; get; }
        public decimal Total { set; get; }
        public byte[] Img { set; get; }
        public int Estado { set; get; }

        public CompraModel()
        {
            this.Fecha = getfecha(DateTime.Now);
            this.Estado = 0;
        }

        public CompraModel(DateTime Fecha)
        {
            this.Fecha = getfecha(Fecha);
            this.Estado = 0;
        }

        private string getfecha(DateTime fecha)
        {
            int dia = fecha.Day;
            int mes = fecha.Month;
            string fech = "" + fecha.Year;

            if (mes < 10)
                fech = fech + "-0" + mes;
            else
                fech = fech + "-" + mes;

            if (dia < 10)
                fech = fech + "-0" + dia;
            else
                fech = fech + "-" + dia;

            return fech;
        }
    }
}
