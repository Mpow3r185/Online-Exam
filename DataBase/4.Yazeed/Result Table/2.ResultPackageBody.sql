/*
*
* * Result Package Body 
*
*/
CREATE OR REPLACE PACKAGE Body ResultPackage AS
    --Body For Get All Result
    PROCEDURE GetAllResult AS R_all sys_refcursor;
    BEGIN
        open R_all for
        select * from Result;
        DBMS_SQL.RETURN_RESULT(R_all);
    END GetAllResult;

    --Body For Update Result
    PROCEDURE UpdateResult(Rid Result.id%TYPE, RQuestionOptionId Result.questionoptionid%TYPE, RAccountId Result.accountid%TYPE) AS        
    BEGIN
    UPDATE Result SET Questionoptionid=RQuestionOptionId, Accountid=RAccountId
    WHERE Id = Rid;
    COMMIT;
    END UpdateResult;

    --Body For Create Result
    PROCEDURE CreateResult(RQuestionOptionId Result.questionoptionid%TYPE, RAccountId Result.accountid%TYPE) AS
    BEGIN
    INSERT INTO Result(Questionoptionid, Accountid)
    VALUES (RQuestionOptionId , RAccountId);
    COMMIT;
    END CreateResult;
    
    --Body For Delete Result
    PROCEDURE DeleteResult(Rid Result.id%TYPE) AS
    BEGIN
    DELETE Result WHERE Id=Rid;
    COMMIT;
    END DeleteResult;
    
END ResultPackage;