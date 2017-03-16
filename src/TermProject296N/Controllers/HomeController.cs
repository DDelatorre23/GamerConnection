using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TermProject296N.Models.ViewModel;
// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TermProject296N.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index() {
            var userVm = new UserViewModel { Authenticated = false };
            if (HttpContext.User.Identity.IsAuthenticated) {
                userVm.Username = HttpContext.User.Identity.Name;

                userVm.Authenticated = true;
            }
            return View("Index", userVm);
        }
    }
}
