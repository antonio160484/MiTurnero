using System.ComponentModel.DataAnnotations;

namespace Mi_turnero.Models
{
    public class Especialidad
    {
        public int Id { get; set; }
        [Required (ErrorMessage = "El nombre de la especialidad es obligatorio.")]
        public string Nombre { get; set; }
        public bool Activo { get; set; }
    }
}
