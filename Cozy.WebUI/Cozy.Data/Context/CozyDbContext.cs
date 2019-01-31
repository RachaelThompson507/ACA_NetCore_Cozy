using System;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using Cozy.Domain.Models;

namespace Cozy.Data.Context
{
    public class CozyDbContext : DbContext
    {
        //interpret models --> db entities
        // query entities
        public DbSet<Home> Homes { get; set; }
        public DbSet<Landlord> Landlords { get; set; }
        public DbSet<Lease> Leases { get; set; }
        public DbSet<Maintenence> Maintenences { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Tenant> Tenants { get; set; }

        public CozyDbContext(DbContextOptions<CozyDbContext> options):base(options)
        {
            
        }
            
    }
}
