using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IServices
{
    public interface IAuthService
    {
        public Task<bool> IsEmailExist(string email);

        public Task<bool> IsValidLogin(string username, string password);
    }
}
