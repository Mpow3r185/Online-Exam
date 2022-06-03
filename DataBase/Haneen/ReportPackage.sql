create or replace PACKAGE ReportPackage AS
    
    -- Get NumOfUsers Procedure
    PROCEDURE NumOfUsers;

    -- Get Total exam's cost for all Courses Procedure
    PROCEDURE TotalCost;

    -- Get Total exam's cost by CourseName Procedure
    PROCEDURE TotalExamsCostByCourseName(cName IN Course.courseName%type);

    -- Get Number of users by CourseName Procedure
    PROCEDURE GetNumOfUsersByCourseName(cName IN Course.courseName%type);

    -- Get Number of users by ExamName Procedure
    PROCEDURE GetNumOfUsersByExamName(eName IN Exam.title%TYPE);

    -- Get Number of Certificates
    PROCEDURE GetNumOfCertificate ;
    
END ReportPackage;