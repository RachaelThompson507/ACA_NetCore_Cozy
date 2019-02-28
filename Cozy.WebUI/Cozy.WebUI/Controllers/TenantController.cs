﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cozy.WebUI.Controllers
{
    public class TenantController : Controller
    {
        [Authorize (Roles = "Tenant")]
        public IActionResult Index()
        {
            return View();
        }
    }
}