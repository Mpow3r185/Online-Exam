﻿using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.PlusExam.Core.Data;

namespace Tahaluf.PlusExam.Core.RepositoryInterface
{
    public interface ICreditCardRepository
    {
        // Get Credit Cards
        List<CreditCard> GetCreditCards();

        // Create Credit Card
        bool CreateCreditCard(CreditCard creditCard);

        // Update Credit Card
        bool UpdateCreditCard(CreditCard creditCard);

        // Delete Credit Card
        bool DeleteCreditCard(int id);
    }
}
