//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Progra_Avanzada_Proyecto_API
{
    using System;
    using System.Collections.Generic;
    
    public partial class Evento
    {
        public int ID { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public Nullable<System.TimeSpan> Hora { get; set; }
        public string Ubicacion { get; set; }
        public string Tipo { get; set; }
        public Nullable<int> ClienteID { get; set; }
        public Nullable<int> EmpleadoID { get; set; }
    
        public virtual Cliente Cliente { get; set; }
        public virtual Empleado Empleado { get; set; }
    }
}
