using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EaglesProject.Models
{
    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "ErrorMessage =Please enter email address")]
        [EmailAddress]
        [Display(Name = "Registered email address")]
        public string Email { get; set; }

        public IFormFileCollection files;
        public bool emailSent { get; set; }
        public bool IsSuccess { get; set; }
    }
}
