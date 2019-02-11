using Cozy.Data.Context;
using Cozy.Data.Interfaces;
using Cozy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cozy.Data.Implementation.EFCore
{
    public class EFCoreTenantRepository : ITenantRepository
    {
        public Tenant Create(Tenant newTenant)
        {
            using (var db = new CozyDbContext())
            {
                db.Tenants.Add(newTenant);
                db.SaveChanges();
            }
            return newTenant;
        }

        public bool DeleteById(string tenantId)
        {
            using (var db = new CozyDbContext())
            {
                var tenant = GetById(tenantId);
                db.Tenants.Remove(tenant);
                db.SaveChanges();
            }
            return true;
        }

        public Tenant GetById(string tenantId)
        {
            using (var db = new CozyDbContext())
            {
                return db.Tenants.Single(t => t.Id == tenantId);
            }
        }

        public Tenant Update(Tenant updatedTenant)
        {
            using (var db = new CozyDbContext())
            {
                var update = GetById(updatedTenant.Id);
                db.Entry(update).CurrentValues.SetValues(updatedTenant);
                db.SaveChanges();
                return update;
            }
        }
    }
}
