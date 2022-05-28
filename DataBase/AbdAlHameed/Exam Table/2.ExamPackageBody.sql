-- Start Code

CREATE OR REPLACE PACKAGE BODY ExamPackage AS

    -- CRUD Procedures
    -- Get Exams Procedure
    PROCEDURE GetExams AS
        ref_cursor SYS_REFCURSOR;
    BEGIN
        OPEN ref_cursor FOR
        SELECT *
        FROM Exam;
    
        DBMS_SQL.RETURN_RESULT(ref_cursor);
    END GetExams;
    
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
       createDate IN exam.creationDate%type) AS
       
       BEGIN
            INSERT INTO Exam
            (courseId, title, passcode, description, examLevel,
            successMark, cost, startDate, endDate, status, creationDate)
            
            VALUES(cid, exTitle, UPPER(passc), des, exLevel, succMark,
                   price, stDate, enDate, UPPER(st), createDate);
            
            commit;
       END CreateExam;
       
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
       createDate IN exam.creationDate%type) AS
       
       BEGIN
            UPDATE Exam SET
                courseId = cid,
                title = exTitle,
                passcode = UPPER(passc),
                description = des,
                examLevel = exLevel,
                successMark = succMark,
                cost = price,
                startDate = stDate,
                endDate = enDate,
                status = UPPER(st),
                creationDate = createDate
            WHERE id = exid;
                
            commit;
       END UpdateExam;
       
    -- Delete Exam Procedure
    PROCEDURE DeleteExam(exid IN exam.id%type) AS
    BEGIN
        DELETE FROM Exam WHERE id = exid;
        
        commit;
    END DeleteExam;
    -- CRUD Procedures
    
    -- Search Exam Procedure
    PROCEDURE SearchExam(
        exTitle IN exam.title%type,
        exLevel IN exam.examLevel%type,
        succMark IN exam.successMark%type,
        price IN exam.cost%type,
        stDate IN exam.startDate%type,
        enDate IN exam.endDate%type,
        createDate IN exam.creationDate%type) AS 
            
            ref_cursor SYS_REFCURSOR;
        BEGIN
            OPEN ref_cursor FOR
            SELECT *
            FROM Exam
            WHERE (exTitle IS NULL OR title LIKE '%' || exTitle || '%')
            AND (exLevel IS NULL OR examLevel LIKE '%' || exLevel || '%')
            AND (succMark IS NULL OR successMark = succMark)
            AND (price IS NULL OR cost = price)
            
            AND ((stDate IS NULL AND enDate IS NULL)
               OR(stDate IS NULL AND enDate IS NOT NULL 
                    AND exam.endDate <= enDate)
               OR(stDate IS NOT NULL AND enDate IS NULL 
                    AND exam.startDate >= stDate)
               OR(stDate IS NOT NULL AND enDate IS NOT NULL AND
                    (exam.startDate >= stDate AND exam.endDate <= enDate)));
                    
            DBMS_SQL.RETURN_RESULT(ref_cursor);
        END SearchExam;
    
END ExamPackage;

-- End Code