using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tahaluf.PlusExam.Core.Data;
using Tahaluf.PlusExam.Core.ServiceInterface;

namespace Tahaluf.PlusExam.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardController : ControllerBase
    {
        #region Fields
        private readonly ICreditCardService creditCardService;
        #endregion Fields

        #region Constructor
        public CreditCardController(ICreditCardService _creditCardService)
        {
            creditCardService = _creditCardService;
        }
        #endregion Constructor

        #region CRUD_Operation

        #region GetCreditCards
        [HttpGet]
        public List<CreditCard> GetCreditCards()
        {
            return creditCardService.GetCreditCards();
        }
        #endregion GetCreditCards

        #region CreateCreditCard
        [HttpPost]
        public bool CreateCreditCard(CreditCard creditCard)
        {
            return creditCardService.CreateCreditCard(creditCard);
        }
        #endregion CreateCreditCard

        #region UpdateCreditCard
        [HttpPut]
        public bool UpdateCreditCard(CreditCard creditCard)
        {
            return creditCardService.UpdateCreditCard(creditCard);
        }
        #endregion UpdateCreditCard

        #region DeleteCreditCard
        [HttpDelete]
        [Route("DeleteCreditCard/{id}")]
        public bool DeleteCreditCard(int id)
        {
            return creditCardService.DeleteCreditCard(id);
        }
        #endregion DeleteCreditCard

        #endregion CRUD_Operation
    }
}
