using Cozy.Data.Interfaces;
using Cozy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cozy.Data.Implementation.Mock
{
    public class MockHomeRepository : IHomeRepository
    {
        private List<Home> Homes = new List<Home>()
        {
            new Home
            {
                Id = 1,
                Address = "123 Fake Street",
                City = "Austin" , 
                State = "TX",
                ImageURL = "https://images.unsplash.com/photo-1513584684374-8bab748fbf90?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=1946&q=80"
            }
        };

        public Home Create(Home newHome)
        {
            newHome.Id = Homes.OrderByDescending(h => h.Id).Single().Id + 1;
            return newHome;
        }

        public bool DeleteById(int homeId)
        {
            var home = GetById(homeId);
            Homes.Remove(home);
            return true;
        }

        public Home GetById(int homeId)
        {
            return Homes.Single(h => h.Id == homeId);
        }

        public ICollection<Home> GetByLandlordId(string landlordId)
        {
            return Homes.FindAll(h => h.LandlordId == landlordId);
        }

        public Home Update(Home updatedHome)
        {
            DeleteById(updatedHome.Id);
            Homes.Add(updatedHome);
            return updatedHome;
        }
    }
}
