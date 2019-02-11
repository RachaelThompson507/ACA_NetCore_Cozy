using Cozy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cozy.Data.Interfaces
{
   public interface ILandlordRepository
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
}
