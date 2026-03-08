using System.ComponentModel.DataAnnotations;

namespace Mi_turnero.Models
{
    public class BloqueoAgenda
    {
        public int Id { get; set; }
        public string? MedicoId { get; set; }
        [Required (ErrorMessage ="El médico es obligatorio")] 
        public Profesional? Medico{ get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fin { get; set; }
        [StringLength(255, ErrorMessage = "Maximo 255 caracteres")]
        public string? Motivo { get; set; }
    }
}
