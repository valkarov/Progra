//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Progra_Avanzada_Proyecto_API
{
    using System;
    using System.Collections.Generic;
    
    public partial class Eventos
    {
        public int ID { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public Nullable<System.TimeSpan> Hora { get; set; }
        public string Ubicacion { get; set; }
        public string Tipo { get; set; }
        public Nullable<int> ClienteID { get; set; }
        public Nullable<int> EmpleadoID { get; set; }
    
        public virtual Clientes Clientes { get; set; }
        public virtual Empleados Empleados { get; set; }
    }
}
