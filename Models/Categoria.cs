using System.ComponentModel.DataAnnotations;

namespace CoreSystem.Models
{
    public class Categoria
    {
        [Key]
        public int IdCategoria { get; set; }

        [Required]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}