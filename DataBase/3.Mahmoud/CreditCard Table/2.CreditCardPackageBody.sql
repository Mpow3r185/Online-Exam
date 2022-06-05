create or replace PACKAGE BODY CreditCardPackage AS
    
    -- CRUD Procedures    
    PROCEDURE CreditCardCRUD(
        func IN VARCHAR DEFAULT NULL,
        card_id IN creditcard.id%type DEFAULT NULL,
        card_number IN Creditcard.cardnumber%type DEFAULT NULL,
        amount IN Creditcard.balance%type DEFAULT NULL,
        acc_id IN Creditcard.accountid%type DEFAULT NULL) AS
        
        ref_cursor SYS_REFCURSOR;
    BEGIN
    -- Create 
        IF func = 'CREATE' THEN
            INSERT INTO CreditCard
            (cardnumber, balance, accountid)
            VALUES(card_number, amount, acc_id);

        COMMIT;
    -- Update 
    ELSIF func = 'UPDATE' THEN
            UPDATE Creditcard SET 
                cardnumber = card_number,
                balance = amount,
                accountid = acc_id

            WHERE id = card_id;

            COMMIT;


    -- Delete 
    ELSIF func = 'DELETE' THEN
        DELETE from CreditCard WHERE id = card_id;

        COMMIT;
    ELSE
    -- Get
        OPEN ref_cursor FOR
        SELECT *
        FROM CreditCard;

        DBMS_SQL.RETURN_RESULT(ref_cursor);
    END IF;
END CreditCardCRUD;


-- Update Balance Procedure
    PROCEDURE UpdateBalance(
        accid IN account.id%type,
        newBalance IN creditCard.balance%type) AS
    BEGIN
        UPDATE creditCard SET 
        balance = newBalance
        WHERE accountId = accid;

        COMMIT;
    END UpdateBalance;

END CreditCardPackage;
