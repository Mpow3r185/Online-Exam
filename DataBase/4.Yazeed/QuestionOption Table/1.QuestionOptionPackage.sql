--------------------------------------------------------
-- Package for Table QuestionOption
--------------------------------------------------------

/*
*
* * QuestionOption Package Header 
*
*/

CREATE OR REPLACE PACKAGE QuestionOptionPackage AS
    --Get All QuestionOption
    PROCEDURE GetAllQuestionOption;
	
    --Update QuestionOption
    PROCEDURE UpdateQuestionOption(
			Oid Questionoption.id%TYPE, 
			OContent Questionoption.optioncontent%TYPE, 
			OQuestionId Questionoption.questionid%TYPE
			);
    
	--Create QuestionOption
    PROCEDURE CreateQuestionOption(
			OContent Questionoption.optioncontent%TYPE, 
			OQuestionId Questionoption.questionid%TYPE
			);
			
    --Delete QuestionOption
    PROCEDURE DeleteQuestionOption(Oid Questionoption.id%TYPE);
END QuestionOptionPackage;