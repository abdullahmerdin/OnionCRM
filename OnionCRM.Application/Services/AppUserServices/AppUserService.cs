using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnionCRM.Application.Interfaces.IAppUserServices;
using OnionCRM.Core.Domain;
using OnionCRM.Persistance.Context;

namespace OnionCRM.Application.Services.AppUserServices;

public class AppUserService : IAppUserService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IdentityDbContext _context;

    public AppUserService(UserManager<AppUser> userManager, IdentityDbContext context)
    {
        _userManager = userManager;
        _context = context;
    }


    public async Task<List<AppUser>> GetAllUsers()
    {
        return await _context.AppUsers.ToListAsync();
    }

    public async Task<AppUser> GetUserById(string id)
    {
        return await _userManager.FindByIdAsync(id);
    }

    public async Task<AppUser> AddUser(AppUser appUser)
    {
        var result = await _userManager.CreateAsync(appUser, appUser.PasswordHash);
        if (result.Succeeded)
        {
            return appUser;
        }
        else
        {
            return null;
        }
    }

    public async Task<AppUser> UpdateUser(AppUser appUser)
    {
        var result = await _userManager.UpdateAsync(appUser);
        if (result.Succeeded)
        {
            return appUser;
        }
        else
        {
            return null;
        }
    }

    public async Task<AppUser> DeleteUser(int id)
    {
        var appUser = await _userManager.FindByIdAsync(id.ToString());
        if (appUser != null)
        {
            var result = await _userManager.DeleteAsync(appUser);
            if (result.Succeeded)
            {
                return appUser;
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