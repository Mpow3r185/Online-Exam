create or replace PACKAGE BODY SCOREPACKAGE AS

PROCEDURE ScoreCRUD(
    func IN VARCHAR DEFAULT NULL,
    SCOREID SCORE.ID%TYPE DEFAULT NULL,
    SCGRADE SCORE.GRADE%TYPE DEFAULT NULL,
    SCSTATUS SCORE.STATUS%TYPE DEFAULT NULL,
    EXID SCORE.EXAMID%TYPE DEFAULT NULL,
    ACCID SCORE.ACCOUNTID%TYPE DEFAULT NULL)
    AS
        C_ALL SYS_REFCURSOR;
    BEGIN
        If func = 'CREATE' THEN
            INSERT INTO SCORE (GRADE,STATUS,EXAMID,ACCOUNTID)
            VALUES (SCGRADE,SCSTATUS,EXID,ACCID);

            COMMIT; 

        ELSIF func = 'UPDATE' THEN
            UPDATE SCORE SET
            GRADE     = SCGRADE,
            STATUS    = SCSTATUS,
            EXAMID    = EXID,
            ACCOUNTID = ACCID
            WHERE ID  = SCOREID;

            COMMIT;

        ELSIF func = 'DELETE' THEN
            DELETE FROM SCORE 
            WHERE ID = SCOREID;

            COMMIT;

        ELSE 
            OPEN C_ALL FOR
            SELECT * 
            FROM Score;

            DBMS_SQL.RETURN_RESULT(C_ALL);
        END IF;        
    END  ScoreCRUD; 

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
        CertificatePackage.CertificateCRUD(
            func => 'CREATE',
            createDate => CURRENT_TIMESTAMP,
            exam_id => exid,
            acc_id => accid);

        st := 'Successful';
    ELSE 
        st := 'Fail';
    END IF;

    -- Create Score
    ScorePackage.ScoreCRUD('Create',totalMark, st, exid, accid);

END CalculateScore;

------------------------------------------------------
END SCOREPACKAGE;

--******************************************************************************