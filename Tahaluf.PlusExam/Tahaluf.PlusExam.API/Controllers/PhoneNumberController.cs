using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tahaluf.PlusExam.Core.Data;
using Tahaluf.PlusExam.Core.ServiceInterface;

namespace Tahaluf.PlusExam.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneNumberController : ControllerBase
    {
        private readonly IPhoneNumberService _phoneNumberService;

        public PhoneNumberController(IPhoneNumberService phoneNumberService)
        {
            _phoneNumberService = phoneNumberService;
        }
        //Get All Phone Numbers
        [HttpGet]
        [ProducesResponseType(typeof(List<PhoneNumber>), StatusCodes.Status200OK)]
        public List<PhoneNumber> GetAll()
        {
            return _phoneNumberService.GetAll();
        }

        //Create
        [HttpPost]
        [ProducesResponseType(typeof(PhoneNumber), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool CreatePhoneNumber([FromBody] PhoneNumber phoneNumber)
        {
            return _phoneNumberService.CreatePhoneNumber(phoneNumber);
        }

        //Update
        [HttpPut]
        [ProducesResponseType(typeof(List<PhoneNumber>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool UpdatePhoneNumber([FromBody] PhoneNumber phoneNumber)
        {
            return _phoneNumberService.UpdatePhoneNumber(phoneNumber);
        }

        //Delete
        [HttpDelete]
        [Route("delete/{id}")]
        public bool DeletePhoneNumber(int id)
        {
            return _phoneNumberService.DeletePhoneNumber(id);
        }


    }
}
