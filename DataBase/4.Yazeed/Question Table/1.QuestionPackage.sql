--------------------------------------------------------
-- Package for Table Question
--------------------------------------------------------

/* 
*
* * Question Package Header 
*
*/

CREATE OR REPLACE PACKAGE QuestionPackage AS
    --Question CRUD operation
    PROCEDURE QuestionCRUD(
               func IN VARCHAR DEFAULT NULL,
               Qid Question.id%TYPE, 
			   QContent Question.questioncontent%TYPE,
			   QType Question.type%TYPE ,
			   QScore Question.score%TYPE, 
			   QStatues Question.status%TYPE, 
			   QExamId Question.examid%TYPE);
END QuestionPackage;
