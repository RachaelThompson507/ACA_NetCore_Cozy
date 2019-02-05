using System;
using System.Collections.Generic;

namespace Cozy.Domain.Models
{
    public class Tenant
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Income { get; set; }
        public string PhoneNumber { get; set; }

        //inverse relationship
        public IEnumerable<Payment> Payments { get; set; }
        //Could add LEASE - MAINTENANCE ETC
        public IEnumerable<Lease> Leases { get; set; }
        public IEnumerable<Maintenance>Maintenences { get; set; }
    }
}
