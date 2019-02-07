using Cozy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cozy.Data.Interfaces
{
   public  interface IMaintenanceRepository
    {
        //Create
        Maintenance Create(Maintenance newMaintenance);

        //Read
        Maintenance GetById(int maintenanceId);
        ICollection<Maintenance> GetByTenantId(string tenantId);
        ICollection<Maintenance> GetByHomeId(int homeId);
        ICollection<Maintenance> GetMaintenanceStatus(int maintenanceStatusId);

        //Update
        Maintenance Update(Maintenance updatedLease);

        //Delete
        bool DeleteById(int maintenanceId);
    }
}
