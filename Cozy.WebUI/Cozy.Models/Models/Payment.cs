using System;
namespace Cozy.Domain.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public DateTime PaidOn { get; set; }
        public double Amount { get; set; }

        public int LeaseId { get; set; }
        public Lease Lease { get; set; }
    }
}
