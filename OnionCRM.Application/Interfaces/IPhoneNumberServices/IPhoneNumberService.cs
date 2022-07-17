using OnionCRM.Core.Domain;

namespace OnionCRM.Application.Interfaces.IPhoneNumberServices;

public interface IPhoneNumberService
{
    public Task<List<PhoneNumber>> GetAllPhoneNumbers();
    public Task<PhoneNumber> GetPhoneNumberById(int id);
    public Task<PhoneNumber> AddPhoneNumber(PhoneNumber phoneNumber);
    public Task<PhoneNumber> UpdatePhoneNumber(PhoneNumber phoneNumber);
    public Task<PhoneNumber> DeletePhoneNumber (int id);
  

}