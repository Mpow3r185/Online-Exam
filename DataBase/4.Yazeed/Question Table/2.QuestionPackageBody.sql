create or replace PACKAGE Body QuestionPackage AS
   --Body For Question CRUD operation
    PROCEDURE QuestionCRUD(
                func IN VARCHAR DEFAULT NULL,
                Qid Question.id%TYPE DEFAULT NULL, 
		QContent Question.questioncontent%TYPE DEFAULT NULL,
		QType Question.type%TYPE DEFAULT NULL,
		QScore Question.score%TYPE DEFAULT NULL, 
	        QStatues Question.status%TYPE DEFAULT NULL, 
	        QExamId Question.examid%TYPE DEFAULT NULL) AS Q_all sys_refcursor;
    BEGIN
        -- Create
        IF func = 'CREATE' THEN
            INSERT INTO Question(Questioncontent, Type, Score, Status, Examid)
            VALUES (QContent , QType , QScore , QStatues, QExamId);
            COMMIT;

        -- Update    
        ELSIF func = 'UPDATE' THEN    
            UPDATE Question SET Questioncontent = QContent, Type=QType, Score=QScore, Status=QStatues, Examid=QExamId
            WHERE Id = Qid;
            COMMIT;

        --Delete    
        ELSIF func = 'DELETE' THEN  
            DELETE Question WHERE Id=Qid;
            COMMIT;

        -- Get All 
        ELSE    
            open Q_all for
            select * from Question;
            DBMS_SQL.RETURN_RESULT(Q_all);

        END IF;
    END QuestionCRUD;


    -- Get Questions By Exam Id
    PROCEDURE GetQeustionsByExamId(exid IN question.examId%type) AS
        ref_cursor SYS_REFCURSOR;

    BEGIN
        OPEN ref_cursor FOR
        SELECT *
        FROM Question
        WHERE examId = exid; 


        DBMS_SQL.RETURN_RESULT(ref_cursor);
    END GetQeustionsByExamId;
    
    -- Get Full Mark For The Question
    PROCEDURE GetScoreForQuestion(
        qid IN Question.id%type, 
        points OUT NUMBER) AS 
    BEGIN
        SELECT score
        INTO points
        FROM Question
        WHERE id = qid;
    
    END GetScoreForQuestion;
    
    -- Get Number Options For Typical Answer
    PROCEDURE GetNumOptionsForTypicalAnswer(
        qid IN Question.id%type, 
        n OUT INT) AS
    BEGIN
        SELECT COUNT(*)
        INTO n
        FROM Question
        JOIN QuestionOption ON Question.id = QuestionOption.questionId
        JOIN CorrectAnswer ON QuestionOption.id = CorrectAnswer.questionOptionId
        WHERE Question.id = qid;
        
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            n := 0;
    
    END GetNumOptionsForTypicalAnswer;
    
    
    -- Get Number Of User Correct Answers
    PROCEDURE GetNumberCorrectAnswers(
        qid IN Question.id%type,
        accId IN Account.id%type,
        exid IN Exam.id%type,
        n OUT INT) AS
    BEGIN
        SELECT Count(*)
        INTO n
        FROM QuestionOption
        JOIN Question ON Question.id = QuestionOption.QuestionId
        LEFT JOIN CorrectAnswer ON CorrectAnswer.QuestionOptionId = QuestionOption.Id
        JOIN Result ON result.questionoptionid = QuestionOption.Id
        WHERE Question.type = 'Multiple'
        AND Result.accountId = accId
        AND Question.examId = exid
        AND Question.id = qid
        AND QuestionOption.Id = CorrectAnswer.questionOptionid
        GROUP BY Question.id;
        
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            n := 0;
    
    END GetNumberCorrectAnswers;
    
    
    -- Get Number Of User Answer Incorrect
    PROCEDURE GetNumberIncorrectAnswers(
        qid IN Question.id%type,
        accId IN Account.id%type,
        exid IN Exam.id%type,
        n OUT INT) AS
    BEGIN
        SELECT COUNT(*)
        INTO n
        FROM QuestionOption
        JOIN Question ON Question.id = QuestionOption.QuestionId
        LEFT JOIN CorrectAnswer ON CorrectAnswer.QuestionOptionId = QuestionOption.Id
        JOIN Result ON result.questionoptionid = QuestionOption.Id
        WHERE Question.type = 'Multiple'
        AND Result.accountId = accId
        AND Question.examId = exid
        AND Question.id = qid
        AND CorrectAnswer.id IS NULL;
        
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            n := 0;
    
    END GetNumberIncorrectAnswers;
    
    
END QuestionPackage;