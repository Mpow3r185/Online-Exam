
/*
*
* * Our Service Package Body 
*
*/

CREATE OR REPLACE PACKAGE Body OurServicePackage AS
   --Body For Question CRUD operation
    PROCEDURE OurServiceCRUD(
                func IN VARCHAR DEFAULT NULL,
               Sid OurService.id%TYPE DEFAULT NULL, 
	       Stitle OurService.title%TYPE DEFAULT NULL,
	       Stext OurService.text%TYPE DEFAULT NULL) AS S_all sys_refcursor;
    BEGIN
        -- Create
        IF func = 'CREATE' THEN
            INSERT INTO OurService(Title, Text)
            VALUES (Stitle , Stext);
            COMMIT;
            
        -- Update    
        ELSIF func = 'UPDATE' THEN    
            UPDATE OurService SET Title = Stitle, Text=Stext
            WHERE Id = Sid;
            COMMIT;
           
        --Delete    
        ELSIF func = 'DELETE' THEN  
            DELETE OurService WHERE Id=Sid;
            COMMIT;
         
        -- Get All 
        ELSE    
            open S_all for
            select * from OurService;
            DBMS_SQL.RETURN_RESULT(S_all);
            
        END IF;
    END OurServiceCRUD;
    
END OurServicePackage;

