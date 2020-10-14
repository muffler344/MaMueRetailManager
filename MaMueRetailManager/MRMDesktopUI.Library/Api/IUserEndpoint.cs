using MRMDesktopUI.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MRMDesktopUI.Library.Api
{
    public interface IUserEndpoint
    {
        Task AddUserToRole(string userId, string roleName);
        Task<List<UserModel>> GetAll();
        Task<Dictionary<string, string>> GetAllRoles();
        Task RemoveUserToRole(string userId, string roleName);
    }
}