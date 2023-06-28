using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMS.Evening.Service.IServices;

namespace SMS.Evening.Host.Pages.Account
{
    public class LogoutModel : PageModel
    {
        private readonly IAccountService _accountService;
        public LogoutModel(IAccountService accountService)
        {
            _accountService = accountService;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(string returnUrl = null) 
        {
            if(returnUrl != null)
            {
                var result = await _accountService.LogoutAsync();
                return RedirectToPage(returnUrl);
            }
            else
            {
                return RedirectToPage("/Account/Login");
            }
        }
    }
}
