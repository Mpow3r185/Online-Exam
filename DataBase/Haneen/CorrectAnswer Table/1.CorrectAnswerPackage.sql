--  CORRECT ANSWER PACKAGE

CREATE OR REPLACE PACKAGE CORRECTANSWERPACKAGE AS
-- GETALL CORRECT ANSWERS
PROCEDURE GETALL;

-- UPDATE CORRECT ANSWER
PROCEDURE UPDATECORRECTANSWER(
    CANSWERID CORRECTANSWER.ID%TYPE,
    QOID CORRECTANSWER.QUESTIONOPTIONID%TYPE
    );
    
-- CREATE CORRECT ANSWER
PROCEDURE CREATECORRECTANSWER(
        QOID CORRECTANSWER.QUESTIONOPTIONID%TYPE
    );
    
-- DELETE CORRECT ANSWER
PROCEDURE DELETECORRECTANSWER(CANSWERID CORRECTANSWER.ID%TYPE);

END CORRECTANSWERPACKAGE;