create or replace PACKAGE BODY CertificatePackage AS
    
    -- CRUD Procedures    
    PROCEDURE CertificateCRUD(
        func IN VARCHAR DEFAULT NULL,
        CertificateID IN Certificate.ID%type DEFAULT NULL,
        createDate IN Certificate.creatiodate%type DEFAULT NULL,
        exam_id IN Certificate.examid%type DEFAULT NULL,
        acc_id IN Certificate.accountid%type DEFAULT NULL) AS
        
        ref_cursor SYS_REFCURSOR;
    BEGIN
    -- Create 
        IF func = 'CREATE' THEN
            INSERT INTO Certificate
            (CreatioDate, ExamId, AccountId)
            VALUES(createDate, exam_id, acc_id);

        COMMIT;
    -- Update 
    ELSIF func = 'UPDATE' THEN
            UPDATE Certificate SET 
                CreatioDate = createDate,
                examid = exam_id,
                accountid = acc_id
            WHERE id = CertificateID;

            COMMIT;


    -- Delete 
    ELSIF func = 'DELETE' THEN
        DELETE from Certificate WHERE id = CertificateID;

        COMMIT;
    ELSE
    -- Get
        OPEN ref_cursor FOR
        SELECT *
        FROM Certificate;

        DBMS_SQL.RETURN_RESULT(ref_cursor);
    END IF;
END CertificateCRUD;
END CertificatePackage;
