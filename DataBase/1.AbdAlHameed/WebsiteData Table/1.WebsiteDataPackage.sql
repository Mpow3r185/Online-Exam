-- Start Code

CREATE OR REPLACE PACKAGE WebsiteDataPackage AS
    
    -- Update Website Data Procedure
    PROCEDURE UpdateWebsiteData(
        mail IN WebsiteData.email%type, 
        passw IN WebsiteData.password%type);
        
    -- Get Website Data Procedure
    PROCEDURE GetWebsiteData;
        
END WebsiteDataPackage;    


-- End Code