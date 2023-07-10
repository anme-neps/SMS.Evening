using SMS.Evening.Data.Helprs;
using SMS.Evening.Data.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Evening.Core.IRepositories
{
    public interface ITeacherRepositories
    {
        Task<DataResult> CreateTeacher(Teacher teacherArgs);
        Task<DataResult> UpdateTeacher(Teacher teacherArgs);
        Task<DataResult> DeleteTeacher(int Id);
        Task<DataResult<Teacher>> GetAllTeachers();
        Task<DataResult<Teacher>> GetTeacherById(int id);
    }
}
