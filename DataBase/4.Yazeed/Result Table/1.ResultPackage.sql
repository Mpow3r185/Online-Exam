--------------------------------------------------------
-- Package for Table Result
--------------------------------------------------------

/* 
*
* * Result Package Header 
*
*/

CREATE OR REPLACE PACKAGE ResultPackage AS
    --Result CRUD operation
    PROCEDURE ResultCRUD(
            func IN VARCHAR DEFAULT NULL,
            Rid Result.id%TYPE DEFAULT NULL, 
	    RQuestionOptionId Result.questionoptionid%TYPE DEFAULT NULL, 
	    RAccountId Result.accountid%TYPE DEFAULT NULL);
END ResultPackage;
