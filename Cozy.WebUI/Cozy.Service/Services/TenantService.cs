using Cozy.Data.Interfaces;
using Cozy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cozy.Service.Services
{
    public interface ITenantService
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

    public class TenantService : ITenantService
    {
        private readonly ITenantRepository _tenantRepository;

        public TenantService(ITenantRepository tenantRepository) =>
            _tenantRepository = tenantRepository;

        public Tenant Create(Tenant newTenant) =>
            _tenantRepository.Create(newTenant);

        public bool DeleteById(string tenantId) =>
            _tenantRepository.DeleteById(tenantId);

        public Tenant GetById(string tenantId) =>
            _tenantRepository.GetById(tenantId);

        public Tenant Update(Tenant updatedTenant) =>
            _tenantRepository.Update(updatedTenant);
    }
}
