--------------------------------------------------------
-- Package for Table Question
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
			   QType Question.type%TYPE,
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