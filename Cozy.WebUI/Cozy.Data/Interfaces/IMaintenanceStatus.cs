using Cozy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cozy.Data.Interfaces
{
   public interface IMaintenanceStatus
    {
        //Create
        MaintenanceStatus Create(MaintenanceStatus newMaintenanceStatus);

        //Read
        MaintenanceStatus GetById(int maintenanceStatusId);

        //Update
        MaintenanceStatus Update(MaintenanceStatus maintenanceStatusId);

        //Delete
        bool DeleteById(int maintenanceStatusId);

    }
}
