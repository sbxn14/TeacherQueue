using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeacherQueue.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [DisplayName("First and Middle Names")]
        public string FirstMidName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        [DisplayName("Emailaddress")]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [DisplayName("Confirm Password")]
        [Compare("Password")]
        public string ConfirmationPassword { get; set; }
    }
}
