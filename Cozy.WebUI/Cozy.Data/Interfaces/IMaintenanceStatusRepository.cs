using Cozy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cozy.Data.Interfaces
{
   public interface IMaintenanceStatusRepository
    {

        //Read
        MaintenanceStatus GetById(int maintenanceStatusId);
        ICollection<MaintenanceStatus> GetAll();
       
    }
}
