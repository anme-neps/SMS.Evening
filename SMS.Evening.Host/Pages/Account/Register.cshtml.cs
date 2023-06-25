using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMS.Evening.Data.Models.ViewModels;
using SMS.Evening.Service.IServices;
using System.Security.Policy;

namespace SMS.Evening.Host.Pages.Account
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public RegisterViewModel RegisterParams { get; set; }
        private readonly IAccountService _accountService;
        public RegisterModel(IAccountService accountService)
        {
            _accountService = accountService;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var result = await _accountService.RegisterAsync(RegisterParams);
                if(result.IsSuccess)
                {
                    return RedirectToPage("/Account/Login");
                }
                else
                    return Page();
            }
            return Page();
        }
    }
}
