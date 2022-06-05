
--   Correct Answer PACKAGE BODY

CREATE OR REPLACE PACKAGE BODY CorrectAnswerPackage AS

    -- Correct Answer CRUD Operations
    PROCEDURE CorrectAnswerCRUD(
        func IN VARCHAR DEFAULT NULL,
        CANSWERID CORRECTANSWER.ID%TYPE DEFAULT NULL,
        QOID CORRECTANSWER.QUESTIONOPTIONID%TYPE DEFAULT NULL)
    AS
        C_ALL SYS_REFCURSOR;
    BEGIN
        If func = 'CREATE' THEN
            INSERT INTO CORRECTANSWER (QUESTIONOPTIONID)
            VALUES (QOID);
        
            COMMIT; 
        
        ELSIF func = 'UPDATE' THEN
            UPDATE CORRECTANSWER SET
            QUESTIONOPTIONID  = QOID
            WHERE ID  = CANSWERID;
    
            COMMIT;
            
        ELSIF func = 'DELETE' THEN
            DELETE FROM CORRECTANSWER 
            WHERE ID = CANSWERID;
        
            COMMIT;
        
        ELSE 
            OPEN C_ALL FOR
            SELECT * 
            FROM CORRECTANSWER;
        
            DBMS_SQL.RETURN_RESULT(C_ALL);
        END IF;        
    END  CorrectAnswerCRUD;       

END CorrectAnswerPackage;
