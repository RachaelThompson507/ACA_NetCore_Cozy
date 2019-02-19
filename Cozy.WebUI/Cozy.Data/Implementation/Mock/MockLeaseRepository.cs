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
        private List<Lease> Leases = new List<Lease>()
        {
            new Lease
            {
                Id = 1,
                HomeId = 1,
                StartDate = DateTime.Now.AddMonths(-3),
                EndDate = DateTime.Now.AddMonths(7),
                RentPrice = 800.00
            },
            new Lease
            {
                Id = 2,
                HomeId = 1,
                StartDate = DateTime.Now.AddMonths(-15),
                EndDate = DateTime.Now.AddMonths(-3),
                RentPrice = 800.00
            },
            new Lease
            {
                Id = 3,
                HomeId = 1,
                StartDate = DateTime.Now.AddMonths(-20),
                EndDate = DateTime.Now.AddMonths(-15),
                RentPrice = 800.00
            }
        };
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
