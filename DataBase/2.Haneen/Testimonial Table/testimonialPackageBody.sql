create or replace PACKAGE BODY TestimonialPackage AS
    
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
        ELSIF func = 'UPDATE' THEN
            UPDATE Testimonial SET              
                Status = stat
            WHERE id = tstId;

            COMMIT;
        ELSIF func = 'DELETE' THEN
            DELETE From Testimonial WHERE id = tstId;

            COMMIT;
        ELSE
            OPEN ref_cursor FOR
            SELECT T.id ,T.accountId,T.message,T.status,A.userName,A.profilePicture,A.fullName
            FROM Testimonial T Join Account A
            on T.accountId = A.id;

            DBMS_SQL.RETURN_RESULT(ref_cursor);
        END IF;
    END TestimonialCRD;


END TestimonialPackage;

-- End Code
