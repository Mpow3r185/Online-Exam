CREATE OR REPLACE PACKAGE CertificatePackage AS
    
    -- CRUD Procedures
    -- Get Certificates Procedure
    PROCEDURE GetCertificates;
    
    -- Create Certificate Procedure
    PROCEDURE CreateCertificate(
        createDate IN Certificate.creatiodate%type,
        exam_id IN Certificate.examid%type,
        acc_id IN Certificate.accountid%type);
    
    -- Update Certificate Procedure
    PROCEDURE UpdateCertificate(
        CertificateID IN Certificate.ID%type,
        createDate IN Certificate.creatiodate%type,
        exam_id IN Certificate.examid%type,
        acc_id IN Certificate.accountid%type);
        
    -- Delete Certificate Procedure
    PROCEDURE DeleteCertificate(CertificateID IN Certificate.id%type);

END CertificatePackage;

