using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TermProject296N.Models;
using TermProject296N.Models.ViewModel;
using TermProject296N.Repository;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TermProject296N.Controllers
{
    public class UserController : Controller
    {
        IUser repository;

        public UserController(IUser repo) {
            repository = repo;
        }
        [HttpGet]
        public ViewResult ProfileForm(int userID)
        {
            var vm = new ProfileViewModel();
            vm.UserID = userID;

            return View("Profile", vm);
        }

        [HttpPost]
        public IActionResult ProfileForm(ProfileViewModel vm) {

            var user = repository.GetUserByID(vm.UserID);

            user.Xbox_Gamertag = vm.Gamertag;
            user.PSN_UserName = vm.PSNName;
            user.Nintendo_FriendCode = vm.FriendCode;

            repository.Update(user);

            return RedirectToAction("Index", "User");
        }
    }
}
