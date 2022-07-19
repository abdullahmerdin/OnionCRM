using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnionCRM.Application.Interfaces.IRoleServices;
using OnionCRM.Core.Domain;
using OnionCRM.Persistance.Context;

namespace OnionCRM.Application.Services.RoleServices;

public class RoleService : IRoleService
{
    private readonly RoleManager<Role> _roleManager;
    private readonly IdentityDbContext _context;

    public RoleService(RoleManager<Role> roleManager, IdentityDbContext context)
    {
        _roleManager = roleManager;
        _context = context;
    }


    public async Task<List<Role>> GetAllRoles()
    {
        return await _context.Roles.ToListAsync();
    }

    public async Task<Role> GetRoleById(string id)
    {
        return await _context.Roles.FindAsync(id);
    }

    public async Task<Role> AddRole(Role role)
    {
        var result = await _roleManager.CreateAsync(role);
        if (result.Succeeded)
        {
            return role;
        }
        else
        {
            return null;
        }
    }

    public async Task<Role> UpdateRole(Role role)
    {
        var result = await _roleManager.UpdateAsync(role);
        if (result.Succeeded)
        {
            return role;
        }
        else
        {
            return null;
        }
    }

    public async Task<Role> DeleteRole(int id)
    {
        var role = await _context.Roles.FindAsync(id);
        if (role != null)
        {
            var result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                return role;
            }
            else
            {
                return null;
            }
        }
        else
        {
            return null;
        }
    }
}