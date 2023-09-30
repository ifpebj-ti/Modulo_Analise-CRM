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
        public DbSet<categoria_produto> categoria_produto { get; set; }
        public DbSet<item_venda> item_venda { get; set; }
        public DbSet<produto> produto { get; set; }
        public DbSet<produto_em_promocao> produto_em_promocao { get; set; }

        public DbSet<subcategoria_produto> subcategoria_produto { get; set; }
        public DbSet<usuario> usuario { get; set; }
        public DbSet<venda> venda { get; set; }
    }
}
