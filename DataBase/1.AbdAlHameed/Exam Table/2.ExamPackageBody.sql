-- Start Code

CREATE OR REPLACE PACKAGE BODY ExamPackage AS

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
        exImg IN exam.examImage%type DEFAULT NULL,
        createDate IN exam.creationDate%type DEFAULT NULL) AS
        
        ref_cursor SYS_REFCURSOR;
    BEGIN
        IF func = 'CREATE' THEN
            INSERT INTO Exam
            (courseId, title, passcode, description, examLevel, successMark,
             cost, startDate, endDate, status, examImage, creationDate)

            VALUES(cid, exTitle, UPPER(passc), des, exLevel, succMark,
                   price, stDate, enDate, UPPER(st), exImg, createDate);

            COMMIT;
        ELSIF func = 'UPDATE' THEN
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
                examImage = exImg,
                creationDate = createDate
            WHERE id = exid;

            COMMIT;
        ELSIF func = 'DELETE' THEN
            DELETE FROM Exam WHERE id = exid;

            COMMIT;
        ELSE
            OPEN ref_cursor FOR
            SELECT *
            FROM Exam;

            DBMS_SQL.RETURN_RESULT(ref_cursor);
        END IF;

    END ExamCRUD;

    -- Search Exam Procedure
    PROCEDURE SearchExam(
        exTitle IN exam.title%type DEFAULT NULL,
        exLevelBeginner IN exam.examLevel%type DEFAULT NULL,
        exLevelIntermediate IN exam.examLevel%type DEFAULT NULL,
        exLevelAdvanced IN exam.examLevel%type DEFAULT NULL,
        exLevelExpert IN exam.examLevel%type DEFAULT NULL,
        succMark IN exam.successMark%type DEFAULT NULL,
        price IN exam.cost%type DEFAULT NULL,
        stDate IN exam.startDate%type DEFAULT NULL,
        enDate IN exam.endDate%type DEFAULT NULL,
        createDate IN exam.creationDate%type DEFAULT NULL) AS 

            ref_cursor SYS_REFCURSOR;
        BEGIN
            OPEN ref_cursor FOR
            SELECT *
            FROM Exam
            WHERE (exTitle IS NULL OR title LIKE '%' || exTitle || '%')
            AND ((examLevel = exLevelBeginner)
            OR (examLevel = exLevelIntermediate)
            OR (examLevel = exLevelAdvanced)
            OR (examLevel = exLevelExpert)
            OR (exLevelBeginner IS NULL AND exLevelIntermediate IS NULL AND exLevelAdvanced IS NULL AND exLevelExpert IS NULL))
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

    -- Buy Exam Procedure
    PROCEDURE BuyExam(
        accid IN account.id%type,
        exid IN exam.id%type) AS

            accBalance creditCard.balance%type;
            examPrice exam.cost%type;
        BEGIN
            SELECT balance
            INTO accBalance
            FROM creditCard
            WHERE accountId = accid;

            SELECT cost
            INTO examPrice
            FROM exam
            WHERE id = exid;

            IF accBalance >= examPrice THEN 
                InvoicePackage.InvoiceCRUD(
                    CREATEDATE => CURRENT_TIMESTAMP,
                    EXAM_ID => exid,
                    ACC_ID => accid); -- Create invoice

                CreditCardPackage.UpdateBalance(accid, accBalance - examPrice); -- Pay for the exam
            END IF;

        END BuyExam;

    -- Enter Exam Procedure
    PROCEDURE EnterExam(
        accid account.id%type,
        exid exam.id%type) AS 

        ref_cursor SYS_REFCURSOR;
    BEGIN
        OPEN ref_cursor FOR
        SELECT examId, accountId
        FROM Invoice
        WHERE examId = exid AND accountId = accid;

        DBMS_SQL.RETURN_RESULT(ref_cursor);
    END EnterExam;

    -- Get Exams By Course Id
    PROCEDURE GetExamsByCourseId(cid IN exam.courseId%type) AS
        ref_cursor SYS_REFCURSOR;
    BEGIN
        OPEN ref_cursor FOR
        SELECT *
        FROM Exam
        WHERE courseId = cid;

        DBMS_SQL.RETURN_RESULT(ref_cursor);
    END GetExamsByCourseId;

END ExamPackage;

-- End Code