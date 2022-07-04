create or replace PACKAGE QuestionPackage AS

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
    
    -- Get Full Mark For The Question
    PROCEDURE GetScoreForQuestion(
        qid IN Question.id%type, 
        points OUT NUMBER);
        
    -- Get Number Options For Typical Answer
    PROCEDURE GetNumOptionsForTypicalAnswer(
        qid IN Question.id%type,
        n OUT INT);
        
    -- Get Number Of User Correct Answers
    PROCEDURE GetNumberCorrectAnswers(
        qid IN Question.id%type,
        accId IN Account.id%type,
        exid IN Exam.id%type,
        n OUT INT);
        
    -- Get Number Of User Answer Incorrect
    PROCEDURE GetNumberIncorrectAnswers(
        qid IN Question.id%type,
        accId IN Account.id%type,
        exid IN Exam.id%type,
        n OUT INT);
        
END QuestionPackage;