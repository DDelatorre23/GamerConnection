using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TermProject296N.Models;
namespace TermProject296N.Repository
{
   public interface IPartnerRequest
    {
        IEnumerable<PartnerRequest> GetAllPartnerRequests();

        List<PartnerRequest> GetRequestsByGame(Game game);

        List<PartnerRequest> GetAllUnfilledRequests();

        List<PartnerRequest> GetAllFilledRequests();

        List<PartnerRequest> GetUnfilledNotCreatedByUser(string username);

        List<PartnerRequest> GetRequestByUser(string username);

        void Create(PartnerRequest request);

        void Update(PartnerRequest request);

        void Delete(PartnerRequest request);

    }
}
