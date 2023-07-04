using Microsoft.EntityFrameworkCore;
using SMS.Evening.Core.IRepositories;
using SMS.Evening.Data;
using SMS.Evening.Data.Helprs;
using SMS.Evening.Data.Models.DataModels;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Evening.Core.Repositories
{
    public class StudentRepositories : IStudentRepositories
    {
        private readonly SMSDbContext _context;
        public StudentRepositories(SMSDbContext context) 
        {
            _context = context;
        }
        public async Task<DataResult> CreateStudent(Student studentParams)
        {
            DataResult result = new DataResult();
            try
            {
                // prepare student table data
                await _context.Students.AddAsync(studentParams);
                // execute add method(command)
                await _context.SaveChangesAsync();
                result.IsSuccess = true;
                result.Message = "Create student successful";
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public async Task<DataResult> DeleteStudent(int id)
        {
            DataResult result = new DataResult();
            try
            {
                var std = await _context.Students.FindAsync(id);
                if(std == null)
                {
                    result.IsSuccess = false;
                    result.Message = "No student found";
                }
                std.IsDeleted = true;
                await _context.SaveChangesAsync();
                result.IsSuccess = true;
                result.Message = "Student deleted successfully";
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public async Task<DataResult<Student>> GetAllStudent()
        {
            DataResult<Student> result = new DataResult<Student>();
            try
            {
                result.Data = await _context.Students.Where(i => i.IsDeleted == false).ToListAsync();
                result.IsSuccess = true;
                result.Message = "Get all student success";
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public async Task<DataResult> UpdateStudent(Student studentParams)
        {
            DataResult result = new DataResult();
            try
            {
                var std = await _context.Students.FindAsync(studentParams.StudentID);
                if (std == null)
                {
                    result.IsSuccess = false;
                    result.Message = "No student found";
                }
                std.FirstName = studentParams.FirstName;
                std.LastName = studentParams.LastName;
                std.DateOfBirth = studentParams.DateOfBirth;
                std.Gender = studentParams.Gender;
                std.GradeLevel = studentParams.GradeLevel;
                std.Contact = studentParams.Contact;
                std.LastModifiedDate = studentParams.LastModifiedDate;
                std.LastModifiedBy = studentParams.LastModifiedBy;
                await _context.SaveChangesAsync();
                result.IsSuccess = true;
                result.Message = "Student updated successfully";
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
            }
            return result;
        }
    }
}
