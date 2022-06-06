-- Start Code

CREATE OR REPLACE PACKAGE ExamPackage AS

    -- Exam CRUD Operations
    PROCEDURE ExamCRUD(
        func IN VARCHAR DEFAULT NULL,
        exid IN exam.id%type DEFAULT NULL,
        cid IN exam.courseId%type DEFAULT NULL,
        exTitle IN exam.title%type DEFAULT NULL,
        passc IN exam.passcode%type DEFAULT NULL,
        des IN exam.description%type DEFAULT NULL,
        exLevel IN exam.examLevel%type DEFAULT NULL,
        succMark IN exam.successMark%type DEFAULT NULL,
        price IN exam.cost%type DEFAULT NULL,
        stDate IN exam.startDate%type DEFAULT NULL,
        enDate IN exam.endDate%type DEFAULT NULL,
        st IN exam.status%type DEFAULT NULL,
        createDate IN exam.creationDate%type DEFAULT NULL);
    
    -- Search Exam Procedure
    PROCEDURE SearchExam(
        exTitle IN exam.title%type DEFAULT NULL,
        exLevel IN exam.examLevel%type DEFAULT NULL,
        succMark IN exam.successMark%type DEFAULT NULL,
        price IN exam.cost%type DEFAULT NULL,
        stDate IN exam.startDate%type DEFAULT NULL,
        enDate IN exam.endDate%type DEFAULT NULL,
        createDate IN exam.creationDate%type DEFAULT NULL);
        
    -- Buy Exam Procedure
    PROCEDURE BuyExam(
        accid IN account.id%type,
        exid IN exam.id%type);
        
    -- Enter Exam Procedure
    PROCEDURE EnterExam(
        accid account.id%type,
        exid exam.id%type);

END ExamPackage;

-- End Code