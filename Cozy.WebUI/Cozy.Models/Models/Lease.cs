using System;
namespace Cozy.Domain.Models
{
    public class Lease
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double RentPrice { get; set; }

        //Relationships (FK)
        public int HomeId { get; set; }
        public string TenantId { get; set; }
        public AppUser Tenant { get; set; }
        //navigational reference
        public Home Home { get; set; }

    }
}
