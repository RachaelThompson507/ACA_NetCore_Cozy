using Cozy.Domain.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cozy.WebUI.ViewModels
{
    public class CreateHomeviewModel
    {
        public Home home { get; set; }
       
        public IFormFile FormImg { get; set; }
    }
}
