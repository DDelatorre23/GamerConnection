using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TermProject296N.Models;
using TermProject296N.Models.ViewModel;
using TermProject296N.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TermProject296N.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        IPartnerRequest repository;
        IUser userRepo;
        UserManager<User> user;
        public AdminController(IPartnerRequest repo, IUser uRepo, UserManager<User> mngr) {
            repository = repo;
            userRepo = uRepo;
            user = mngr;
        }

        public ViewResult Index()
        {
            var vm = new UserViewModel();
            vm.Users = userRepo.GetAllUsers().ToList();
            return View(vm);
        }

        public ViewResult PullRequests() {
            var vm = new RequestViewModel();
            
            vm.Requests = repository.GetAllPartnerRequests().ToList();

            
            return View("Requests", vm);
        }
    }
}
