using System;
namespace Cozy.Domain.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public DateTime PaidOn { get; set; }
        public double Amount { get; set; }

        //Relationships
        public string TenantId { get; set; }
        public int LeaseId { get; set; }
        //nav reference
        public Tenant Tenant { get; set; }
        public Lease Lease { get; set; }
    }
}
