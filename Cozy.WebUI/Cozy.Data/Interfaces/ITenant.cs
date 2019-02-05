using System;
using System.Collections.Generic;
using System.Text;
using Cozy.Domain.Models;

namespace Cozy.Data.Interfaces
{
    public interface ITenant
    {
        //Create
        Tenant Create(Tenant newTenant);

        //Read
        Tenant GetById(int tenantId);
        ICollection<Home> GetByLeaseId(int leaseId);

        //Update
        Tenant Update(Tenant updatedTenant);

        //Delete
        bool DeleteById(int tenantId);

    }
}
