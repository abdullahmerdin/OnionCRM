using OnionCRM.Core.Domain;

namespace OnionCRM.Application.Interfaces.IRoleServices;

public interface IRoleService
{
    public Task<List<Role>> GetAllRoles();
    public Task<Role> GetRoleById(string id);
    public Task<Role> AddRole(Role role);
    public Task<Role> UpdateRole(Role role);
    public Task<Role> DeleteRole(int id);

}