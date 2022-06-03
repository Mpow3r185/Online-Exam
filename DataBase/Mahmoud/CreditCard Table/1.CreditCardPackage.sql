CREATE OR REPLACE PACKAGE CreditCardPackage AS
    
    -- CRUD Procedures
    -- Get CreditCards Procedure
    PROCEDURE GetCreditCards;
    
    -- Create CreditCard Procedure
    PROCEDURE CreateCreditCard(
        card_number IN Creditcard.cardnumber%type,
        amount IN Creditcard.balance%type,
        acc_id IN Creditcard.accountid%type);
    
    -- Update CreditCard Procedure
    PROCEDURE UpdateCreditCard(
        card_id IN creditcard.id%type,
        card_number IN Creditcard.cardnumber%type,
        amount IN Creditcard.balance%type,
        acc_id IN Creditcard.accountid%type);
        
    -- Delete CreditCard Procedure
    PROCEDURE DeleteCreditCard(card_id IN CreditCard.id%type);
    -- CRUD Procedures
    
    -- Update Balance Procedure
    PROCEDURE UpdateBalance(
        accid IN account.id%type,
        newBalance IN creditCard.balance%type);

END CreditCardPackage;

