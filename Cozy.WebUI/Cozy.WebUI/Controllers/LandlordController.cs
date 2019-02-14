using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cozy.Domain.Models;
using Cozy.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cozy.WebUI.Controllers
{
    public class LandlordController : Controller
    {
        private readonly IHomeService _homeService;
        private readonly ILeaseService _leaseService;

        public LandlordController(IHomeService homeService)=>
            _homeService = homeService;

        public LandlordController(ILeaseService leaseService) =>
            _leaseService = leaseService;

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult HomeHistory(int id)
        {
            Home home = _homeService.GetById(id);
            ICollection<Lease> leases = _leaseService.GetByHomeId(id);
            return View();
        }
    }
}