using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TermProject296N.Models
{
    public class PartnerRequest
    {
        public int PartnerRequestID { get; set; }

        public User Requester { get; set; }

        public DateTime RequestDate { get; set; }

        public DateTime? RequestCompleted { get; set; }

        public User MatchedPartner { get; set; }

        public Game SelectedGame { get; set; }

        public bool HasBeenMatched { get; set; } = false;

    }
}

