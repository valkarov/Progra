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
    
    public partial class RegistroActividad
    {
        public int ID { get; set; }
        public Nullable<int> UsuarioID { get; set; }
        public Nullable<System.DateTime> FechaHora { get; set; }
        public string Accion { get; set; }
    
        public virtual Usuarios Usuarios { get; set; }
    }
}