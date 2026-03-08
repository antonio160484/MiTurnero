using System.ComponentModel.DataAnnotations;

namespace Mi_turnero.Models
{
    public class Profesional
    {
        [Key]
        public string UsuarioId { get; set; } = null!;
        public Usuario Usuario { get; set; } = null!;
      
        
        public string? Matricula { get; set; }
        public int EspecialidadId { get; set; }
        [Required (ErrorMessage = "La especialidad es obligatoria.")]
        public Especialidad Especialidad { get; set; }
        [Phone (ErrorMessage ="Ingrese un número de teléfono válido")]
        public string? Telefono { get; set; }
       
        [Required (ErrorMessage = "El horario de atención es obligatorio.")]
        public List<TurnoTrabajo> TurnosTrabajo { get; set; }
        [Required (ErrorMessage = "La duración del turno es obligatoria.")]
        [Range(typeof(TimeSpan), "00:15:00", "08:00:00", ErrorMessage = "La duración del turno debe ser entre 15 minutos y 8 horas.")]
        public TimeSpan? DuracionTurno { get; set; }
        public bool Activo { get; set; }
        public List<BloqueoAgenda>? Bloqueos { get; set; }
        public List<Turno>? Turnos { get; set; }
      
    }
}
