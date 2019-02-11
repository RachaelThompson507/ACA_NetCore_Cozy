using Cozy.Data.Context;
using Cozy.Data.Interfaces;
using Cozy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cozy.Data.Implementation.EFCore
{
    public class EFCorePaymentRepository : IPaymentRepository
    {
        public Payment Create(Payment newPayment)
        {
            using (var db = new CozyDbContext())
            {
                db.Payments.Add(newPayment);
                db.SaveChanges();
            }
            return newPayment;
        }

        public bool DeleteById(int paymentId)
        {
            using (var db = new CozyDbContext())
            {
                var payment = GetById(paymentId);
                db.Payments.Remove(payment);
                db.SaveChanges();
            }
            return true;
        }

        public Payment GetById(int paymentId)
        {
            using (var db = new CozyDbContext())
            {
                return db.Payments.Single(p => p.Id == paymentId);
            }
        }

        public ICollection<Payment> GetByLeaseId(int leaseId)
        {
            using (var db = new CozyDbContext())
            {
                var paymentLease = db.Payments.Select(p => p.LeaseId == leaseId).ToList() as ICollection<Payment>;
                return paymentLease;
            }
        }

        public ICollection<Payment> GetByTenantId(string tenantId)
        {
            using (var db = new CozyDbContext())
            {
                var tenantPayment = db.Payments.Select(p => p.TenantId == tenantId).ToList() as ICollection<Payment>;
                return tenantPayment;
            }
        }

        public Payment Update(Payment updatedPayment)
        {
            using (var db = new CozyDbContext())
            {
                var update = GetById(updatedPayment.Id);
                db.Entry(update).CurrentValues.SetValues(updatedPayment);
                db.SaveChanges();
                return update;
            }
        }
    }
}
