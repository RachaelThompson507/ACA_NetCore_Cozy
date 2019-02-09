using Cozy.Data.Interfaces;
using Cozy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Cozy.Data.Implementation.Mock
{
    public class MockLandlordRepository : ILandlordRepository
    {
        private List<landlord> Landlords = new List<landlord>();
        public landlord Create(landlord landlord)
        {
           Guid g = Guid.NewGuid();
            landlord.Id = g.ToString();
            Landlords.Add(landlord);
            return landlord;
            //This logic won't make sense with entities that are going to be assigned Id's
            //from the Identity Server-- hmmm... do we regex a random GUID?
           // landlord.Id = Landlord.OrderByDescending(l => l.Id).Single().Id + 1;
        } 

        public bool DeleteById(string landlordId)
        {
            var landlord = GetById(landlordId);
            Landlords.Remove(landlord);
            return true;
        }

        public landlord GetById(string landlordId)
        {
            return Landlords.Single(l => l.Id == landlordId);
        }

        public landlord Update(landlord updatedLandlord)
        {
            DeleteById(updatedLandlord.Id);
            Landlords.Add(updatedLandlord);
            return updatedLandlord;
        }
    }
}
