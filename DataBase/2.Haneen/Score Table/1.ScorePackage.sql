create or replace PACKAGE SCOREPACKAGE AS
-- Score CRUD Operations
PROCEDURE ScoreCRUD(
    func IN VARCHAR DEFAULT NULL,
    SCOREID SCORE.ID%TYPE DEFAULT NULL,
    SCGRADE SCORE.GRADE%TYPE DEFAULT NULL,
    SCSTATUS SCORE.STATUS%TYPE DEFAULT NULL,
    SCCreateDate SCORE.creationDate%type DEFAULT NULL,
    EXID SCORE.EXAMID%TYPE DEFAULT NULL,
    ACCID SCORE.ACCOUNTID%TYPE DEFAULT NULL);

    -- Calculate Score Procedure
    PROCEDURE CalculateScore(
        accid IN account.id%type,
        exid IN exam.id%type);
        
    -- Get Score By Exam Id And Account Id
    PROCEDURE GetScoreByExamIdAndAccountId(
        accid IN account.id%type,
        exid IN exam.id%type);

END SCOREPACKAGE;