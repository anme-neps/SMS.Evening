using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMS.Evening.Data.Models.ViewModels;
using SMS.Evening.Service.IServices;

namespace SMS.Evening.Host.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly IAccountService _accountService;
        [BindProperty]
        public LoginViewModel LoginParams { get; set; }
        public LoginModel(IAccountService accountService)
        {
            _accountService = accountService;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            var response = await _accountService.LoginAsync(LoginParams);
            if(response.IsSuccess)
               return RedirectToPage("/Index");
            
            return Page();
        }
    }
}
