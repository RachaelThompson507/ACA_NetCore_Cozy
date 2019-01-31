using System;
namespace Cozy.Domain.Models
{
    public class Maintenence
    {
        public int Id { get; set; }
        public int Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Description { get; set; }

        //Relationships
        public int HomeId { get; set; }
        public string TenantId { get; set; }
        //nav reference 
        public Home Home { get; set; }
        public Tenant Tenant { get; set; }
    }
}
