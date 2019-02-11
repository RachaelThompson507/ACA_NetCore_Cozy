using Cozy.Data.Context;
using Cozy.Data.Interfaces;
using Cozy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cozy.Data.Implementation.EFCore
{
    public class EFCoreMaintenanceStatusRepository : IMaintenanceStatusRepository
    {
        public ICollection<MaintenanceStatus> GetAll()
        {
            using (var db = new CozyDbContext())
            {
                var maintenanceStatusAll = db.MaintenanceStatuses.Select(ms => ms.Id);
                return maintenanceStatusAll.ToList() as ICollection<MaintenanceStatus>;
            }
        }

        public MaintenanceStatus GetById(int maintenanceStatusId)
        {
            using (var db = new CozyDbContext())
            {
                var maintenanceStatus = db.MaintenanceStatuses.Single(ms => ms.Id == maintenanceStatusId);
                return maintenanceStatus;
            }
        }
    }
}
