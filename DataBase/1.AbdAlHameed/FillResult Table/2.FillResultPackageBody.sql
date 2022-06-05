-- Start Code

CREATE OR REPLACE PACKAGE BODY FillResultPackage AS

    -- FillResult CRUD Operations
    PROCEDURE FillResultCRUD(
        func IN VARCHAR DEFAULT NULL,
        frid IN fillResult.Id%type DEFAULT NULL,
        ans IN fillResult.answer%type DEFAULT NULL,
        qid IN fillResult.questionId%type DEFAULT NULL,
        accid IN fillResult.accountId%type DEFAULT NULL) AS
        
        ref_cursor SYS_REFCURSOR;
    BEGIN
        IF func = 'CREATE' THEN
            INSERT INTO FillResult (answer, questionId, accountId)
            VALUES(ans, qid, accid);
            
            COMMIT;
        ELSIF func = 'UPDATE' THEN
            UPDATE FillResult
            SET answer = ans,
                questionId = qid,
                accountId = accid
            WHERE id = frid;
        
            COMMIT;
        ELSIF func = 'DELETE' THEN
            DELETE FROM FillResult WHERE id = frid;
    
            COMMIT;
        ELSE
            OPEN ref_cursor FOR
            SELECT *
            FROM FillResult;
            
            DBMS_SQL.RETURN_RESULT(ref_cursor);
        END IF;
    
    END FillResultCRUD;
    
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