using Mi_turnero.Models;

namespace Mi_turnero.ViewModels
{
    public class AltaProfesionalVM
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string? Matricula { get; set; }
        public int EspecialidadId { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }
        public string Password { get; set; }
        public List<TurnoTrabajo> TurnosTrabajo { get; set; } = new List<TurnoTrabajo>();
        public TimeSpan? DuracionTurno { get; set; }
        bool Activo { get; set; } = true;
    }
}
