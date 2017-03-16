using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TermProject296N.Models;
namespace TermProject296N.Repository
{
    interface IPartnerRequest
    {
        IEnumerable<PartnerRequest> GetAllPartnerRequests();

        List<PartnerRequest> GetRequestsByGame(Game game);

        List<PartnerRequest> GetAllUnfilledRequests();

        List<PartnerRequest> GetAllFilledRequests();

        PartnerRequest GetRequestByUserID(int userID);

        void Create(PartnerRequest request);

        void Update(PartnerRequest request);

        void Delete(PartnerRequest request);

    }
}
