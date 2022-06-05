-- Start Code

CREATE OR REPLACE PACKAGE FillResultPackage AS
    
    -- FillResult CRUD Operations
    PROCEDURE FillResultCRUD(
        func IN VARCHAR DEFAULT NULL,
        frid IN fillResult.Id%type DEFAULT NULL,
        ans IN fillResult.answer%type DEFAULT NULL,
        qid IN fillResult.questionId%type DEFAULT NULL,
        accid IN fillResult.accountId%type DEFAULT NULL);
    
    -- Get Answer By QuestionId And Account Id
    PROCEDURE GetAnswerByQuestionIdAndAccountId(
        qid IN fillResult.questionId%type,
        accid IN fillResult.accountId%type);
        
    -- Get FillResult By QuestionId
    PROCEDURE GetFillResultByQuestionId(qid IN fillResult.questionId%type);
    
END FillResultPackage;

-- End Code