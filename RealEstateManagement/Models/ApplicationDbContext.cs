using Microsoft.EntityFrameworkCore;

namespace RealEstateManagement.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Property> Properties { get; set; }

        public DbSet<Agent> Agents { get; set; }

        public DbSet<Tenant> Tenants { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<MaintenanceRequest> MaintenanceRequests { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Payment>()
                .Property(p => p.Amount)
                .HasColumnType("decimal(18,2)"); // Sets precision to 18 digits, 2 after the decimal
        }

    }
}
