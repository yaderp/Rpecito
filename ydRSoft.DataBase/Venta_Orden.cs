//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ydRSoft.DataBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class Venta_Orden
    {
        public int ID { get; set; }
        public int ID_Sede { get; set; }
        public int ID_Cotiza { get; set; }
        public string ID_Cliente { get; set; }
        public string ID_Empleado { get; set; }
        public string Serie { get; set; }
        public string Numero { get; set; }
        public int Estado { get; set; }
        public System.DateTime Fecha_Reg { get; set; }
    
        public virtual Cliente Cliente { get; set; }
        public virtual Cotizacion Cotizacion { get; set; }
        public virtual Sede Sede { get; set; }
    }
}
