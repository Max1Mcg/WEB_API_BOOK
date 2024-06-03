using Microsoft.AspNetCore.Identity;
using WEB_API_BOOK.DbModels;
using WEB_API_BOOK.Models;

namespace WEB_API_BOOK.Services.Interfaces
{
    public interface IUserService
    {
        public Task<Microsoft.AspNetCore.Identity.SignInResult> Login(UserModel userModel);

        public Task Logout();

        public Task<IdentityResult> Register(UserModel userModel);

        public Task<IdentityResult> AddRole(string roleName);

        public Task<IdentityResult> AddRoleToUser(string userName, string roleName);
    }
}
