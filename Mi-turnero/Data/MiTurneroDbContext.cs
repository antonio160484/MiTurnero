using Mi_turnero.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Mi_turnero.Data
{
    public class MiTurneroDbContext : IdentityDbContext<Usuario>
    {
        public MiTurneroDbContext(DbContextOptions<MiTurneroDbContext>options): base(options)
        {
          
        }

        public DbSet<Profesional> Profesionales{ get; set; }
        public DbSet<Turno> Turnos { get; set; }
        public DbSet<Especialidad> Especialidades { get; set; }
        public DbSet<BloqueoAgenda> Bloqueos { get; set; }
        public DbSet<TurnoTrabajo> TurnosTrabajo{ get; set; }
        public DbSet<Paciente> Pacientes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configuración de relaciones y restricciones adicionales
            modelBuilder.Entity<Turno>()
                .HasOne(t => t.Medico)
                .WithMany(p => p.Turnos)
                .HasForeignKey(t => t.ProfesionalId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Turno>()
                .HasOne(t => t.Paciente)
                .WithMany(p => p.Turnos)
                .HasForeignKey(t => t.PacienteId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
