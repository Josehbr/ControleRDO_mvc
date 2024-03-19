using MEC.ControleRDO.Models;
using Microsoft.EntityFrameworkCore;

namespace MEC.ControleRDO.Context
{
    public class ControleRdoContext : DbContext
    {
        public ControleRdoContext() { }

        public ControleRdoContext(DbContextOptions<ControleRdoContext> options) : base(options) { }

        public DbSet<FiscalModel> Fiscal { get; set; }

        public DbSet<ObraModel> Obra { get; set; }

        public DbSet<RdoModel> Rdo { get; set; }

        public DbSet<UsuarioModel> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ObraModel>()
                .HasOne(o => o.Fiscal)
                .WithMany(f => f.Obras)
                .HasForeignKey(o => o.FiscalId)
                .OnDelete(DeleteBehavior.Restrict); 
                
            modelBuilder.Entity<RdoModel>()
                .HasOne(r => r.Obra)
                .WithMany(o => o.Rdos)
                .HasForeignKey(r => r.ObraId)
                .OnDelete(DeleteBehavior.Restrict); 
        }
    }
}
