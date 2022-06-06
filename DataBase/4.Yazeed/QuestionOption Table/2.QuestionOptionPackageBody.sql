/* 
*
* * QuestionOption Package Body
*
*/
CREATE OR REPLACE PACKAGE Body QuestionOptionPackage AS
    --Body For CRUD QuestionOption
    PROCEDURE QuestionOptionCRUD(
            func IN VARCHAR DEFAULT NULL,
            Oid Questionoption.id%TYPE DEFAULT NULL, 
			OContent Questionoption.optioncontent%TYPE DEFAULT NULL, 
			OQuestionId Questionoption.questionid%TYPE DEFAULT NULL) AS O_all sys_refcursor;
    BEGIN
        -- Create
        IF func = 'CREATE' THEN
             INSERT INTO Questionoption(Optioncontent, Questionid)
             VALUES (OContent , OQuestionId);
             COMMIT;
             
         -- Update    
        ELSIF func = 'UPDATE' THEN    
             UPDATE Questionoption SET Optioncontent = OContent, Questionid=OQuestionId
             WHERE Id = Oid;
             COMMIT;
        
         --Delete    
        ELSIF func = 'DELETE' THEN  
             DELETE Questionoption WHERE Id=Oid;
             COMMIT;
        -- Get All 
        ELSE    
            open O_all for
            select * from Questionoption;
            DBMS_SQL.RETURN_RESULT(O_all);
            
       END IF;     
    END QuestionOptionCRUD; 
    
END QuestionOptionPackage;
