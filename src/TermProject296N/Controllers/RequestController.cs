using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TermProject296N.Models;
using TermProject296N.Repository;
using TermProject296N.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TermProject296N.Controllers
{
    public class RequestController : Controller
    {
        IPartnerRequest repository;
        IGame gameRepository;
        UserManager<User> user;

        public RequestController(IPartnerRequest repo, IGame gRepo, UserManager<User> usr) {
            repository = repo;
            user = usr;
            gameRepository = gRepo;

        }


        public async Task<IActionResult> Create(Game game) {

            Game g = gameRepository.GetGamesByTitle(game.Title).First();
            User u = await user.FindByNameAsync(HttpContext.User.Identity.Name);
            List<PartnerRequest> p = repository.GetUnfilledNotCreatedByUser(u.UserName);
            var unMatchedByGame = p.Where(r => r.SelectedGame == g).ToList();
            if (unMatchedByGame.Count == 0) {

                PartnerRequest request = new PartnerRequest() {
                    Requester = u,
                    RequestDate = DateTime.Now,
                    SelectedGame = g,
                    HasBeenMatched = false
                };
                repository.Create(request);
                TempData["message"] = "Your request has been created. Please check back later when we have found you a match";
            } else {
                var requestFound = unMatchedByGame.First();
                requestFound.MatchedPartner = u;
                requestFound.HasBeenMatched = true;
                requestFound.RequestCompleted = DateTime.Now;
                repository.Update(requestFound);

                PartnerRequest request = new PartnerRequest() {
                    Requester = u,
                    RequestDate = DateTime.Now,
                    SelectedGame = g,
                    HasBeenMatched = true,
                    RequestCompleted = DateTime.Now,
                    MatchedPartner = requestFound.Requester
                };
                repository.Create(request);

                TempData["message"] = "Eureka! We have found you a partner. Check your profile for details.";
            }
            return RedirectToAction("Index", "Game");
        }
    }
}
