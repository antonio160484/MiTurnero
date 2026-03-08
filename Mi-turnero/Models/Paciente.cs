using System.ComponentModel.DataAnnotations;

namespace Mi_turnero.Models
{
    public class Paciente
    {
        [Key]
        public string UsuarioId { get; set; } = null!;
        public Usuario Usuario { get; set; } = null!;
    
        [Required(ErrorMessage = "Debe ingresar un número de teléfono.")]
        [Phone(ErrorMessage = "Ingrese un número de teléfono válido.")]
        public string Telefono { get; set; }
    
        [Required(ErrorMessage = "Debe ingresar un DNI.")]
        [Display(Name = "Numero de documento")]
        public string Dni { get; set; }
        public List<Turno>? Turnos { get; set; } 
        [DataType(DataType.Date)]
        public DateTime? FechaNac { get; set; }
        public string? Calle { get; set; }
        public int? Numero { get; set; }
        public string? Partido { get; set; }
        public string? Localidad { get; set; }
      
    }
}
