using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cozy.Domain.Models;
using Cozy.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cozy.WebUI.Controllers
{
    public class HomeController : Controller
    {
        //Dependency injection
        private readonly IHomeService _homeService;

        //Constructor
        public HomeController(IHomeService homeService)
        {
            _homeService = homeService;
        }
        
        // GET: /<controller>/
        public IActionResult Index()
        {
            
            var home = _homeService.GetById(1);
            return View(home);
        }
    }
}
