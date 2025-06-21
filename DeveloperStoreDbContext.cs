using DeveloperStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DeveloperStore.Infrastructure.Data
{
    public class DeveloperStoreDbContext : DbContext
    {
        public DeveloperStoreDbContext(DbContextOptions<DeveloperStoreDbContext> options) : base(options) { }

        public DbSet<Venda> Vendas { get; set; }
        public DbSet<ItemVenda> ItensVenda { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Venda>(entity =>
            {
                entity.HasKey(v => v.Id);
                entity.HasMany(v => v.Itens).WithOne().HasForeignKey("VendaId");
            });

            modelBuilder.Entity<ItemVenda>(entity =>
            {
                entity.HasKey(i => new { i.Produto, i.Quantidade }); 
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
