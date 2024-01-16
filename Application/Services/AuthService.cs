using Domain.Entities;
using Domain.IServices;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public async Task<bool> IsEmailExist(string email)
        {
            var result = await _userManager.FindByEmailAsync(email);
            return (result != null);
        }

        public Task<bool> IsValidLogin(string username, string password)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsUserLogedIn(string userEmail)
        {
            //_userManager.
            throw new NotImplementedException();
        }
    }
}
