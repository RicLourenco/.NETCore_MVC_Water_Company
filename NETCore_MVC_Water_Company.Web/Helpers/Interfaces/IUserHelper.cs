namespace NETCore_MVC_Water_Company.Web.Helpers.Interfaces
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using NETCore_MVC_Water_Company.Web.Data.Entities;
    using NETCore_MVC_Water_Company.Web.Models;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IUserHelper
    {
        /// <summary>
        /// Get user by e-mail
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<User> GetUserByEmailAsync(string email);

        /// <summary>
        /// Add user
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<IdentityResult> AddUserAsync(User user, string password);

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable> GetAllUsers();

        /// <summary>
        /// Delete user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<IdentityResult> RemoveUserAsync(User user, string userName);

        /// <summary>
        /// Login logic
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<SignInResult> LoginAsync(LoginViewModel model);

        /// <summary>
        /// Logout logic
        /// </summary>
        /// <returns></returns>
        Task LogoutAsync();

        /// <summary>
        /// Update user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<IdentityResult> UpdateUserAsync(User user);

        /// <summary>
        /// Change user password
        /// </summary>
        /// <param name="user"></param>
        /// <param name="currentPassword"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        Task<IdentityResult> ChangePasswordAsync(User user, string currentPassword, string newPassword);

        /// <summary>
        /// Validate password
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<SignInResult> ValidatePasswordAsync(User user, string password);

        /// <summary>
        /// Check if role exists
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns></returns>
        Task CheckRoleAsync(string roleName);

        /// <summary>
        /// Check if user is in role
        /// </summary>
        /// <param name="user"></param>
        /// <param name="roleName"></param>
        /// <returns></returns>
        Task<bool> IsUserInRoleAsync(User user, string roleName);

        /// <summary>
        /// Add user to role
        /// </summary>
        /// <param name="user"></param>
        /// <param name="roleName"></param>
        /// <returns></returns>
        Task AddUserToRoleAsync(User user, string roleName);

        /// <summary>
        /// Remove user from role
        /// </summary>
        /// <param name="user"></param>
        /// <param name="roleName"></param>
        /// <returns></returns>
        Task RemoveUserFromRoleAsync(User user, string roleName);

        /// <summary>
        /// Generate e-mail
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<string> GenerateEmailConfirmationTokenAsync(User user);

        /// <summary>
        /// Confirm e-mail
        /// </summary>
        /// <param name="user"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<IdentityResult> ConfirmEmailAsync(User user, string token);

        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<User> GetUserByIdAsync(string userId);

        /// <summary>
        /// Generate password token
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<string> GeneratePasswordResetTokenAsync(User user);

        /// <summary>
        /// Reset password
        /// </summary>
        /// <param name="user"></param>
        /// <param name="token"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<IdentityResult> ResetPasswordAsync(User user, string token, string password);

        /// <summary>
        /// Get roles combobox
        /// </summary>
        /// <returns></returns>
        IEnumerable<SelectListItem> GetComboRoles();

        /// <summary>
        /// Change user's role while deleting other roles he might be included in
        /// </summary>
        /// <param name="user"></param>
        /// <param name="roleName"></param>
        /// <returns></returns>
        Task ChangeUserRoleAsync(User user, string userName, string roleName);

        /// <summary>
        /// Check if user is in all roles
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<string> CheckUserRoleAsync(User user);

        /// <summary>
        /// get all users with roles associated
        /// </summary>
        /// <returns></returns>
        Task<List<User>> GetAllUsersWithRolesAsync();
    }
}
