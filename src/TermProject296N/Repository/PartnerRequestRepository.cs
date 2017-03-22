using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TermProject296N.Models;
using Microsoft.EntityFrameworkCore;
 

namespace TermProject296N.Repository
{
   
    public class PartnerRequestRepository : IPartnerRequest {

        ApplicationDbContext context;

        public PartnerRequestRepository (ApplicationDbContext ctx) {
            context = ctx;
        }
        public void Create(PartnerRequest request) {
            context.Requests.Add(request);
            context.SaveChanges();
        }

        public void Delete(PartnerRequest request) {
            context.Requests.Remove(request);
            context.SaveChanges();
        }

        public List<PartnerRequest> GetAllFilledRequests() {
            return context.Requests.Where(f => f.HasBeenMatched == true)
                .Include(m => m.Requester)
                .Include(g => g.SelectedGame)
                .ToList();
        }

        public IEnumerable<PartnerRequest> GetAllPartnerRequests() {
            return context.Requests
                .Include(m => m.Requester)
                .Include(p => p.MatchedPartner)
                .Include(g => g.SelectedGame)
                ;
        }

        public List<PartnerRequest> GetAllUnfilledRequests() {
            return context.Requests.Where(f => f.HasBeenMatched == false)
                .Include(m => m.Requester)
                .Include(g => g.SelectedGame)
                .ToList();

        }

        public List<PartnerRequest> GetUnfilledNotCreatedByUser(string username) {
            return context.Requests.Where(u => u.HasBeenMatched != true &&
                                                u.Requester.UserName != username)
                                                .Include(m => m.Requester)
                                                .Include(g => g.SelectedGame).ToList();
        }

        public List<PartnerRequest> GetRequestByUser(string username) {
            return context.Requests.Where(i => i.Requester.UserName == username)
                .Include(m => m.Requester)
                .Include(p => p.MatchedPartner)
                .Include(g => g.SelectedGame)
                .ToList()
                ;
                
        }

        public List<PartnerRequest> GetRequestsByGame(Game game) {
            return context.Requests.Where(g => g.SelectedGame == game)
                .Include(m => m.Requester).Include(g => g.SelectedGame)
                .ToList();
        }

        public void Update(PartnerRequest request) {
            context.Requests.Update(request);
            context.SaveChanges();
        }
    }
}
