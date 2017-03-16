using System.ComponentModel.DataAnnotations;

namespace TermProject296N.Models.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
