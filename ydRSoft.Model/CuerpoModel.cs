using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ydRSoft.Model
{
    public class CuerpoModel
    {
        public int ID { get; set; }
        public int ID_Moneda { get; set; }
        public string NMoneda { get; set; }
        public decimal TipCambio { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Inafecta { get; set; }
        public decimal Descuento { get; set; }
        public decimal Base { get; set; }
        public decimal IGV { get; set; }
        public decimal Total { get; set; }

        public CuerpoModel(decimal SubTotal, decimal Inafecta) {
            this.SubTotal = SubTotal;
            this.Inafecta = Inafecta;
            this.Total = SubTotal - Inafecta;
            this.IGV = ydR.Convertir.toIGV(Total);
            this.Base = Total - IGV;

        }
    }
}
