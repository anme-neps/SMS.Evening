using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMS.Evening.Data.Models.Enums;
using SMS.Evening.Data.Models.ViewModels;
using SMS.Evening.Service.IServices;

namespace SMS.Evening.Host.Pages.Teacher
{
    public class UpdateTeacherModel : PageModel
    {
        [BindProperty]
        public TeacherViewModel TeacherVM { get; set; }
        [BindProperty]
        public List<GenderType> GenderList { get; set; }
        private readonly ITeacherService _service;
        public UpdateTeacherModel(ITeacherService service)
        {
            _service = service;
        }
        public async Task OnGet(int id)
        {
            var response = await _service.GetTeacherById(id);
            TeacherVM = response.Data.First();
            GenderList = Enum.GetValues<GenderType>().ToList();
        }

        public async Task<IActionResult> OnPost()
        {
            var response = await _service.UpdateTeacher(TeacherVM);
            if (response.IsSuccess)
            {
                return RedirectToPage("/Teacher/Index");
            }
            return Page();
        }
    }
}
