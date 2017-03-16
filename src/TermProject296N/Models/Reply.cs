using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TermProject296N.Models
{
    public class Reply
    {
        public int ReplyID { get; set; }

        public string ReplyBody { get; set; }

        public User ReplyCreator { get; set; }

        public DateTime DateReplied { get; set; }

        public int ReplyRating { get; set; }

    }
}
