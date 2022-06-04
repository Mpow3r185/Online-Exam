--   SCORE PACKAGE BODY

CREATE OR REPLACE PACKAGE BODY SCOREPACKAGE AS
----------------------------------------------------
--  GET ALL

PROCEDURE GETALL AS
C_ALL SYS_REFCURSOR;
BEGIN
OPEN C_ALL FOR
SELECT * FROM SCORE;
DBMS_SQL.RETURN_RESULT(C_ALL);
END GETALL;
----------------------------------------------------
-- UPDATE SCORE

PROCEDURE UPDATESCORE(
    SCOREID SCORE.ID%TYPE,
    SCGRADE SCORE.GRADE%TYPE,
    SCSTATUS SCORE.STATUS%TYPE,
    EXID SCORE.EXAMID%TYPE,
    ACCID SCORE.ACCOUNTID%TYPE
    ) AS
BEGIN
UPDATE SCORE SET
    GRADE     = SCGRADE,
    STATUS    = SCSTATUS,
    EXAMID    = EXID,
    ACCOUNTID = ACCID
    WHERE ID  = SCOREID;
COMMIT;
END UPDATESCORE;
----------------------------------------------------
-- CREATE SCORE

PROCEDURE CREATESCORE(
    SCGRADE SCORE.GRADE%TYPE,
    SCSTATUS SCORE.STATUS%TYPE,
    EXID SCORE.EXAMID%TYPE,
    ACCID SCORE.ACCOUNTID%TYPE
    ) AS
BEGIN
    INSERT INTO SCORE (GRADE,STATUS,EXAMID,ACCOUNTID)
    VALUES (SCGRADE,SCSTATUS,EXID,ACCID);
COMMIT;
END CREATESCORE;
----------------------------------------------------
-- DELETE SCORE

PROCEDURE DELETESCORE(SCOREID SCORE.ID%TYPE) AS
BEGIN
    DELETE FROM SCORE 
    WHERE ID = SCOREID;
COMMIT;
END DELETESCORE;

----------------------------------------------------
-- Calculate Score Procedure
PROCEDURE CalculateScore(
    accid IN account.id%type,
    exid IN exam.id%type) AS 
    
    totalMark Score.grade%type;
    fillQuestionsMarks Score.grade%type;
    succMark Exam.SuccessMark%type;
    fullMark Question.score%type;
    st Score.status%type;

BEGIN
    SELECT successMark
    INTO succMark
    FROM Exam
    WHERE id = exid;
    
    SELECT SUM(score)
    INTO fullMark
    FROM Question
    WHERE examId = exid;
    
    -- For Single And Multiple Marks
    SELECT SUM(Q.score) AS Score
    INTO totalMark
    FROM Result R
    JOIN QuestionOption QO ON R.QuestionOptionId = QO.Id
    JOIN Question Q ON QO.QuestionId = Q.Id
    JOIN CorrectAnswer CA ON QO.Id = CA.QuestionOptionId
    WHERE Q.type = 'Single' OR Q.type = 'Multiple'
    AND examId = exid AND accountId = accid;
    
    -- For Fill Marks
    SELECT SUM(Q.score) AS Score
    INTO fillQuestionsMarks
    FROM FillResult FR
    JOIN QuestionOption QO ON FR.questionId = QO.questionId
    JOIN Question Q ON QO.questionId = Q.id
    WHERE QO.optionContent LIKE FR.answer AND FR.accountId = accid;
    
    totalMark := totalMark + fillQuestionsMarks;
    
    IF totalMark IS NULL THEN
        totalMark := 0;
    END IF;
    
    IF totalMark >= succMark THEN
        -- Create Certificate
        CertificatePackage.CreateCertificate(
            CURRENT_TIMESTAMP,
            exid,
            accid);
    
        st := 'Successful';
    ELSE 
        st := 'Fail';
    END IF;
    
    -- Create Score
    ScorePackage.CreateScore(totalMark, st, exid, accid);

END CalculateScore;

------------------------------------------------------
END SCOREPACKAGE;

--******************************************************************************
