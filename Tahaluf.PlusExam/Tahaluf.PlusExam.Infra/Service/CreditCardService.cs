using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.PlusExam.Core.Data;
using Tahaluf.PlusExam.Core.RepositoryInterface;
using Tahaluf.PlusExam.Core.ServiceInterface;

namespace Tahaluf.PlusExam.Infra.Service
{
    class CreditCardService : ICreditCardService
    {
        private readonly ICreditCardRepository creditCardRepository;
        public CreditCardService(ICreditCardRepository _creditCardRepository)
        {
            creditCardRepository = _creditCardRepository;
        }
        public List<CreditCard> GetCreditCards()
        {
            return creditCardRepository.GetCreditCards();
        }
        public bool CreateCreditCard(CreditCard creditCard)
        {
            return creditCardRepository.CreateCreditCard(creditCard);
        }
        public bool UpdateCreditCard(CreditCard creditCard)
        {
            return creditCardRepository.UpdateCreditCard(creditCard);
        }

        public bool DeleteCreditCard(int id)
        {
            return creditCardRepository.DeleteCreditCard(id);
        }

        

        
    }
}
