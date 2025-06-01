// Models/User.cs
using System.ComponentModel.DataAnnotations;

namespace CoreSystem.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cargo { get; set; }
        public string Email { get; set; }
        public int? IdTipo_Usuario { get; set; }
    }
}
