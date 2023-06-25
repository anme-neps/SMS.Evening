using Microsoft.AspNetCore.Identity;
using SMS.Evening.Core.IRepositories;
using SMS.Evening.Data.Helprs;
using SMS.Evening.Data.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Evening.Core.Repositories
{
    public class AccountRepositories : IAccountRepositories
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public AccountRepositories(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager) 
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<DataResult> LoginAsync(LoginViewModel parms)
        {
            DataResult result = new DataResult();
            var user = await _userManager.FindByEmailAsync(parms.EmailAddress);
            var signInResult = await _signInManager.PasswordSignInAsync(user.UserName, parms.Password, false, false);
            if(signInResult.Succeeded)
            {
                result.IsSuccess = true;
                result.Message = "User login success";
            }
            else
            {
                result.IsSuccess = false;
                result.Message = "Login failed";
            }
            return result;
        }

        public async Task<DataResult> LogoutAsync()
        {
            DataResult result = new DataResult();
            await _signInManager.SignOutAsync();
            result.IsSuccess = true;
            result.Message = "Logut successful";
            return result;
        }

        public async Task<DataResult> RegisterAsync(RegisterViewModel parms)
        {
            DataResult result = new DataResult();
            IdentityUser user = new IdentityUser
            {
                UserName = parms.UserName,
                Email = parms.Email
            };
            var response = await _userManager.CreateAsync(user, parms.Password);
            if(response.Succeeded)
            {
                result.IsSuccess = true;
                result.Message = "User created successfully";
            }
            else
            {
                result.IsSuccess = false;
                result.Message = "Could not register user";
            }
            return result;
        }
    }
}
