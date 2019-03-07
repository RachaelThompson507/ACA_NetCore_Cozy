using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Cozy.Domain.Models;
using Cozy.Service.Services;
using Cozy.WebUI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cozy.WebUI.Controllers
{
    [Authorize(Roles="Landlord")]
    public class HomeController : Controller
    {
        //Dependency injection
        private readonly IHomeService _homeService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IHostingEnvironment _environment;

        //Constructor
        public HomeController(IHomeService homeService, UserManager<AppUser> userManager, IHostingEnvironment environment)
        {
            _homeService = homeService;
            _userManager = userManager;
            _environment = environment;
        }
        
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        //See homes listed out
        public IActionResult List()
        {
            var user = _userManager.GetUserId(User);
            var homes = _homeService.GetByLandlordId(user);
            return View(homes); //Collection of Homes (ICollection<Homes>)
        }

        [HttpGet]
        public IActionResult Create() => View();
        [HttpPost]
        public IActionResult Create(CreateHomeviewModel vm)
        {
            Home newHome = vm.home;
            var image = vm.FormImg;
            //upload image
            if(image !=null && image.Length >0)
            {
                //where image lives
                string storageFolder = Path.Combine(_environment.WebRootPath,"images/homes");
                //new image name
                string newImageName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(image.FileName)}";
                //image path + image name = full path
                string fullPath = Path.Combine(storageFolder, newImageName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    image.CopyTo(stream);
                }
                //image is uploaded - Successfully!
                newHome.ImageURL = $"/images/homes/{newImageName}";
            }
            //Add owner to home
            newHome.LandlordId = _userManager.GetUserId(User);
            //Save home
            _homeService.Create(newHome);
            return RedirectToAction("List");
        }
    }
}
