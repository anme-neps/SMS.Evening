using SMS.Evening.Core.IRepositories;
using SMS.Evening.Data.Helprs;
using SMS.Evening.Data.Models.DataModels;
using SMS.Evening.Data.Models.ViewModels;
using SMS.Evening.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Evening.Service.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepositories _studentRepo;
        public StudentService(IStudentRepositories studentRepo) 
        {
            _studentRepo = studentRepo;
        }
        public async Task<DataResult> CreateStudent(StudentViewModel studentParams)
        {
            Student student = new Student
            {
                FirstName = studentParams.FirstName,
                LastName = studentParams.LastName,
                Contact = studentParams.Contact,
                DateOfBirth = studentParams.DateOfBirth,
                Gender = studentParams.Gender,
                GradeLevel = studentParams.GradeLevel,
                CreatedBy  = "",
                CreationDate = DateTime.Now,
                LastModifiedBy = null,
                LastModifiedDate = null,
                IsDeleted = false
            };
            var response = await _studentRepo.CreateStudent(student);
            return response;
        }
    }
}
