-- Start Code


CREATE OR REPLACE PACKAGE BODY WebsiteDataPackage AS
    
    -- Update Website Data Procedure
    PROCEDURE UpdateWebsiteData(
        mail IN WebsiteData.email%type, 
        passw IN WebsiteData.password%type) AS
        
    BEGIN
        UPDATE WebsiteData SET
        email = mail,
        password = passw;
    END UpdateWebsiteData;
    
    -- Get Website Data Procedure
    PROCEDURE GetWebsiteData AS
        ref_cursor SYS_REFCURSOR;
    BEGIN
        OPEN ref_cursor FOR
        SELECT *
        FROM WebsiteData
        FETCH FIRST 1 ROWS ONLY;
        
        DBMS_SQL.RETURN_RESULT(ref_cursor);
    END GetWebsiteData;
    
END WebsiteDataPackage;

-- End Code