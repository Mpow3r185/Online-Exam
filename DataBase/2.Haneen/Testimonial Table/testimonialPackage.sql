-- Start Code

CREATE OR REPLACE PACKAGE BODY TestimonialPackage AS
    
    -- Testimonial CRD Operations
    PROCEDURE TestimonialCRD(
        func IN VARCHAR DEFAULT NULL,
        tstId IN Testimonial.id%type DEFAULT NULL,
        accid IN Testimonial.accountId%type DEFAULT NULL,
        msg IN Testimonial.Message%type DEFAULT NULL,
        stat IN Testimonial.status%type DEFAULT NULL) AS
        
        ref_cursor SYS_REFCURSOR;
    BEGIN
        IF func = 'CREATE' THEN
            INSERT INTO Testimonial
            (accountId, Message, status)
            VALUES(accid, msg,stat);

            COMMIT;            
        
        ELSIF func = 'DELETE' THEN
            DELETE From Testimonial WHERE id = tstId;

            COMMIT;
        ELSE
            OPEN ref_cursor FOR
            SELECT *
            FROM Testimonial;
            
            DBMS_SQL.RETURN_RESULT(ref_cursor);
        END IF;
    END TestimonialCRD;

   
END TestimonialPackage;

-- End Code








