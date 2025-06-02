using System.ComponentModel.DataAnnotations;

namespace CoreSystem.Models
{
    public class Proveedor
    {
        [Key]
        public int IdProveedor { get; set; }

        [Required]
        public string Nombre { get; set; }

        public string Telefono { get; set; }
        public string Correo { get; set; }

        public string Direccion { get; set; }
    }
}