using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMS.Evening.Data.Models.Enums;
using SMS.Evening.Data.Models.ViewModels;
using SMS.Evening.Service.IServices;

namespace SMS.Evening.Host.Pages.Student
{
    public class CreateStudentModel : PageModel
    {
        [BindProperty]
        public StudentViewModel StudentVM { get; set; }
        [BindProperty]
        public List<GenderType> GenderList { get; set; }
        private readonly IStudentService _studentService;
        public CreateStudentModel(IStudentService studentService)
        {
            _studentService = studentService;
        }
        public void OnGet()
        {
            GenderList = Enum.GetValues<GenderType>().ToList();
        }
    }
}
