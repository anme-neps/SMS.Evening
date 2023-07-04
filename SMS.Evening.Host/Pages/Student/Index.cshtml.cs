using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMS.Evening.Data.Models.ViewModels;
using SMS.Evening.Service.IServices;

namespace SMS.Evening.Host.Pages.Student
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public List<StudentViewModel> StudentsVM { get; set; }
        private readonly IStudentService _studentService;
        public IndexModel(IStudentService studentService)
        {
            _studentService = studentService;
        }
        public async Task<IActionResult> OnGet()
        {
            var result = await _studentService.GetAllStudent();
            if (result.IsSuccess)
            {
                StudentsVM = result.Data;
                return Page();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
