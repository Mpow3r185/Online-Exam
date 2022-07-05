-- Start Code

CREATE OR REPLACE PACKAGE ZoomMeetingPackage AS
    
    -- ZoomMeeting CRUD Operations
    PROCEDURE ZoomMeetingCRUD(
        func IN VARCHAR DEFAULT NULL,
        zoomId IN zoomMeeting.id%type DEFAULT NULL,
        link IN zoomMeeting.zoomLink%type DEFAULT NULL,
        exid IN zoomMeeting.examId%type DEFAULT NULL);
        
    -- Get Zoom Meeting By Exam Id
    PROCEDURE GetZoomMeetingByExamId(
        exid IN zoomMeeting.examId%type DEFAULT NULL);

END ZoomMeetingPackage;

-- End Code