using Cozy.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Cozy.Data.Context
{
    public class CozyDbContext : IdentityDbContext<AppUser>
    {
        //interpret models --> db entities
        // query entities
        public DbSet<Home> Homes { get; set; }
        public DbSet<Lease> Leases { get; set; }
        public DbSet<Maintenance> Maintenances { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<MaintenanceStatus> MaintenanceStatuses { get; set; }
        //public DbSet<landlord> Landlords { get; set; }
        //public DbSet<Tenant> Tenants { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\ProjectsV13; Database=Cozy; Trusted_Connection=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaintenanceStatus>().HasData(
                new MaintenanceStatus { Id = 1, Description = "New" },
                new MaintenanceStatus { Id = 2, Description = "In Progress" },
                new MaintenanceStatus { Id = 3, Description = "Completed" },
                new MaintenanceStatus { Id = 4, Description = "Cancelled" }
                );
        }

    }
}
