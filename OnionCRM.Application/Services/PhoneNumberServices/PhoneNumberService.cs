using Microsoft.EntityFrameworkCore;
using OnionCRM.Application.Interfaces.IPhoneNumberServices;
using OnionCRM.Core.Domain;
using OnionCRM.Persistance.Context;

namespace OnionCRM.Application.Services.PhoneNumberServices;

public class PhoneNumberService : IPhoneNumberService
{

    private readonly OnionProjectContext _context;
    public PhoneNumberService(OnionProjectContext context)
    {
        _context = context;
    }


    public async Task<List<PhoneNumber>> GetAllPhoneNumbers()
    {
        return await _context.PhoneNumbers.ToListAsync();

    }

    
    async Task<PhoneNumber> IPhoneNumberService.GetPhoneNumberById(int id)
    {
        return await _context.PhoneNumbers.FindAsync(id);

    }

    async Task<PhoneNumber> IPhoneNumberService.AddPhoneNumber(PhoneNumber phoneNumber)
    {
        if (phoneNumber == null)
        {
            throw new ArgumentNullException(nameof(phoneNumber));
        }

        await _context.PhoneNumbers.AddAsync(phoneNumber);
        await _context.SaveChangesAsync();
        return phoneNumber;
    }

    public async Task<PhoneNumber> UpdatePhoneNumber(PhoneNumber phoneNumber)
    {
        var dbNumber = await _context.PhoneNumbers.FindAsync(phoneNumber.Id);
        if (dbNumber == null)
        {
            throw new ArgumentNullException(nameof(phoneNumber));
        }
        dbNumber.Number = phoneNumber.Number;
        dbNumber.UserName = phoneNumber.UserName;

        await _context.SaveChangesAsync();
        return phoneNumber;
    }
    
    async Task<PhoneNumber> IPhoneNumberService.DeletePhoneNumber(int id)
    {
        _context.PhoneNumbers.Remove(await _context.PhoneNumbers.FindAsync(id));
        await _context.SaveChangesAsync();
        return null;
    }
    
}