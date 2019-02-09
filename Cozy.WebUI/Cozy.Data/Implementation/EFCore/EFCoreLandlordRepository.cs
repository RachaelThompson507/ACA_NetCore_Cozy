using Cozy.Data.Interfaces;
using Cozy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Cozy.Data.Context;

namespace Cozy.Data.Implementation.EFCore
{
    public class EFCoreLandlordRepository : ILandlordRepository
    {
        public landlord Create(landlord landlord)
        {
            using (var db = new CozyDbContext())
            {
                db.Landlords.Add(landlord);
                db.SaveChanges();
            }
            return landlord;
        }

        public bool DeleteById(string landlordId)
        {
            using (var db = new CozyDbContext())
            {
                var landLord = GetById(landlordId);
                db.Landlords.Remove(landLord);
                db.SaveChanges();
            }
            return true;
        }

        public landlord GetById(string landlordId)
        {
            using (var db = new CozyDbContext())
            {
                return db.Landlords.Single(l => l.Id == landlordId);
            }
        }

        public landlord Update(landlord updatedLandlord)
        {
            using (var db = new CozyDbContext())
            {
                var update = GetById(updatedLandlord.Id);
                db.Entry(update).CurrentValues.SetValues(updatedLandlord);
                db.SaveChanges();
                return update;
            }
        }
    }
}
