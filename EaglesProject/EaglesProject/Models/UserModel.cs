using System.ComponentModel.DataAnnotations;

namespace EaglesProject.Models
{
    public class UserModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }



        public UserModel user { get; set; }



    }
}
