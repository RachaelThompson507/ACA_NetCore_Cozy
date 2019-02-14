using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cozy.Domain.Models;
using Cozy.Service.Services;
using Cozy.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Cozy.WebUI.Controllers
{
    public class LandlordController : Controller
    {
        private readonly IHomeService _homeService;
        private readonly ILeaseService _leaseService;

        public LandlordController(IHomeService homeService, ILeaseService leaseService)
        {
            _homeService = homeService;
            _leaseService = leaseService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult HomeHistory(int id)
        {
            HomeHistoryViewModel hhvm = new HomeHistoryViewModel();

            hhvm.Home = _homeService.GetById(id);
            hhvm.Leases = _leaseService.GetByHomeId(id);
            return View(hhvm);
        }
    }
}