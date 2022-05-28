CREATE OR REPLACE PACKAGE BODY CertificatePackage AS
    
    -- CRUD Procedures
    -- Get Certificates Procedure
    PROCEDURE GetCertificates AS
        ref_cursor SYS_REFCURSOR;
    BEGIN
        OPEN ref_cursor FOR
        SELECT *
        FROM Certificate;
        
        DBMS_SQL.RETURN_RESULT(ref_cursor);
    END GetCertificates;
    
    -- Create Certificate Procedure
    PROCEDURE CreateCertificate(
        createDate IN Certificate.creatiodate%type,
        exam_id IN Certificate.examid%type,
        acc_id IN Certificate.accountid%type) AS
        BEGIN
            INSERT INTO Certificate
            (CreatioDate, ExamId, AccountId)
            VALUES(createDate, exam_id, acc_id);
        commit;
        END CreateCertificate;
    
    -- Update Certificate Procedure
    PROCEDURE UpdateCertificate(
        CertificateID IN Certificate.ID%type,
        createDate IN Certificate.creatiodate%type,
        exam_id IN Certificate.examid%type,
        acc_id IN Certificate.accountid%type) AS
        BEGIN
            UPDATE Certificate SET 
                CreatioDate = createDate,
                examid = exam_id,
                accountid = acc_id
               
            WHERE id = CertificateID;
            commit;
        END UpdateCertificate;
        
    -- Delete Certificate Procedure
    PROCEDURE DeleteCertificate(CertificateID IN Certificate.id%type) AS
    BEGIN
        DELETE from Certificate WHERE id = CertificateID;
        commit;
END DeleteCertificate;
END CertificatePackage;