using System.ComponentModel.DataAnnotations;

namespace PrograAvanzadaProyectoAPI.Models
{
    public class SuministroModel
    {
        [Key]
        public int ID { get; set; }

        [StringLength(200)] 
        public string Descripcion { get; set; }


        [StringLength(100)] 
        public string Tipo { get; set; }

        [Range(0, 99999999.99)] 
        public decimal Precio { get; set; }

        public bool Disponibilidad { get; set; }
    }
}
