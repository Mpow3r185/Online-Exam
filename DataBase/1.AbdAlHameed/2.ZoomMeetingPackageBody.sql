-- Start Code

CREATE OR REPLACE PACKAGE BODY ZoomMeetingPackage AS
    
    -- ZoomMeeting CRUD Operations
    PROCEDURE ZoomMeetingCRUD(
        func IN VARCHAR DEFAULT NULL,
        zoomId IN zoomMeeting.id%type DEFAULT NULL,
        link IN zoomMeeting.zoomLink%type DEFAULT NULL,
        exid IN zoomMeeting.examId%type DEFAULT NULL) AS
        
        ref_cursor SYS_REFCURSOR;
    BEGIN
        IF func = 'CREATE' THEN
            INSERT INTO ZoomMeeting(zoomLink, examId) VALUES(link, exid);
            
        ELSIF func = 'UPDATE' THEN
            UPDATE ZoomMeeting SET
                zoomLink = link,
                examId = exid
            WHERE examId = exid;
        
            COMMIT;
        ELSIF func = 'DELETE' THEN
            DELETE ZoomMeeting WHERE id = zoomId;
            
            COMMIT;
        ELSE 
            OPEN ref_cursor FOR
            SELECT *
            FROM ZoomMeeting;
        
            DBMS_SQL.RETURN_RESULT(ref_cursor);
        END IF;
    END ZoomMeetingCRUD;
        
    -- Get Zoom Meeting By Exam Id
    PROCEDURE GetZoomMeetingByExamId(
        exid IN zoomMeeting.examId%type DEFAULT NULL) AS
        
        ref_cursor SYS_REFCURSOR;
    BEGIN
        OPEN ref_cursor FOR
        SELECT *
        FROM ZoomMeeting
        WHERE examId = exid;
    
        DBMS_SQL.RETURN_RESULT(ref_cursor);
    END GetZoomMeetingByExamId;

END ZoomMeetingPackage;

-- End Code