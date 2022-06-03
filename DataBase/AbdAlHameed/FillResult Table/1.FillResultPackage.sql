-- Start Code

CREATE OR REPLACE PACKAGE FillResultPackage AS

    -- CRUD Operations
    -- Get Fill Results Procedure
    PROCEDURE GetFillResults;
    
    -- Create Fill Result Procedure
    PROCEDURE CreateFillResult(
        ans IN fillResult.answer%type,
        qid IN fillResult.questionId%type,
        accid IN fillResult.accountId%type);
        
    -- Update Fill Result Procedure
    PROCEDURE UpdateFillResult(
        frid IN fillResult.Id%type,
        ans IN fillResult.answer%type,
        qid IN fillResult.questionId%type,
        accid IN fillResult.accountId%type);
        
    -- Delete Fill Result Procedure
    PROCEDURE DeleteFillResult(frid IN fillResult.Id%type);
    -- CRUD Operations
    
    -- Get Answer By QuestionId And Account Id
    PROCEDURE GetAnswerByQuestionIdAndAccountId(
        qid IN fillResult.questionId%type,
        accid IN fillResult.accountId%type);
        
    -- Get FillResult By QuestionId
    PROCEDURE GetFillResultByQuestionId(qid IN fillResult.questionId%type);
    
END FillResultPackage;

-- End Code