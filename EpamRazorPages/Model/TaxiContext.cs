using Microsoft.EntityFrameworkCore;

namespace EpamRazorPages.Model
{
    public class TaxiContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }

        public TaxiContext(DbContextOptions<TaxiContext> options)
            : base(options)
        {
            Database.EnsureCreated(); // todo remake with migrations
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users", "Taxi");

                entity.HasIndex(e => e.Name, "Name");

                entity.HasIndex(e => e.ContactNumber, "ContactNumber");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(60);

                entity.Property(e => e.ContactNumber).HasMaxLength(24);
            });
            

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Orders", "Taxi");

                entity.HasIndex(e => e.UserId, "UserID");

                entity.HasIndex(e => e.UserName, "UserName");

                entity.HasIndex(e => e.ContactNumber, "ContactNumber");

                entity.HasIndex(e => e.OrderDate, "OrderDate");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.UserName).HasMaxLength(60);

                entity.Property(e => e.ContactNumber).HasMaxLength(24);

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.CarDeliveryTime).HasColumnType("time");

                entity.Property(e => e.FromLocation).HasMaxLength(200);

                entity.Property(e => e.ToLocation).HasMaxLength(200);

                entity.Property(e => e.Cost)
                    .HasColumnType("money");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Orders_Users");
            });
        }
    }
}
