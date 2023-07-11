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
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepositories _teacherRepo;
        public TeacherService(ITeacherRepositories teacherRepo) 
        {
            _teacherRepo = teacherRepo;
        }
        public async Task<DataResult> CreateTeacher(TeacherViewModel teacherArgs)
        {
            //DataResult result = new DataResult();
            Teacher teach = new Teacher
            {
                FirstName = teacherArgs.FirstName,
                LastName = teacherArgs.LastName,
                DateOfBirth = teacherArgs.DateOfBirth,
                Gender = teacherArgs.Gender,
                Phone = teacherArgs.Phone,
                Email = teacherArgs.Email,
                Subject = teacherArgs.Subject,
                CreationDate = DateTime.Now,
                CreatedBy = ""
            };
            var resp = await _teacherRepo.CreateTeacher(teach);
            //result.IsSuccess = resp.IsSuccess;
            //result.Message = resp.Message;
            return resp;
        }

        public async Task<DataResult> DeleteTeacher(int id)
        {
            var resp = await _teacherRepo.DeleteTeacher(id);
            return resp;
        }

        public async Task<DataResult<TeacherViewModel>> GetAllTeachers()
        {
            DataResult<TeacherViewModel> result = new DataResult<TeacherViewModel>();
            var resonse = await _teacherRepo.GetAllTeachers();
            result.IsSuccess = resonse.IsSuccess;
            result.Message = resonse.Message;
            // Transfer data from DataModel(Teacher) to ViewModal(TeacherViewModal)
            result.Data = resonse.Data.Select(s => new TeacherViewModel
                                        {
                                            Id = s.Id,
                                            FirstName = s.FirstName,
                                            LastName = s.LastName,
                                            DateOfBirth= s.DateOfBirth,
                                            Gender = s.Gender,
                                            Phone = s.Phone,
                                            Email = s.Email,
                                            Subject = s.Subject,
                                        }).ToList();
            return result;
        }

        public async Task<DataResult<TeacherViewModel>> GetTeacherById(int id)
        {
            DataResult<TeacherViewModel> result = new DataResult<TeacherViewModel>();
            var resonse = await _teacherRepo.GetTeacherById(id);
            result.IsSuccess = resonse.IsSuccess;
            result.Message = resonse.Message;
            // Transfer data from DataModel(Teacher) to ViewModal(TeacherViewModal)
            result.Data = resonse.Data.Select(s => new TeacherViewModel
                                        {
                                            Id = s.Id,
                                            FirstName = s.FirstName,
                                            LastName = s.LastName,
                                            DateOfBirth = s.DateOfBirth,
                                            Gender = s.Gender,
                                            Phone = s.Phone,
                                            Email = s.Email,
                                            Subject = s.Subject,
                                        }).ToList();
            return result;
        }

        public async Task<DataResult> UpdateTeacher(TeacherViewModel teacherArgs)
        {
            Teacher teach = new Teacher
            {
                Id = teacherArgs.Id,
                FirstName = teacherArgs.FirstName,
                LastName = teacherArgs.LastName,
                DateOfBirth = teacherArgs.DateOfBirth,
                Gender = teacherArgs.Gender,
                Phone = teacherArgs.Phone,
                Email = teacherArgs.Email,
                Subject = teacherArgs.Subject,
                LastModifiedDate = DateTime.Now,
                LastModifiedBy = ""
            };
            var resp = await _teacherRepo.UpdateTeacher(teach);
            return resp;
        }
    }
}
