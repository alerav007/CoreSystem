using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreSystem.Models
{
    public class Entrada
    {
        [Key]
        public int IdEntrada { get; set; }

        [Required]
        public int IdProducto { get; set; }

        [ForeignKey("IdProducto")]
        public Producto Producto { get; set; }

        [Required]
        public DateTime FechaEntrada { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [Required]
        public decimal PrecioCompra { get; set; }

        public string Observaciones { get; set; }
    }
}