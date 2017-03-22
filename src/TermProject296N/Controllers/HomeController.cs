using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TermProject296N.Models.ViewModel;
using TermProject296N.Models;
using TermProject296N.Repository;
// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TermProject296N.Controllers
{
    public class HomeController : Controller
    {
        IGame repository;

        public HomeController(IGame repo) {
            repository = repo;
        }
        // GET: /<controller>/
        public IActionResult Index() {
            GameViewModel vm = new GameViewModel();
            vm.Games = repository.GetAllGames().ToList(); 
            return View(vm);
        }
    }
}
