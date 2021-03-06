﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TermProject296N.Models;
using TermProject296N.Models.ViewModel;
using TermProject296N.Repository;
using Microsoft.AspNetCore.Identity;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TermProject296N.Controllers
{
    public class UserController : Controller
    {
        UserManager<User> user;

        public UserController(UserManager<User> usr) {
            user = usr;
        }
       

        [HttpPost]
        public async Task<IActionResult> ProfileForm(ProfileViewModel vm) {

            var u = await user.FindByNameAsync(HttpContext.User.Identity.Name);

            u.Xbox_Gamertag = vm.Gamertag;
            u.PSN_UserName = vm.PSNName;
            u.Nintendo_FriendCode = vm.FriendCode;

            await user.UpdateAsync(u);
            
            return RedirectToAction("Index", "User");
        }
    }
}
