using Cozy.Data.Context;
using Cozy.Data.Interfaces;
using Cozy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cozy.Data.Implementation.EFCore
{
    public class EFCoreHomeRepository : IHomeRepository
    {
        //Microsoft Implement EF Core DB 
        public Home Create(Home newHome)
        {
            using (var db = new CozyDbContext())
            {
                db.Homes.Add(newHome);
                db.SaveChanges();
            }
            return newHome;
        }

        public bool DeleteById(int homeId)
        {
            using (var db = new CozyDbContext())
            {
                var home = GetById(homeId);
                db.Homes.Remove(home);
                db.SaveChanges();
            }
            return true;
        }

        public Home GetById(int homeId)
        {
            using (var db = new CozyDbContext())
            {
                return db.Homes.Single(h => h.Id == homeId);
            }

        }

        public ICollection<Home> GetByLandlordId(string landlordId)
        {
            using (var db = new CozyDbContext())
            {
                return db.Homes.Where(h => h.LandlordId == landlordId).ToList();
            }
        }

        public Home Update(Home updatedHome)
        {
            using (var db = new CozyDbContext())
            {
                var update = GetById(updatedHome.Id);
                db.Entry(update).CurrentValues.SetValues(updatedHome);
                db.SaveChanges();
                return update;
            }
        }
    }
}
