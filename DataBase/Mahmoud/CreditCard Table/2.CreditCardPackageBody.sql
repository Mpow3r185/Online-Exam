CREATE OR REPLACE PACKAGE BODY CreditCardPackage AS
    
    -- CRUD Procedures
    -- Get CreditCards Procedure
    PROCEDURE GetCreditCards AS
        ref_cursor SYS_REFCURSOR;
    BEGIN
        OPEN ref_cursor FOR
        SELECT *
        FROM CreditCard;
        
        DBMS_SQL.RETURN_RESULT(ref_cursor);
    END GetCreditCards;
    
    -- Create CreditCard Procedure
    PROCEDURE CreateCreditCard(
        card_number IN Creditcard.cardnumber%type,
        amount IN Creditcard.balance%type,
        acc_id IN Creditcard.accountid%type) AS
        BEGIN
            INSERT INTO CreditCard
            (cardnumber, balance, accountid)
            VALUES(card_number, amount, acc_id);
        commit;
        END CreateCreditCard;
    
    -- Update CreditCard Procedure
    PROCEDURE UpdateCreditCard(
        card_id IN creditcard.id%type,
        card_number IN Creditcard.cardnumber%type,
        amount IN Creditcard.balance%type,
        acc_id IN Creditcard.accountid%type) AS
        BEGIN
            UPDATE Creditcard SET 
                cardnumber = card_number,
                balance = amount,
                accountid = acc_id
               
            WHERE id = card_id;
            commit;
        END UpdateCreditCard;
        
    -- Delete CreditCard Procedure
    PROCEDURE DeleteCreditCard(card_id IN CreditCard.id%type) AS
    BEGIN
        DELETE from CreditCard WHERE id = card_id;
        commit;
END DeleteCreditCard;
END CreditCardPackage;