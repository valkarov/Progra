using System.ComponentModel.DataAnnotations;

namespace Progra_Avanzada_Proyecto.Models
{
    public class ProductosViewModel
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }
        public string Tipo { get; set; }
        public decimal Precio { get; set; }
        public bool Disponibilidad { get; set; }
        // Agrega todas las propiedades que necesitas desde tu API
    }
}