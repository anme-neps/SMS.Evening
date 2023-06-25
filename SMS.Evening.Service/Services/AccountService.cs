using SMS.Evening.Core.IRepositories;
using SMS.Evening.Data.Helprs;
using SMS.Evening.Data.Models.ViewModels;
using SMS.Evening.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Evening.Service.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepositories _accountRepo;
        public AccountService(IAccountRepositories accountRepo) 
        {
            _accountRepo = accountRepo;
        }
        public async Task<DataResult> LoginAsync(LoginViewModel parms)
        {
            //DataResult result = new DataResult();
            DataResult result = await _accountRepo.LoginAsync(parms);
            return result;
        }

        public async Task<DataResult> LogoutAsync()
        {
            DataResult result = await _accountRepo.LogoutAsync();
            return result;
        }

        public async Task<DataResult> RegisterAsync(RegisterViewModel parms)
        {
            DataResult result = await _accountRepo.RegisterAsync(parms);
            return result;
        }
    }
}
