
--------------------------------------------------------
-- Backage for Table Question
--------------------------------------------------------

/* 
*
* * Question Package Header 
*
*/

CREATE OR REPLACE PACKAGE QuestionPackage AS
    --Get All Question
    PROCEDURE GetAllQuestion;
	
    --Update Question
    PROCEDURE UpdateQuestion(
	           Qid Question.id%TYPE, 
			   QContent Question.questioncontent%TYPE,
			   QType Question.type%TYPE ,
			   QScore Question.score%TYPE, 
			   QStatues Question.status%TYPE, 
			   QExamId Question.examid%TYPE
			   );
			   
    --Create Question
    PROCEDURE CreateQuestion(
			 QContent Question.questioncontent%TYPE,
			 QType Question.type%TYPE ,
			 QScore Question.score%TYPE, 
			 QStatues Question.status%TYPE, 
			 QExamId Question.examid%TYPE
			 );
			 
    --Delete Question
    PROCEDURE DeleteQuestion(Qid Question.id%TYPE);
END QuestionPackage;



/*
*
* * Question Package Body 
*
*/

CREATE OR REPLACE PACKAGE Body QuestionPackage AS
    --Body For Get All Question
    PROCEDURE GetAllQuestion AS Q_all sys_refcursor;
    BEGIN
        open Q_all for
        select * from Question;
        DBMS_SQL.RETURN_RESULT(Q_all);
    END GetAllQuestion;

    --Body For Update Question
    PROCEDURE UpdateQuestion(
			Qid Question.id%TYPE, 
			QContent Question.questioncontent%TYPE,
			QType Question.type%TYPE ,
			QScore Question.score%TYPE, 
			QStatues Question.status%TYPE, 
			QExamId Question.examid%TYPE
			) AS        
    BEGIN
    UPDATE Question SET Questioncontent = QContent, Type=QType, Score=QScore, Status=QStatues, Examid=QExamId
    WHERE Id = Qid;
    COMMIT;
    END UpdateQuestion;

    --Body For Create Question
    PROCEDURE CreateQuestion(QContent Question.questioncontent%TYPE,QType Question.type%TYPE ,QScore Question.score%TYPE, QStatues Question.status%TYPE, QExamId Question.examid%TYPE) AS
    BEGIN
    INSERT INTO Question(Questioncontent, Type, Score, Status, Examid)
    VALUES (QContent , QType , QScore , QStatues, QExamId);
    COMMIT;
    END CreateQuestion;
    
    --Body For Delete Question
    PROCEDURE DeleteQuestion(Qid Question.id%TYPE) AS
    BEGIN
    DELETE Question WHERE Id=Qid;
    COMMIT;
    END DeleteQuestion;
    
END QuestionPackage;


