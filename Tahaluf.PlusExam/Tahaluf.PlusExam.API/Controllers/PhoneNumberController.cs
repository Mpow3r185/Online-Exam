using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tahaluf.PlusExam.Core.Data;
using Tahaluf.PlusExam.Core.ServiceInterface;

namespace Tahaluf.PlusExam.API.Controllers
{
    [Route("[api/controller]")]
    [ApiController]
    public class PhoneNumberController : ControllerBase
    {
        #region Fields
        private readonly IPhoneNumberService _phoneNumberService;
        #endregion Fields

        #region Constructor
        public PhoneNumberController(IPhoneNumberService phoneNumberService)
        {
            _phoneNumberService = phoneNumberService;
        }
        #endregion Constructor

        #region CRUD_Operation

        #region GetPhoneNumbers
        // Get All Phone Numbers
        [HttpGet]
        [ProducesResponseType(typeof(List<PhoneNumber>), StatusCodes.Status200OK)]
        public List<PhoneNumber> GetPhoneNumbers()
        {
            return _phoneNumberService.GetPhoneNumbers();
        }
        #endregion GetPhoneNumbers

        #region CreatePhoneNumber
        // Create Phone Number
        [HttpPost]
        [ProducesResponseType(typeof(PhoneNumber), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool CreatePhoneNumber([FromBody] PhoneNumber phoneNumber)
        {
            return _phoneNumberService.CreatePhoneNumber(phoneNumber);
        }
        #endregion CreatePhoneNumber

        #region UpdatePhoneNumber
        // Update Phone Number
        [HttpPut]
        [ProducesResponseType(typeof(List<PhoneNumber>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool UpdatePhoneNumber([FromBody] PhoneNumber phoneNumber)
        {
            return _phoneNumberService.UpdatePhoneNumber(phoneNumber);
        }
        #endregion UpdatePhoneNumber

        #region DeletePhoneNumber
        // Delete Phone Number
        [HttpDelete]
        [Route("deletePhoneNumber/{id}")]
        public bool DeletePhoneNumber(int id)
        {
            return _phoneNumberService.DeletePhoneNumber(id);
        }
        #endregion DeletePhoneNumber

        #endregion CRUD_Operation
    }
}
