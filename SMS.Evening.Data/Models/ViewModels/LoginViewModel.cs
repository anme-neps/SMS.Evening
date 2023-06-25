using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Evening.Data.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Required]
        [StringLength(100, ErrorMessage ="The {0} must be at least {2} and at max {1} characters long.", MinimumLength =6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
