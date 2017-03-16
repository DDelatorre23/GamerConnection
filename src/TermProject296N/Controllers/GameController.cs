using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TermProject296N.Models;
using TermProject296N.Repository;
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

            return View(repository.GetAllGames().ToList());
        }
    }
}
// TODO: Game view model
//TODO: add actions to create a request.
//TODO: possibly create a view component for each game for nicer viewing. 


//TODO: delete migrations and update the two databases so that the right entities are in the right DB