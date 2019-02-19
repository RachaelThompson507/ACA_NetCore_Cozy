using System;

namespace Cozy.Domain.Models
{
    public class Maintenance
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Description { get; set; }

        //Relationships
        public int HomeId { get; set; }
        public string TenantId { get; set; }
        public AppUser Tenant { get; set; }
        public int MaintenanceStatus { get; set; }
        //nav reference 
        public Home Home { get; set; }
        public MaintenanceStatus MaintenanceStatuses { get; set; }

    }
}
