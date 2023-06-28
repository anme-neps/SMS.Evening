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

        public Task<DataResult> DeleteStudent(int id)
        {
            throw new NotImplementedException();
        }

        public Task<DataResult<Student>> GetAllStudent()
        {
            throw new NotImplementedException();
        }

        public Task<DataResult> UpdateStudent(Student studentParams)
        {
            throw new NotImplementedException();
        }
    }
}
