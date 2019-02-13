using Cozy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cozy.Service.Services
{
    public interface IMaintenanceService
    {
        //Create
        Maintenance Create(Maintenance newMaintenance);

        //Read
        Maintenance GetById(int maintenanceId);
        ICollection<Maintenance> GetByTenantId(string tenantId);
        ICollection<Maintenance> GetByHomeId(int homeId);
        ICollection<Maintenance> GetMaintenanceStatus(int maintenanceStatusId);

        //Update
        Maintenance Update(Maintenance updatedMaintenance);

        //Delete
        bool DeleteById(int maintenanceId);
    }

    public class MaintenanceService : IMaintenanceService
    {
        private readonly IMaintenanceService _maintenanceRepository;

        public MaintenanceService(IMaintenanceService maintenanceRepository) =>
            _maintenanceRepository = maintenanceRepository;

        public Maintenance Create(Maintenance newMaintenance) =>
            _maintenanceRepository.Create(newMaintenance);

        public bool DeleteById(int maintenanceId) =>
            _maintenanceRepository.DeleteById(maintenanceId);

        public ICollection<Maintenance> GetByHomeId(int homeId) =>
            _maintenanceRepository.GetByHomeId(homeId);

        public Maintenance GetById(int maintenanceId) =>
            _maintenanceRepository.GetById(maintenanceId);

        public ICollection<Maintenance> GetByTenantId(string tenantId) =>
            _maintenanceRepository.GetByTenantId(tenantId);

        public ICollection<Maintenance> GetMaintenanceStatus(int maintenanceStatusId) =>
            _maintenanceRepository.GetMaintenanceStatus(maintenanceStatusId);

        public Maintenance Update(Maintenance updatedMaintenance) =>
            _maintenanceRepository.Update(updatedMaintenance);
        
    }
}
