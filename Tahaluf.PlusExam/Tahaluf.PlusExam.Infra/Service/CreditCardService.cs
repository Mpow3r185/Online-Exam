using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.PlusExam.Core.Data;
using Tahaluf.PlusExam.Core.RepositoryInterface;
using Tahaluf.PlusExam.Core.ServiceInterface;

namespace Tahaluf.PlusExam.Infra.Service
{
    public class CreditCardService : ICreditCardService
    {
        #region Fields
        private readonly ICreditCardRepository creditCardRepository;
        #endregion Fields

        #region Constructor
        public CreditCardService(ICreditCardRepository _creditCardRepository)
        {
            creditCardRepository = _creditCardRepository;
        }
        #endregion Constructor

        #region CRUD_Operation

        #region GetCreditCards
        public List<CreditCard> GetCreditCards()
        {
            return creditCardRepository.GetCreditCards();
        }
        #endregion GetCreditCards

        #region CreateCreditCard
        public bool CreateCreditCard(CreditCard creditCard)
        {
            return creditCardRepository.CreateCreditCard(creditCard);
        }
        #endregion CreateCreditCard

        #region UpdateCreditCard
        public bool UpdateCreditCard(CreditCard creditCard)
        {
            return creditCardRepository.UpdateCreditCard(creditCard);
        }
        #endregion UpdateCreditCard

        #region DeleteCreditCard
        public bool DeleteCreditCard(int id)
        {
            return creditCardRepository.DeleteCreditCard(id);
        }
        #endregion DeleteCreditCard

        #endregion CRUD_Operation
    }
}
