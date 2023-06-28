using SMS.Evening.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Evening.Data.Models.ViewModels
{
    public class StudentViewModel
    {
        public int StudentID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        public GenderType Gender { get; set; }
        public int GradeLevel { get; set; }
        [Required]
        [Phone]
        public string Contact { get; set; }
    }
}
