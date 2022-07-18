using OnionCRM.Core.Domain;

namespace OnionCRM.Application.Interfaces.IAppUserServices;

public interface IAppUserService
{
    public Task<List<AppUser>> GetAllUsers();
    public Task<AppUser> GetUserById(string id);
    public Task<AppUser> AddUser(AppUser appUser);
    public Task<AppUser> UpdateUser(AppUser appUser);
    public Task<AppUser> DeleteUser(int id);

}