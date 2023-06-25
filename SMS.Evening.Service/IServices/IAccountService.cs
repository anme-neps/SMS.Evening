using SMS.Evening.Data.Helprs;
using SMS.Evening.Data.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Evening.Service.IServices
{
    public interface IAccountService
    {
        Task<DataResult> LoginAsync(LoginViewModel parms);
        Task<DataResult> LogoutAsync();
        Task<DataResult> RegisterAsync(RegisterViewModel parms);
    }
}
