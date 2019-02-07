using Cozy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cozy.Data.Interfaces
{
   public interface ILandlordRepository
    {
        //create
        Landlord Create(Landlord landlord);

        //read
        Landlord GetById(string landlordId);

        //update
        Landlord Update(Landlord updatedLandlord);

        //delete
        bool DeleteById(int landlordId);
    }
}
