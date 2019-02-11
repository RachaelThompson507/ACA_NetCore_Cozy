using Cozy.Data.Interfaces;
using Cozy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cozy.Data.Implementation.Mock
{
    public class MockLeaseRepository : ILeaseRepository
    {
        private List<Lease> Leases = new List<Lease>();
        public Lease Create(Lease newLease)
        {
            newLease.Id = Leases.OrderByDescending(le => le.Id).Single().Id + 1;
            return newLease;
        }

        public bool DeleteById(int leaseId)
        {
            var lease = GetById(leaseId);
            Leases.Remove(lease);
            return true;
        }

        public ICollection<Lease> GetByHomeId(int homeId)
        {
            return Leases.FindAll(le => le.HomeId == homeId);
        }

        public Lease GetById(int leaseId)
        {
            return Leases.Single(le => le.Id == leaseId);
        }

        public ICollection<Lease> GetByTenantId(string tenantId)
        {
            return Leases.FindAll(le => le.TenantId == tenantId);
        }

        public Lease Update(Lease updatedLease)
        {
            DeleteById(updatedLease.Id);
            Leases.Add(updatedLease);
            return updatedLease;
        }
    }
}
