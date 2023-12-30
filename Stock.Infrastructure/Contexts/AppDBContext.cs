using Microsoft.EntityFrameworkCore;
using Stock.Domain.Entities.Products;
using Stock.Domain.Entities.ProductStores;
using Stock.Domain.Entities.Shared;
using Stock.Domain.Entities.Stores;

namespace Stock.Infrastructure.Contexts
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        public DbSet<Store> Stores { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductStore> ProductStores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductStore>()
                .HasKey(ps => new { ps.ProductId, ps.StoreId });

            modelBuilder.Entity<ProductStore>()
                .HasOne(ps => ps.Product)
                .WithMany(p => p.ProductStores)
                .HasForeignKey(ps => ps.ProductId);

            modelBuilder.Entity<ProductStore>()
                .HasOne(ps => ps.Store)
                .WithMany(s => s.ProductStores)
                .HasForeignKey(ps => ps.StoreId);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                if (entry.State == EntityState.Deleted)
                {
                    entry.State = EntityState.Modified;
                    entry.Entity.IsDeleted = true;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }


    }
}
