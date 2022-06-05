
--   Phone Number Package BODY

CREATE OR REPLACE PACKAGE BODY PhoneNumberPackage AS

    -- Phone Number CRUD Operations
    PROCEDURE PhoneNumberCRUD(
        func IN VARCHAR DEFAULT NULL,
        phNumId PhoneNumber.ID%TYPE DEFAULT NULL,
        PhNum PhoneNumber.PHONENUM%TYPE DEFAULT NULL,
        accId PHONENUMBER.ACCOUNTID%TYPE DEFAULT NULL )
    AS
        C_ALL SYS_REFCURSOR;
    BEGIN
        If func = 'CREATE' THEN
            INSERT INTO PhoneNumber(PHONENUM,ACCOUNTID)
            VALUES (PhNum,accId);
        
            COMMIT; 
        
        ELSIF func = 'UPDATE' THEN
            UPDATE PhoneNumber SET
            PHONENUM = PHNUM,
            ACCOUNTID   = ACCID
            WHERE ID    = PHNUMID;
    
            COMMIT;
            
        ELSIF func = 'DELETE' THEN
            DELETE FROM PHONENUMBER 
            WHERE ID = PHNUMID;
        
            COMMIT;
        
        ELSE 
            OPEN C_ALL FOR
            SELECT * 
            FROM PhoneNumber;
        
            DBMS_SQL.RETURN_RESULT(C_ALL);
        END IF;        
    END  PhoneNumberCRUD;       

END PhoneNumberPackage;
