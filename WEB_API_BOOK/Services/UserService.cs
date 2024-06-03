using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WEB_API_BOOK.DbModels;
using WEB_API_BOOK.Models;
using WEB_API_BOOK.Services.Interfaces;

namespace WEB_API_BOOK.Services
{
    public class UserService: IUserService
    {
        SignInManager<UserDbModel> _signInManager;
        UserManager<UserDbModel> _userManager;
        RoleManager<IdentityRole> _roleManager;
        public UserService(SignInManager<UserDbModel> signInManager,
            UserManager<UserDbModel> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<Microsoft.AspNetCore.Identity.SignInResult> Login(UserModel userModel)
        {
            var result = await _signInManager.PasswordSignInAsync(userModel.UserName, userModel.Password, true, false);
            return result;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> Register(UserModel userModel)
        {
            //TODO check for description
            var user = new UserDbModel() { UserName = userModel.UserName };
            var result = await _userManager.CreateAsync(user, userModel.Password);
            return result;
        }

        public async Task<IdentityResult> AddRole(string roleName)
        {
            var role = new IdentityRole() { Name = roleName, NormalizedName = roleName };
            var result = await _roleManager.CreateAsync(role);
            return result;
        }

        public async Task<IdentityResult> AddRoleToUser(string userName, string roleName)
        {
            var targetUser = await _userManager.FindByNameAsync(userName);
            var result = await _userManager.AddToRoleAsync(targetUser, roleName);
            return result;
        }
    }
}
