create or replace PACKAGE CertificatePackage AS
    
    -- CRUD Procedures
    PROCEDURE CertificateCRUD(
        func IN VARCHAR DEFAULT NULL,
        CertificateID IN Certificate.ID%type DEFAULT NULL,
        createDate IN Certificate.creatiodate%type DEFAULT NULL,
        exam_id IN Certificate.examid%type DEFAULT NULL,
        acc_id IN Certificate.accountid%type DEFAULT NULL);

    --Get Certificate
    PROCEDURE getCertificateByUserId(uid IN account.id%type DEFAULT NULL);

END CertificatePackage;
