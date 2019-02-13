using Cozy.Data.Interfaces;
using Cozy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cozy.Service.Services
{
    public interface IHomeService
    {
        //read
        Home GetById(int homeId);
        ICollection<Home> GetByLandlordId(string landlordId);
        //create
        Home Create(Home newHome);
        //delete
        bool DeleteById(int homeId);
        //update
        Home Update(Home Update);
    }


    public class HomeService : IHomeService
    {
        private readonly IHomeRepository _homeRepository;

        public HomeService(IHomeRepository homeRepository) =>
            _homeRepository = homeRepository;

        public Home GetById(int homeId) => 
            _homeRepository.GetById(homeId);

        public ICollection<Home> GetByLandlordId(string landlordId) => 
            _homeRepository.GetByLandlordId(landlordId);

        public Home Create(Home newHome) => 
            _homeRepository.Create(newHome);

        public bool DeleteById(int homeId) => 
            _homeRepository.DeleteById(homeId);

        public Home Update(Home updatedHome) => 
            _homeRepository.Update(updatedHome);
    }
}
