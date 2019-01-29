using System;
namespace Cozy.Domain.Models
{
    public class Lease
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double RentPrice { get; set; }

        //Relationships 
        public int HomeId { get; set; }
        public string TenantId { get; set; }
    }
}
