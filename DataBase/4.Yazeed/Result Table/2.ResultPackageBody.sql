/*
*
* * Result Package Body 
*
*/
CREATE OR REPLACE PACKAGE Body ResultPackage AS
     --Body for Result CRUD operation
    PROCEDURE ResultCRUD(
            func IN VARCHAR DEFAULT NULL,
            Rid Result.id%TYPE DEFAULT NULL, 
			RQuestionOptionId Result.questionoptionid%TYPE DEFAULT NULL, 
			RAccountId Result.accountid%TYPE DEFAULT NULL) AS R_all sys_refcursor;
    BEGIN
        -- Create
        IF func = 'CREATE' THEN
               INSERT INTO Result(Questionoptionid, Accountid)
               VALUES (RQuestionOptionId , RAccountId);
               COMMIT;
        
         -- Update    
        ELSIF func = 'UPDATE' THEN   
               UPDATE Result SET Questionoptionid=RQuestionOptionId, Accountid=RAccountId
               WHERE Id = Rid;
               COMMIT;
        
         --Delete    
        ELSIF func = 'DELETE' THEN  
               DELETE Result WHERE Id=Rid;
               COMMIT;
               
        -- Get All 
        ELSE 
            open R_all for
            select * from Result;
            DBMS_SQL.RETURN_RESULT(R_all);
                
       END IF;         
    END ResultCRUD;
    
END ResultPackage;
