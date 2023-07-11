using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMS.Evening.Data.Models.Enums;
using SMS.Evening.Data.Models.ViewModels;
using SMS.Evening.Service.IServices;

namespace SMS.Evening.Host.Pages.Teacher
{
    public class CreateTeacherModel : PageModel
    {
        [BindProperty]
        public TeacherViewModel TeacherVM { get; set; }
        [BindProperty]
        public List<GenderType> GenderList { get; set; }
        private readonly ITeacherService _service;
        public CreateTeacherModel(ITeacherService service)
        {
            _service = service;
        }
        public async Task OnGet()
        {
            GenderList = Enum.GetValues<GenderType>().ToList();
        }

        public async Task<IActionResult> OnPost()
        {
            var response = await _service.CreateTeacher(TeacherVM);
            if (response.IsSuccess) 
            {
                return RedirectToPage("/Teacher/Index");
            }
            return Page();
        }
    }
}
