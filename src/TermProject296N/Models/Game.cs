using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TermProject296N.Models {
    public class Game {
        public int GameID { get; set; }

        public string Title { get; set; }

        public string Platform { get; set; }

        public string Description { get; set; }

        //TODO: determine whether this should be a list<user> object and add users as they set it to a favorite.
        public int TotalUsers { get; set; }

    }
}