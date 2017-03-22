using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TermProject296N.Models;
using TermProject296N.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

// TODO: still needs testing and needs to configure the Startup.cs file
namespace TermProject296N.Controllers
{
    public class AuthenticationController : Controller
    {
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;

        public AuthenticationController(UserManager<User> usrMgr, SignInManager<User> sim) {
            userManager = usrMgr;
            signInManager = sim;
        }

        //public ViewResult Index() => View();

        public IActionResult Register() {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel vm) {
            if (ModelState.IsValid) {
                User user = new User {
                    UserName = vm.Username,
                    FirstName = vm.FirstName,
                    LastName = vm.LastName,
                    Email = vm.Email
                };
                IdentityResult result = await userManager.CreateAsync(user, vm.Password);

                if (result.Succeeded) {
                    await userManager.AddToRoleAsync(user, "Member");
                    TempData["message"] = $"Success! Welcome to Gamer Connection, {user.UserName}!";
                    return RedirectToAction("Index", "Home"); // TODO: add roles when user register

                } else {
                    foreach (IdentityError error in result.Errors) {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            // We get here either if the model state is invalid or if xreate user fails
            return View(vm);
        }

        [AllowAnonymous]
        public ViewResult Login() {
            return View(new LoginViewModel());
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel vm) {
            if (ModelState.IsValid) {
                User user = await userManager.FindByNameAsync(vm.UserName);
                if (user != null) {
                    await signInManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult result =
                            await signInManager.PasswordSignInAsync(
                                user, vm.Password, false, false);
                    if (result.Succeeded) {
                        TempData["message"] = $"Welcome back, {user.UserName}";
                        return RedirectToAction("Index", "Home");
                    }
                }
                ModelState.AddModelError(nameof(LoginViewModel.UserName),
                    "Invalid user or password");
            }
            return View(vm);
        }

        public async Task<IActionResult> Logout() {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
