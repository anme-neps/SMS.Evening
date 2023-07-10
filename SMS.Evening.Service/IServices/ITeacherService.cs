using SMS.Evening.Data.Helprs;
using SMS.Evening.Data.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Evening.Service.IServices
{
    public interface ITeacherService
    {
        Task<DataResult> CreateTeacher(TeacherViewModel teacherArgs);
        Task<DataResult> UpdateTeacher(TeacherViewModel teacherArgs);
        Task<DataResult> DeleteTeacher(int id);
        Task<DataResult<TeacherViewModel>> GetAllTeachers();
        Task<DataResult<TeacherViewModel>> GetTeacherById(int id);
    }
}
