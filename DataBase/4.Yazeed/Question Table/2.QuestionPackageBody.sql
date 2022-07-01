/*
*
* * Question Package Body 
*
*/

CREATE OR REPLACE PACKAGE Body QuestionPackage AS
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
    
END QuestionPackage;
