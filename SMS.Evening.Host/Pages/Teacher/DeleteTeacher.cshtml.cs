using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMS.Evening.Data.Models.Enums;
using SMS.Evening.Data.Models.ViewModels;
using SMS.Evening.Service.IServices;

namespace SMS.Evening.Host.Pages.Teacher
{
    public class DeleteTeacherModel : PageModel
    {
        [BindProperty]
        public TeacherViewModel TeacherVM { get; set; }
        private readonly ITeacherService _service;
        public DeleteTeacherModel(ITeacherService service)
        {
            _service = service;
        }
        public async Task OnGet(int id)
        {
            var response = await _service.GetTeacherById(id);
            TeacherVM = response.Data.First();
        }

        public async Task<IActionResult> OnPost()
        {
            var response = await _service.DeleteTeacher(TeacherVM.Id);
            if (response.IsSuccess)
            {
                return RedirectToPage("/Teacher/Index");
            }
            return Page();
        }
    }
}
