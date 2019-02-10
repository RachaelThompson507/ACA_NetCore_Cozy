using Cozy.Data.Interfaces;
using Cozy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cozy.Data.Implementation.EFCore
{
    public class EFCoreTenantRepository : ITenantRepository
    {
        public Tenant Create(Tenant newTenant)
        {
            throw new NotImplementedException();
        }

        public bool DeleteById(int tenantId)
        {
            throw new NotImplementedException();
        }

        public Tenant GetById(int tenantId)
        {
            throw new NotImplementedException();
        }

        public ICollection<Home> GetByLeaseId(int leaseId)
        {
            throw new NotImplementedException();
        }

        public Tenant Update(Tenant updatedTenant)
        {
            throw new NotImplementedException();
        }
    }
}
