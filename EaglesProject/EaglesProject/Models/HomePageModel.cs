using BL;
using Domains;
using Microsoft.AspNetCore.Authentication;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EaglesProject.Models
{
    public class HomePageModel
    {
        #region Declaration


        public IEnumerable<ApplicationUser> UserData { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserModel user { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }

        public string PersonalPhoto { get; set; }

        public ApplicationUser OneUser { get; set; }

       
        public IEnumerable<ApplicationUser> lstUsers { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }


        public IEnumerable<TbCustomer> lsCustomers { get; set; }


        #endregion

    }
}
