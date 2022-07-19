using Microsoft.AspNetCore.Mvc;
using OnionCRM.Application.Interfaces.IPhoneNumberServices;
using OnionCRM.Core.Domain;

namespace OnionCRM.WebAPI.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class PhoneNumbersController : ControllerBase
    {

        private readonly IPhoneNumberService _phoneNumberService;

        public PhoneNumbersController(IPhoneNumberService phoneNumberService)
        {
            _phoneNumberService = phoneNumberService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllNumbers(IPhoneNumberService _phoneNumberService)
        {
            var numbers = await _phoneNumberService.GetAllPhoneNumbers();
            return Ok(numbers);
        }

        [HttpPost]
        public async Task<IActionResult> AddPhoneNumber(PhoneNumber phoneNumber)
        {
            await _phoneNumberService.AddPhoneNumber(phoneNumber);
            return Ok(phoneNumber);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPhoneNumberById(int id)
        {
            return Ok(await _phoneNumberService.GetPhoneNumberById(id));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePhoneNumber(PhoneNumber phoneNumber)
        {
            
            return Ok(await _phoneNumberService.UpdatePhoneNumber(phoneNumber));

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhoneNumber(int id)
        {
            await _phoneNumberService.DeletePhoneNumber(id);
            return Ok();
        }

    }

}



