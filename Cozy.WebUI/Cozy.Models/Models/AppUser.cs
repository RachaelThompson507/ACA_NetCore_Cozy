using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cozy.Domain.Models
{
    public class AppUser : IdentityUser
    {
        //Landlord || Tenanat
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Income { get; set; }

        //Navigation properties
        public ICollection<Home>Homes { get; set; } //Landlord
        public ICollection<Lease> Leases { get; set; } //Tenant
        public ICollection<Maintenance> Maintenances { get; set; } //Tenant 
    }
}
