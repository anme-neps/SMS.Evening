using SMS.Evening.Data.Helprs;
using SMS.Evening.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Evening.Data.Models.DataModels
{
    public class Student : BaseModel
    {
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public GenderType Gender { get; set; }
        public int GradeLevel { get; set; }
        public string Contact { get; set; }
        public string CreatedBy { get; set; }
    }
}
