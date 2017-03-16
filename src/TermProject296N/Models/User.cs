using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace TermProject296N.Models
{
    public class User : IdentityUser
    {
        public int UserID { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public List<Game> FavoriteGames { get; set; }

        public string Xbox_Gamertag { get; set; }

        public string PSN_UserName { get; set; }

        [StringLength(12, MinimumLength =12, ErrorMessage = "Friend code must be 12 character long")]
        public string Nintendo_FriendCode { get; set; }

        
    }
}

