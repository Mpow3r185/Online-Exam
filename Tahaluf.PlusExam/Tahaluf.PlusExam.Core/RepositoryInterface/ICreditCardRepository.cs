using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.PlusExam.Core.Data;

namespace Tahaluf.PlusExam.Core.RepositoryInterface
{
    public interface ICreditCardRepository
    {
        List<CreditCard> GetCreditCards();
        bool CreateCreditCard(CreditCard creditCard);
        bool UpdateCreditCard(CreditCard creditCard);
        bool DeleteCreditCard(int id);
    }
}
