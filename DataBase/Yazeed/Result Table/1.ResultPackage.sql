--------------------------------------------------------
-- Package for Table Result
--------------------------------------------------------

/* 
*
* * Result Package Header 
*
*/

CREATE OR REPLACE PACKAGE ResultPackage AS
    --Get All Result
    PROCEDURE GetAllResult;
	
    --Update Result
    PROCEDURE UpdateResult(
			Rid Result.id%TYPE, 
			RQuestionOptionId Result.questionoptionid%TYPE, 
			RAccountId Result.accountid%TYPE
			);
			
    --Create Result
    PROCEDURE CreateResult(
			RQuestionOptionId Result.questionoptionid%TYPE, 
			RAccountId Result.accountid%TYPE
			);
			
    --Delete Result
    PROCEDURE DeleteResult(Rid Result.id%TYPE);
END ResultPackage;