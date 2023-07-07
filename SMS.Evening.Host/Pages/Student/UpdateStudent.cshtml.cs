using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMS.Evening.Data.Models.Enums;
using SMS.Evening.Data.Models.ViewModels;
using SMS.Evening.Service.IServices;

namespace SMS.Evening.Host.Pages.Student
{
    public class UpdateStudentModel : PageModel
    {
        private readonly IStudentService _studentService;
        [BindProperty]
        public StudentViewModel StudentVM { get; set; }
        [BindProperty]
        public List<GenderType> GenderList { get; set; }
        public UpdateStudentModel(IStudentService studentService)
        {
            _studentService = studentService;
        }
        public async void OnGet(int id)
        {
            var response = await _studentService.GetAllStudent();
            if (response.Data != null) 
            {
                StudentVM = response.Data.Where(w => w.StudentID == id).First();
            }
            GenderList = Enum.GetValues<GenderType>().ToList();
        }

        public async Task<IActionResult> OnPost()
        {
            var response = await _studentService.UpdateStudent(StudentVM);
            if (response.IsSuccess)
                return RedirectToPage("/Student/Index");
            return Page();
        }
    }
}
