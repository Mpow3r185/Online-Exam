create or replace PACKAGE CreditCardPackage AS

-- CRUD Procedure    
    PROCEDURE CreditCardCRUD(
        func IN VARCHAR DEFAULT NULL,
        card_id IN creditcard.id%type DEFAULT NULL,
        card_number IN Creditcard.cardnumber%type DEFAULT NULL,
        amount IN Creditcard.balance%type DEFAULT NULL,
        acc_id IN Creditcard.accountid%type DEFAULT NULL);


-- Update Balance Procedure
    PROCEDURE UpdateBalance(
        accid IN account.id%type,
        newBalance IN creditCard.balance%type);

END CreditCardPackage;
