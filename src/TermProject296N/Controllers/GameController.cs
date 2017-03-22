using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TermProject296N.Models;
using TermProject296N.Repository;
using TermProject296N.Models.ViewModel;
// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TermProject296N.Controllers
{
    public class GameController : Controller
    {
        IGame repository;

        public GameController(IGame repo) {
            repository = repo;
        }


        // GET: /<controller>/
        public ViewResult Index()
        {
            GameViewModel vm = new GameViewModel();
            vm.Games = repository.GetAllGames().ToList();

            return View(vm);
        }
    }
}
