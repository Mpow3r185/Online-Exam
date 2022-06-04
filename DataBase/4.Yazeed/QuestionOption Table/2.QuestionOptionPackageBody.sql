/* 
*
* * QuestionOption Package Body
*
*/
CREATE OR REPLACE PACKAGE Body QuestionOptionPackage AS
    --Body For Get All QuestionOption
    PROCEDURE GetAllQuestionOption AS O_all sys_refcursor;
    BEGIN
        open O_all for
        select * from Questionoption;
        DBMS_SQL.RETURN_RESULT(O_all);
    END GetAllQuestionOption;

    --Body For Update QuestionOption
    PROCEDURE UpdateQuestionOption(Oid Questionoption.id%TYPE, OContent Questionoption.optioncontent%TYPE, OQuestionId Questionoption.questionid%TYPE) AS        
    BEGIN
    UPDATE Questionoption SET Optioncontent = OContent, Questionid=OQuestionId
    WHERE Id = Oid;
    COMMIT;
    END UpdateQuestionOption;

    --Body For Create QuestionOption
    PROCEDURE CreateQuestionOption(OContent Questionoption.optioncontent%TYPE, OQuestionId Questionoption.questionid%TYPE) AS
    BEGIN
    INSERT INTO Questionoption(Optioncontent, Questionid)
    VALUES (OContent , OQuestionId);
    COMMIT;
    END CreateQuestionOption;
    
    --Body For Delete QuestionOption
    PROCEDURE DeleteQuestionOption(Oid Questionoption.id%TYPE) AS
    BEGIN
    DELETE Questionoption WHERE Id=Oid;
    COMMIT;
    END DeleteQuestionOption;
    
END QuestionOptionPackage;