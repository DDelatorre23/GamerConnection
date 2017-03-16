using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TermProject296N.Models
{
    public class Post
    {
        public int PostID { get; set; }

        public string Title { get; set; }

        public string PostBody { get; set; }

        public User PostCreator { get; set; }

        public DateTime DatePosted { get; set; }

        public int PostRating { get; set; }

        List<Reply> replies = new List<Reply>();
        public List<Reply> Replies { get { return replies; } }


    }
}
