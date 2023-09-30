using Microsoft.EntityFrameworkCore;
using Modelo.Analise.Api.Domain;

namespace Modelo.Analise.Api.Repository
{
    public class ContextBd : DbContext
    {
        public ContextBd(DbContextOptions<ContextBd> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();

            base.OnConfiguring(optionsBuilder);
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<cliente>()
        //    .HasOne(c => c.enderecos)
        //    .WithMany(e => e.clientes)
        //    .HasForeignKey(c => c.id_endereco)
        //    .IsRequired();
        //}
        public DbSet<cliente> cliente { get; set; }
        public DbSet<enderecos> enderecos { get; set; }
    }
}
