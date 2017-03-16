using TermProject296N.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TermProject296N.Components
{
    public class UserViewComponent : ViewComponent
    {
        //UserViewModel userVm;
        public UserViewComponent() {
            
        }
        public IViewComponentResult Invoke() {
            var userVm = new UserViewModel { Authenticated = false };
            if (HttpContext.User.Identity.IsAuthenticated) {
                userVm.Username = HttpContext.User.Identity.Name;

                userVm.Authenticated = true;
            }
            return View(userVm);
        }
    }
}
