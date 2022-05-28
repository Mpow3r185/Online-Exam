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
        private readonly ICreditCardService creditCardService;

        public CreditCardController(ICreditCardService _creditCardService)
        {
            creditCardService = _creditCardService;
        }
        [HttpGet]
        public List<CreditCard> GetCreditCards()
        {
            return creditCardService.GetCreditCards();
        }
        [HttpPost]
        public bool CreateCreditCard(CreditCard creditCard)
        {
            return creditCardService.CreateCreditCard(creditCard);
        }
        [HttpPut]
        public bool UpdateCreditCard(CreditCard creditCard)
        {
            return creditCardService.UpdateCreditCard(creditCard);
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public bool DeleteCreditCard(int id)
        {
            return creditCardService.DeleteCreditCard(id);
        }
    }
}
