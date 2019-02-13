using Cozy.Data.Context;
using Cozy.Data.Interfaces;
using Cozy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cozy.Data.Implementation.EFCore
{
    public class EFCoreMaintenanceRepository : IMaintenanceRepository
    {
        public Maintenance Create(Maintenance newMaintenance)
        {
            using (var db = new CozyDbContext())
            {
                db.Maintenances.Add(newMaintenance);
                db.SaveChanges();
            }
            return newMaintenance;
        }

        public bool DeleteById(int maintenanceId)
        {
            using (var db = new CozyDbContext())
            {
                var maintenance = GetById(maintenanceId);
                db.Maintenances.Remove(maintenance);
                db.SaveChanges();
            }
            return true;
        }

        public ICollection<Maintenance> GetByHomeId(int homeId)
        {
            using (var db = new CozyDbContext())
            {
                return db.Maintenances.Where(m => m.HomeId == homeId).ToList();
            }
        }

        public Maintenance GetById(int maintenanceId)
        {
            using (var db = new CozyDbContext())
            {
                return db.Maintenances.Single(m=> m.Id == maintenanceId);
            }
        }

        public ICollection<Maintenance> GetByTenantId(string tenantId)
        {
            using (var db = new CozyDbContext())
            {
               return db.Maintenances.Where(lm => lm.TenantId == tenantId).ToList();
            }
        }

        public ICollection<Maintenance> GetMaintenanceStatus(int maintenanceStatusId)
        {
            using (var db = new CozyDbContext())
            {
               return db.Maintenances.Where(m => m.MaintenanceStatus == maintenanceStatusId).ToList();
            }
        }

        public Maintenance Update(Maintenance updatedMaintenance)
        {
            using (var db = new CozyDbContext())
            {
                var update = GetById(updatedMaintenance.Id);
                db.Entry(update).CurrentValues.SetValues(updatedMaintenance);
                db.SaveChanges();
                return update;
            }
        }
    }
}
