namespace NETCore_MVC_Water_Company.Web.Helpers
{
    using Microsoft.AspNetCore.Identity;
    using NETCore_MVC_Water_Company.Web.Data.Entities;
    using System.Threading.Tasks;

    public interface IUserHelper
    {
        Task<User> GetUserByEmail(string email);

        Task<IdentityResult> AddUserAsync(User user, string password);
    }
}
