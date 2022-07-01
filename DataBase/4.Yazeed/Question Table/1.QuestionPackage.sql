--------------------------------------------------------
-- Package for Table Question
--------------------------------------------------------

/* 
*
* * Question Package Header 
*
*/

CREATE OR REPLACE PACKAGE QuestionPackage AS

    -- Question CRUD operation
    PROCEDURE QuestionCRUD(
           func IN VARCHAR DEFAULT NULL,
           Qid Question.id%TYPE DEFAULT NULL, 
	       QContent Question.questioncontent%TYPE DEFAULT NULL,
	       QType Question.type%TYPE DEFAULT NULL,
	       QScore Question.score%TYPE DEFAULT NULL, 
	       QStatues Question.status%TYPE DEFAULT NULL, 
	       QExamId Question.examid%TYPE DEFAULT NULL);
           
    -- Get Questions By Exam Id
    PROCEDURE GetQeustionsByExamId(exid IN question.examId%type);
    
END QuestionPackage;
