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

        public async Task<DataResult> DeleteStudent(int studentId)
        {
            var response = await _studentRepo.DeleteStudent(studentId);
            return response;
        }

        public async Task<DataResult<StudentViewModel>> GetAllStudent()
        {
            DataResult<StudentViewModel> studentViewModel = new DataResult<StudentViewModel>();
            DataResult<Student> studentDataModel = await _studentRepo.GetAllStudent();
            studentViewModel.Data = studentDataModel.Data.Select(x => new StudentViewModel
                                    { 
                                        StudentID  = x.StudentID,
                                        FirstName = x.FirstName,
                                        LastName = x.LastName,
                                        Contact = x.Contact,
                                        DateOfBirth= x.DateOfBirth,
                                        Gender= x.Gender,
                                        GradeLevel= x.GradeLevel
                                    }).ToList();
            studentViewModel.IsSuccess = studentDataModel.IsSuccess;
            studentViewModel.Message = studentDataModel.Message;
            return studentViewModel;
        }

        public async Task<DataResult> UpdateStudent(StudentViewModel studentParams)
        {
            Student student = new Student
            {
                FirstName = studentParams.FirstName,
                LastName = studentParams.LastName,
                Contact = studentParams.Contact,
                DateOfBirth = studentParams.DateOfBirth,
                Gender = studentParams.Gender,
                GradeLevel = studentParams.GradeLevel,
                LastModifiedBy = "",
                LastModifiedDate = DateTime.Now
            };
            var response = await _studentRepo.UpdateStudent(student);
            return response;
        }
    }
}
