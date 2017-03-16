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
                .ToList();
        }

        public IEnumerable<PartnerRequest> GetAllPartnerRequests() {
            return context.Requests;
        }

        public List<PartnerRequest> GetAllUnfilledRequests() {
            return context.Requests.Where(f => f.HasBeenMatched == false)
                .Include(m => m.Requester)
                .ToList();
        }

        public PartnerRequest GetRequestByUserID(int userID) {
            return context.Requests.Where(i => i.Requester.UserID == userID)
                .Include(m => m.Requester)
                .Single();
                
        }

        public List<PartnerRequest> GetRequestsByGame(Game game) {
            return context.Requests.Where(g => g.SelectedGame == game)
                .Include(m => m.Requester)
                .ToList();
        }

        public void Update(PartnerRequest request) {
            context.Requests.Update(request);
            context.SaveChanges();
        }
    }
}
