using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TermProject296N.Models;
using TermProject296N.Repository;
using Microsoft.AspNetCore.Mvc;
using TermProject296N.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TermProject296N.Controllers
{
    [Authorize(Roles = "Member")]
    public class PreferenceController : Controller
    {
        UserManager<User> user;
        IUser repository;
        IPartnerRequest prRepository;

        public PreferenceController(UserManager<User> usr, IUser repo, IPartnerRequest rpRepo) {
            user = usr;
            repository = repo;
            prRepository = rpRepo;
        }

        public async Task<ViewResult> Index() {
            var vm = new RequestViewModel();
            var u = await user.FindByNameAsync(HttpContext.User.Identity.Name);
            vm.Requests = prRepository.GetRequestByUser(u.UserName);

            return View(vm);
        }
       
        public IActionResult Delete(PartnerRequest p) {
            prRepository.Delete(p);

            TempData["message"] = "Your request has been deleted.";
            return RedirectToAction("Index", "Preference");
        }

        [HttpPost]
        public async Task<IActionResult> ProfileForm(ProfileViewModel vm) {

            var u = await user.FindByNameAsync(HttpContext.User.Identity.Name);

            u.Xbox_Gamertag = vm.Gamertag;
            u.PSN_UserName = vm.PSNName;
            u.Nintendo_FriendCode = vm.FriendCode;

            repository.Update(u);
            TempData["message"] = "User Prefences have been updated";
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public ViewResult ProfileForm() {

            var vm = new ProfileViewModel();


            return View(vm);
        }
    }
}
