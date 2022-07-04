--------------------------------------------------------
-- Package for Table QuestionOption
--------------------------------------------------------

/*
*
* * QuestionOption Package Header 
*
*/

create or replace PACKAGE QuestionOptionPackage AS
    -- QuestionOption CRUD operation
    PROCEDURE QuestionOptionCRUD(
            func IN VARCHAR DEFAULT NULL,
            Oid Questionoption.id%TYPE DEFAULT NULL, 
	    OContent Questionoption.optioncontent%TYPE DEFAULT NULL, 
	    OQuestionId Questionoption.questionid%TYPE DEFAULT NULL);

    -- Get QuestionOption By Question Id
    PROCEDURE GetQuestionOptionByQuestionId(
    qid IN QuestionOption.questionId%type);
END QuestionOptionPackage;
