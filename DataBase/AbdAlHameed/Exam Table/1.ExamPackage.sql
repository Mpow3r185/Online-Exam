-- Start Code

CREATE OR REPLACE PACKAGE ExamPackage AS

    -- CRUD Procedures
    -- Get Exams Procedure
    PROCEDURE GetExams;

    -- Create Exam Procedure
    PROCEDURE CreateExam(
       cid IN exam.courseId%type,
       exTitle IN exam.title%type,
       passc IN exam.passcode%type,
       des IN exam.description%type,
       exLevel IN exam.examLevel%type,
       succMark IN exam.successMark%type,
       price IN exam.cost%type,
       stDate IN exam.startDate%type,
       enDate IN exam.endDate%type,
       st IN exam.status%type,
       createDate IN exam.creationDate%type);

    -- Update Exam Procedure
    PROCEDURE UpdateExam(
       exid IN exam.id%type,
       cid IN exam.courseId%type,
       exTitle IN exam.title%type,
       passc IN exam.passcode%type,
       des IN exam.description%type,
       exLevel IN exam.examLevel%type,
       succMark IN exam.successMark%type,
       price IN exam.cost%type,
       stDate IN exam.startDate%type,
       enDate IN exam.endDate%type,
       st IN exam.status%type,
       createDate IN exam.creationDate%type);

    -- Delete Exam Procedure
    PROCEDURE DeleteExam(exid IN exam.id%type);
    -- CRUD Procedures

    -- Search Exam Procedure
    PROCEDURE SearchExam(
        exTitle IN exam.title%type,
        exLevel IN exam.examLevel%type,
        succMark IN exam.successMark%type,
        price IN exam.cost%type,
        stDate IN exam.startDate%type,
        enDate IN exam.endDate%type,
        createDate IN exam.creationDate%type);

END ExamPackage;

-- End Code