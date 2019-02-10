using Cozy.Data.Interfaces;
using Cozy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cozy.Data.Implementation.EFCore
{
    public class EFCorePaymentRepository : IPaymentRepository
    {
        public Payment Create(Payment newLease)
        {
            throw new NotImplementedException();
        }

        public bool DeleteById(int paymentId)
        {
            throw new NotImplementedException();
        }

        public Payment GetById(int paymentId)
        {
            throw new NotImplementedException();
        }

        public ICollection<Payment> GetByLeaseId(int leaseId)
        {
            throw new NotImplementedException();
        }

        public ICollection<Payment> GetByTenantId(string tenantId)
        {
            throw new NotImplementedException();
        }

        public Payment Update(Payment updatedLease)
        {
            throw new NotImplementedException();
        }
    }
}
