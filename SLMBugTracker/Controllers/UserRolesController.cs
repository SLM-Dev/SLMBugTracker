using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SLMBugTracker.Controllers
{
    public class UserRolesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
