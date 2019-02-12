using Cozy.Data.Context;
using Cozy.Data.Interfaces;
using Cozy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cozy.Data.Implementation.EFCore
{
    class EFCoreLeaseRepository : ILeaseRepository
    {
        public Lease Create(Lease newLease)
        {
            using (var db = new CozyDbContext())
            {
                db.Leases.Add(newLease);
                db.SaveChanges();
            }
            return newLease;
        }

        public bool DeleteById(int leaseId)
        {
            using (var db = new CozyDbContext())
            {
                var lease = GetById(leaseId);
                db.Leases.Remove(lease);
                db.SaveChanges();
            }
            return true;
        }

        public ICollection<Lease> GetByHomeId(int homeId)
        {
            using (var db = new CozyDbContext())
            {
                return db.Leases.Where(le => le.HomeId == homeId).ToList();
            }
        }

        public Lease GetById(int leaseId)
        {
            using (var db = new CozyDbContext())
            {
                return db.Leases.Single(le => le.Id == leaseId);
            }
        }

        public ICollection<Lease> GetByTenantId(string tenantId)
        {
            using (var db = new CozyDbContext())
            {
                return db.Leases.Where(le => le.TenantId == tenantId).ToList();
            }
        }

        public Lease Update(Lease updatedLease)
        {
            using (var db = new CozyDbContext())
            {
                var update = GetById(updatedLease.Id);
                db.Entry(update).CurrentValues.SetValues(updatedLease);
                db.SaveChanges();
                return update;
            }
        }
    }
}
