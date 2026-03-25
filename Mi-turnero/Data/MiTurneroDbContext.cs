using Mi_turnero.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Mi_turnero.Data
{
    public class MiTurneroDbContext : IdentityDbContext<Usuario, IdentityRole, string>
    {
        public MiTurneroDbContext(DbContextOptions<MiTurneroDbContext> options) : base(options)
        {

        }

        public DbSet<Profesional> Profesionales { get; set; }
        public DbSet<Turno> Turnos { get; set; }
        public DbSet<Especialidad> Especialidades { get; set; }
        public DbSet<BloqueoAgenda> Bloqueos { get; set; }
        public DbSet<TurnoTrabajo> TurnosTrabajo { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configuración de relaciones y restricciones adicionales
            modelBuilder.Entity<Turno>()
                .HasOne(t => t.Profesional)
                .WithMany(p => p.Turnos)
                .HasForeignKey(t => t.ProfesionalId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Turno>()
                .HasOne(t => t.Paciente)
                .WithMany(p => p.Turnos)
                .HasForeignKey(t => t.PacienteId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Profesional>()
                .HasKey(p => p.UsuarioId);

            modelBuilder.Entity<Profesional>()
                .HasOne(p => p.Usuario)
                .WithOne(u => u.Profesional)
                .HasForeignKey<Profesional>(p => p.UsuarioId);

            modelBuilder.Entity<Paciente>()
                .HasKey(p => p.UsuarioId);

            modelBuilder.Entity<Paciente>()
                .HasOne(p => p.Usuario)
                .WithOne(u => u.Paciente)
                .HasForeignKey<Paciente>(p => p.UsuarioId);

            modelBuilder.Entity<TurnoTrabajo>()
                .HasOne(t => t.Profesional)
                .WithMany(p => p.TurnosTrabajo)
                .HasForeignKey(t => t.ProfesionalId)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
