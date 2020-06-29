namespace NETCore_MVC_Water_Company.Web.Helpers
{
    using Microsoft.AspNetCore.Identity;
    using NETCore_MVC_Water_Company.Web.Data.Entities;
    using System.Threading.Tasks;

    public class UserHelper : IUserHelper
    {
        readonly UserManager<User> _userManager;

        public UserHelper(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> AddUserAsync(User user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }
    }
}
