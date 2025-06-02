using System.ComponentModel.DataAnnotations;

namespace CoreSystem.Models
{
    public class Producto
    {
        [Key]
        public int IdProducto { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public int CantidadEnStock { get; set; }

        [Required]
        public decimal Precio { get; set; }

        public string Descripcion { get; set; }
    }
}