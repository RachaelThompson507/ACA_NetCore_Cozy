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
        private readonly SignInManager<AppUser> _signInManager;
        private readonly List<IdentityRole> _roles;

        public AccountController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager,
            SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;

            //call Role Table one time
            _roles=_roleManager.Roles.ToList();
        }

        [HttpGet]
        public IActionResult Register()
        {
            //populate the roles before rendering the views
            var rVm = new RegisterViewModel
            {
                Roles = new SelectList(_roles)
            };
            return View(rVm);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel rVm)
        {
            if (ModelState.IsValid)
            {
                //register user
                var user = new AppUser
                {
                    Email = rVm.Email,
                    UserName = rVm.Email
                };

                var result=await _userManager.CreateAsync(user, rVm.Password);

                if(result.Succeeded)
                {
                    //new user created- apply roles to User
                    await _userManager.AddToRoleAsync(user, rVm.Role);
                    //login user
                    await _signInManager.SignInAsync(user, true);
                    return RedirectToAction("Index", "Home");
                    
                }
                else
                {
                    foreach(var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                }
            };

            rVm.Roles = new SelectList(_roles);
            return View(rVm);
            
        }
    }
}