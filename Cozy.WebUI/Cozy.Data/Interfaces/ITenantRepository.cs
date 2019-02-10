using System;
using System.Collections.Generic;
using System.Text;
using Cozy.Domain.Models;

namespace Cozy.Data.Interfaces
{
    public interface ITenantRepository
    {
        //Create
        Tenant Create(Tenant newTenant);

        //Read
        Tenant GetById(string tenantId);
        //ICollection<Home> GetByLeaseId(int leaseId);

        //Update
        Tenant Update(Tenant updatedTenant);

        //Delete
        bool DeleteById(string tenantId);

    }
}
