using System.ComponentModel.DataAnnotations;
using Mi_turnero.Enums;

namespace Mi_turnero.Models
{
    public class TurnoTrabajo
    {
        public int Id { get; set; }
        [Required (ErrorMessage = "El día de la semana es obligatorio.")]

        public string ProfesionalId { get; set; } = null!;
        public Profesional Profesional { get; set; } = null!;

        public DiaSemana Dia { get; set; }
        [Required (ErrorMessage = "La hora de inicio es obligatoria.")]
        
        public TimeSpan HoraInicio { get; set; }
        [Required(ErrorMessage = "La hora de fin es obligatoria.")]
        [Compare("HoraInicio", ErrorMessage = "La hora de fin debe ser mayor que la hora de inicio.")]      
        public TimeSpan HoraFin { get; set; }

    }
}
