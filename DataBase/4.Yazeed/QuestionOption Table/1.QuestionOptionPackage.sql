--------------------------------------------------------
-- Package for Table QuestionOption
--------------------------------------------------------

/*
*
* * QuestionOption Package Header 
*
*/

CREATE OR REPLACE PACKAGE QuestionOptionPackage AS
    --QuestionOption CRUD operation
    PROCEDURE QuestionOptionCRUD(
            func IN VARCHAR DEFAULT NULL,
            Oid Questionoption.id%TYPE DEFAULT NULL, 
	    OContent Questionoption.optioncontent%TYPE DEFAULT NULL, 
	    OQuestionId Questionoption.questionid%TYPE DEFAULT NULL);
END QuestionOptionPackage;
