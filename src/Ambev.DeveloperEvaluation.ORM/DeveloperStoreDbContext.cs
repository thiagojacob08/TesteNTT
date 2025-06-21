using Ambev.DeveloperEvaluation.Domain.Entities;
using DeveloperStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM
{
    public class DeveloperStoreDbContext : DbContext
    {
        public DeveloperStoreDbContext(DbContextOptions<DeveloperStoreDbContext> options)
            : base(options) { }

        public DbSet<Venda> Vendas { get; set; }
        public DbSet<ItemVenda> ItensVenda { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Venda>(entity =>
            {
                entity.ToTable("Vendas");

                entity.HasKey(v => v.Id);

                entity.Property(v => v.Cliente).IsRequired();
                entity.Property(v => v.Filial).IsRequired();
                entity.Property(v => v.DataVenda).IsRequired();
                entity.Property(v => v.Cancelado).IsRequired();

                entity
                    .HasMany(typeof(ItemVenda), "_itens")
                    .WithOne()
                    .HasForeignKey("VendaId")
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<ItemVenda>(entity =>
            {
                entity.ToTable("ItensVenda");

                entity.HasKey(nameof(ItemVenda.Produto), "VendaId");

                entity.Property(i => i.Produto).IsRequired();
                entity.Property(i => i.Quantidade).IsRequired();
                entity.Property(i => i.PrecoUnitario).IsRequired();
                entity.Property(i => i.Desconto).IsRequired();
            });
        }
    }
}
