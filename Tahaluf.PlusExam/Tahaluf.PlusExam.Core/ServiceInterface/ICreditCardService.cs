using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.PlusExam.Core.Data;

namespace Tahaluf.PlusExam.Core.ServiceInterface
{
    public interface ICreditCardService
    {
        List<CreditCard> GetCreditCards();
        bool CreateCreditCard(CreditCard creditCard);
        bool UpdateCreditCard(CreditCard creditCard);
        bool DeleteCreditCard(int id);
    }
}
