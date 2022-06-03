-- Start Code

CREATE OR REPLACE PACKAGE BODY FillResultPackage AS

    -- CRUD Operations
    -- Get Fill Results Procedure
    PROCEDURE GetFillResults AS
        ref_cursor SYS_REFCURSOR;
    BEGIN
        OPEN ref_cursor FOR
        SELECT *
        FROM FillResult;
        
        DBMS_SQL.RETURN_RESULT(ref_cursor);
    END GetFillResults;
    
    -- Create Fill Result Procedure
    PROCEDURE CreateFillResult(
        ans IN fillResult.answer%type,
        qid IN fillResult.questionId%type,
        accid IN fillResult.accountId%type) AS
    BEGIN
        INSERT INTO FillResult (answer, questionId, accountId)
        VALUES(ans, qid, accid);
        
        COMMIT;
    END CreateFillResult;
        
    -- Update Fill Result Procedure
    PROCEDURE UpdateFillResult(
        frid IN fillResult.Id%type,
        ans IN fillResult.answer%type,
        qid IN fillResult.questionId%type,
        accid IN fillResult.accountId%type) AS
    BEGIN
        UPDATE FillResult
        SET answer = ans,
            questionId = qid,
            accountId = accid
        WHERE id = frid;
    
        COMMIT;
    END UpdateFillResult;
        
    -- Delete Fill Result Procedure
    PROCEDURE DeleteFillResult(frid IN fillResult.Id%type) AS
    BEGIN
        DELETE FROM FillResult WHERE id = frid;
    
        COMMIT;
    END DeleteFillResult;
    -- CRUD Operations
    
    -- Get Answer By QuestionId And Account Id
    PROCEDURE GetAnswerByQuestionIdAndAccountId(
        qid IN fillResult.questionId%type,
        accid IN fillResult.accountId%type) AS 
        
        ref_cursor SYS_REFCURSOR;
    BEGIN
        OPEN ref_cursor FOR
        SELECT answer
        FROM FillResult
        WHERE questionId = qid
        AND accountid = accid;
        
        DBMS_SQL.RETURN_RESULT(ref_cursor);
    END GetAnswerByQuestionIdAndAccountId;
        
    -- Get FillResult By QuestionId
    PROCEDURE GetFillResultByQuestionId(qid IN fillResult.questionId%type) AS
        ref_cursor SYS_REFCURSOR;
    BEGIN
        OPEN ref_cursor FOR
        SELECT *
        FROM FillResult
        WHERE questionId = qid;
        
        DBMS_SQL.RETURN_RESULT(ref_cursor);
    END GetFillResultByQuestionId;
    
END FillResultPackage;

-- End Code