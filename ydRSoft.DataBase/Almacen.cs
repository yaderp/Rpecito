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
    
    public partial class Almacen
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Almacen()
        {
            this.Compra_Detalle = new HashSet<Compra_Detalle>();
            this.Compra_Solicitud = new HashSet<Compra_Solicitud>();
            this.Receta = new HashSet<Receta>();
        }
    
        public int ID { get; set; }
        public int ID_Tipo { get; set; }
        public string Nombre { get; set; }
        public decimal Stock { get; set; }
        public decimal Cantidad_Orden { get; set; }
        public string Unidad { get; set; }
        public string Detalle { get; set; }
        public byte[] Img { get; set; }
        public int Estado { get; set; }
    
        public virtual Alma_Tipo Alma_Tipo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Compra_Detalle> Compra_Detalle { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Compra_Solicitud> Compra_Solicitud { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Receta> Receta { get; set; }
    }
}
