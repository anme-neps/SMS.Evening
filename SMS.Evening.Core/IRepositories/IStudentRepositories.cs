using SMS.Evening.Data.Helprs;
using SMS.Evening.Data.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Evening.Core.IRepositories
{
    public interface IStudentRepositories
    {
        Task<DataResult<Student>> GetAllStudent();
        Task<DataResult> CreateStudent(Student studentParams);
        Task<DataResult> UpdateStudent(Student studentParams);
        Task<DataResult> DeleteStudent(int id);
    }
}
