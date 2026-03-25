using System.ComponentModel.DataAnnotations;
using Mi_turnero.Enums;

namespace Mi_turnero.Models
{
    public class Turno
    {
        public int Id { get; set; }
        public string ProfesionalId { get; set; }
        [Required (ErrorMessage = "Debe seleccionar un Profesional")]
        public Profesional Profesional { get; set; }
        public string PacienteId { get; set; }
        public Paciente Paciente { get; set; }
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }
        [DataType(DataType.Time)]
        public TimeSpan Hora { get; set; }
        [StringLength(250)]
        public string? MotivoConsulta { get; set; }
        public EstadoTurno Estado { get; set; } = EstadoTurno.Asignado;
        [StringLength(500)]
        public string Observaciones { get; set; }
        [Timestamp]
        public byte RowVersion { get; set; }
    }
}
