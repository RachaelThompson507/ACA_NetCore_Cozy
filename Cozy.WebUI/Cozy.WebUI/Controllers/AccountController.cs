using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cozy.Domain.Models;
using Cozy.WebUI.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cozy.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            //populate the roles before rendering the views
            var rVm = new RegisterViewModel
            {
                Roles = new SelectList(_roleManager.Roles.ToList())
            };
            return View(rVm);
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel rVm)
        {
            if (ModelState.IsValid)
            {
                //register user

            }
            return View(rVm);
            
        }
    }
}