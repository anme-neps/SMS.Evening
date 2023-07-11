using Microsoft.EntityFrameworkCore;
using SMS.Evening.Core.IRepositories;
using SMS.Evening.Data;
using SMS.Evening.Data.Helprs;
using SMS.Evening.Data.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Evening.Core.Repositories
{
    public class TeacherRepositories : ITeacherRepositories
    {
        private readonly SMSDbContext _context;
        public TeacherRepositories(SMSDbContext context) 
        {
            _context = context;
        }
        public async Task<DataResult> CreateTeacher(Teacher teacherArgs)
        {
            DataResult result = new DataResult();
            try
            {
                await _context.Teachers.AddAsync(teacherArgs);
                await _context.SaveChangesAsync();
                result.IsSuccess = true;
                result.Message = "create teacher successful";
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public async Task<DataResult> DeleteTeacher(int id)
        {
            DataResult result = new DataResult();
            try
            {
                var teach = await _context.Teachers.FindAsync(id);
                if (teach == null)
                {
                    result.IsSuccess = false;
                    result.Message = "No data found";
                }
                teach.IsDeleted = true;
                await _context.SaveChangesAsync();
                result.IsSuccess = true;
                result.Message = "Delete use successful";
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public async Task<DataResult<Teacher>> GetAllTeachers()
        {
            DataResult<Teacher> result = new DataResult<Teacher>();
            try
            {
                result.Data = await _context.Teachers.Where(w => w.IsDeleted == false).ToListAsync();
                result.IsSuccess = true;
                result.Message = "Get all teacher success";
            }
            catch(Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public async Task<DataResult<Teacher>> GetTeacherById(int id)
        {
            DataResult<Teacher> result = new DataResult<Teacher>();
            try
            {
                result.Data = await _context.Teachers.Where(w => w.IsDeleted == false && w.Id == id).ToListAsync();
                result.IsSuccess = true;
                result.Message = "Get all teacher success";
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public async Task<DataResult> UpdateTeacher(Teacher teacherArgs)
        {
            DataResult result = new DataResult();
            try
            {
                //get existing data row
                var teach = await _context.Teachers.FindAsync(teacherArgs.Id);
                if(teach != null) 
                { 
                    // Override value form teacherArgs to teach
                    teach.FirstName = teacherArgs.FirstName;
                    teach.LastName = teacherArgs.LastName;
                    teach.DateOfBirth = teacherArgs.DateOfBirth;
                    teach.Email = teacherArgs.Email;
                    teach.Gender = teacherArgs.Gender;
                    teach.Phone = teacherArgs.Phone;
                    teach.Subject = teacherArgs.Subject;
                    teach.LastModifiedBy = teacherArgs.LastModifiedBy;
                    teach.LastModifiedDate = teacherArgs.LastModifiedDate;
                    
                    //Execute to db to update value
                    await _context.SaveChangesAsync();
                    result.IsSuccess = true;
                    result.Message = "Update teacher success";
                }
                else 
                { 
                    result.IsSuccess = false;
                    result.Message = "No data found";
                }
            }
            catch(Exception ex )
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
            }
            return result;
        }
    }
}
