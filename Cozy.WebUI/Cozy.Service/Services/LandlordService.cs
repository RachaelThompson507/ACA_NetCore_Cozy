using Cozy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cozy.Service.Services
{
    public interface ILandlordService
    {
        //create
        landlord Create(landlord landlord);

        //read
        landlord GetById(string landlordId);

        //update
        landlord Update(landlord updatedLandlord);

        //delete
        bool DeleteById(string landlordId);

    }

    public class LandlordService : ILandlordService
    {
        private readonly ILandlordService _landlordService;

        public LandlordService(ILandlordService landlordService) =>
            _landlordService = landlordService;

        public landlord Create(landlord landlord) =>
            _landlordService.Create(landlord);

        public bool DeleteById(string landlordId) =>
            _landlordService.DeleteById(landlordId);

        public landlord GetById(string landlordId) =>
            _landlordService.GetById(landlordId);

        public landlord Update(landlord updatedLandlord) =>
            _landlordService.Update(updatedLandlord);
    }
}
