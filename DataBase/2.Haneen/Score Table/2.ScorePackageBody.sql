create or replace PACKAGE BODY SCOREPACKAGE AS

PROCEDURE ScoreCRUD(
    func IN VARCHAR DEFAULT NULL,
    SCOREID SCORE.ID%TYPE DEFAULT NULL,
    SCGRADE SCORE.GRADE%TYPE DEFAULT NULL,
    SCSTATUS SCORE.STATUS%TYPE DEFAULT NULL,
    SCCreateDate SCORE.creationDate%type DEFAULT NULL,
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
            CREATIONDATE = SCCreateDate,
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
    multipleQuestionsMarks Score.grade%type;
    fillQuestionsMarks Score.grade%type;
    succMark Exam.SuccessMark%type;
    fullMark Question.score%type;
    st Score.status%type;
    
    mtQid Question.id%type;
    mtScore NUMBER;
    mtQScore NuMBER;
    numOfCorrectOptions INT;
    numOfIncorrectOptions INT;
    numOfOptions INT;
    
    scid Score.id%type;
    
    multipleQuestions SYS_REFCURSOR;

BEGIN
    totalMark := 0;
    multipleQuestionsMarks := 0;
    fillQuestionsMarks := 0;

    SELECT successMark
    INTO succMark
    FROM Exam
    WHERE id = exid;

    SELECT SUM(score)
    INTO fullMark
    FROM Question
    WHERE examId = exid;

    -- For Single Marks
    SELECT SUM(Q.score) AS Score
    INTO totalMark
    FROM Result R
    JOIN QuestionOption QO ON R.QuestionOptionId = QO.Id
    JOIN Question Q ON QO.QuestionId = Q.Id
    JOIN CorrectAnswer CA ON QO.Id = CA.QuestionOptionId
    WHERE Q.type = 'Single'
    AND examId = exid AND accountId = accid;
    
    -- For Multiple Marks
    OPEN multipleQuestions FOR
    SELECT id
    FROM Question
    WHERE Question.type = 'Multiple' AND Question.examId = exid;
    
    LOOP
    FETCH multipleQuestions INTO mtQid;
    EXIT WHEN multipleQuestions%NOTFOUND;
        QuestionPackage.GetScoreForQuestion(QID => mtQid, POINTS => mtScore);
        QuestionPackage.GetNumOptionsForTypicalAnswer(QID => mtQid, N => numOfOptions);
        
        QuestionPackage.GetNumberCorrectAnswers(
            QID => mtQid,
            EXID => exid,
            ACCID => accid,
            N => numOfCorrectOptions);
            
        QuestionPackage.GetNumberIncorrectAnswers(
            QID => mtQid,
            EXID => exid,
            ACCID => accid,
            N => numOfIncorrectOptions);
            
        mtQScore := ((numOfCorrectOptions / numOfOptions * mtScore) - (numOfIncorrectOptions / numOfOptions * mtScore));
        IF mtQScore < 0 THEN
            mtQScore := 0;
        END IF;
        multiplequestionsmarks := multiplequestionsmarks + mtQScore;
        
    END LOOP;

    -- For Fill Marks
    SELECT SUM(Q.score) AS Score
    INTO fillQuestionsMarks
    FROM FillResult FR
    JOIN QuestionOption QO ON FR.questionId = QO.questionId
    JOIN Question Q ON QO.questionId = Q.id
    WHERE QO.optionContent LIKE FR.answer AND FR.accountId = accid;

    totalMark := totalMark + fillQuestionsMarks + multiplequestionsmarks;

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
    
    SELECT id
    INTO scid
    FROM Score
    WHERE examId = exid AND accountId = accid;
    
    -- Create Score
    ScorePackage.ScoreCRUD(
        FUNC => 'UPDATE',
        SCOREID => scid,
        SCGRADE => totalMark, 
        SCSTATUS => st,
        SCCreateDate => CURRENT_TIMESTAMP,
        EXID => exid, 
        ACCID => accid);

END CalculateScore;


-- Get Score By Exam Id And Account Id
    PROCEDURE GetScoreByExamIdAndAccountId(
        accid IN account.id%type,
        exid IN exam.id%type) AS
        
        ref_cursor SYS_REFCURSOR;
    BEGIN
        OPEN ref_cursor FOR
        SELECT *
        FROM Score
        WHERE examId = exid AND accountId = accid;
        
        DBMS_SQL.RETURN_RESULT(ref_cursor);
    END GetScoreByExamIdAndAccountId;

------------------------------------------------------
END SCOREPACKAGE;

--******************************************************************************