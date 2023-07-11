using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMS.Evening.Data.Models.ViewModels;
using SMS.Evening.Service.IServices;

namespace SMS.Evening.Host.Pages.Teacher
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public List<TeacherViewModel> TeachersVM { get; set; }
        private readonly ITeacherService _service;
        public IndexModel(ITeacherService service)
        {
            _service = service;
        }
        public async Task OnGet()
        {
            var resp = await _service.GetAllTeachers();
            TeachersVM = resp.Data;
        }
    }
}
