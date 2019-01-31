using System;
using System.Collections.Generic;

namespace Cozy.Domain.Models
{
    public class Landlord
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //navigation collection property
        public IEnumerable<Home> Homes { get; set; }
    }
}
