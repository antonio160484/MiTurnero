using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Mi_turnero.Models
{
    public class Usuario : IdentityUser
    {
        [Required]
        [StringLength(50)]
        public string? Nombre { get; set; } = null!;
        [Required]
        [StringLength(50)]
        public string? Apellido { get; set; } = null!;
        public Profesional? Profesional { get; set; }
        public Paciente? Paciente { get; set; }
    }
}
