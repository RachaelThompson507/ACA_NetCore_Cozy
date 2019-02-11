using Cozy.Data.Interfaces;
using Cozy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cozy.Data.Implementation.Mock
{
    public class MockMaintenanceRepository : IMaintenanceRepository
    {
        private List<Maintenance> Maintenances = new List<Maintenance>();
        public Maintenance Create(Maintenance newMaintenance)
        {
            newMaintenance.Id = Maintenances.OrderByDescending(m => m.Id).Single().Id + 1;
            return newMaintenance;
        }

        public bool DeleteById(int maintenanceId)
        {
            var maintenance = GetById(maintenanceId);
            Maintenances.Remove(maintenance);
            return true;
        }

        public ICollection<Maintenance> GetByHomeId(int homeId)
        {
            return Maintenances.FindAll(m => m.HomeId == homeId);
        }

        public Maintenance GetById(int maintenanceId)
        {
            return Maintenances.Single(m => m.Id == maintenanceId);
        }

        public ICollection<Maintenance> GetByTenantId(string tenantId)
        {
            return Maintenances.FindAll(m => m.TenantId == tenantId);
        }

        public ICollection<Maintenance> GetMaintenanceStatus(int maintenanceStatusId)
        {
            return Maintenances.FindAll(m => m.MaintenanceStatus == maintenanceStatusId);
        }

        public Maintenance Update(Maintenance updatedMaintenance)
        {
            DeleteById(updatedMaintenance.Id);
            Maintenances.Add(updatedMaintenance);
            return updatedMaintenance;
        }
    }
}
