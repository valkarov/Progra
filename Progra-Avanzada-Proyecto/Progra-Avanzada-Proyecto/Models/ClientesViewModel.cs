using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Progra_Avanzada_Proyecto.Models
{
    public class ClientesViewModel
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string PreferenciasDieteticas { get; set; }
        public string TipoEvento { get; set; } 
    }


    public class ClientesEditViewModel
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string PreferenciasDieteticas { get; set; }
    }

}
