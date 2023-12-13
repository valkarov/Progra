using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Progra_Avanzada_Proyecto.Models
{
    public class InventarioViewModel
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }
        public int CantidadDisponible { get; set; }
    }

}