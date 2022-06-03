create or replace PACKAGE BODY ReportPackage AS

    -- Get Number of Users Procedure
    PROCEDURE NumOfUsers AS
        ref_cursor SYS_REFCURSOR;
    BEGIN
        OPEN ref_cursor FOR
        select count(*) "TotalUsers"
        from Account 
        where roleName='Student';

        DBMS_SQL.RETURN_RESULT(ref_cursor);
    END NumOfUsers;

    -- Get Total exam's cost for all Courses Procedure
    PROCEDURE TotalCost AS
        ref_cursor SYS_REFCURSOR;
    BEGIN
        OPEN ref_cursor FOR
        select SUM(COST) "TotalCost"
        from Exam ;

        DBMS_SQL.RETURN_RESULT(ref_cursor);
    END TotalCost;    

    -- Get Total exam's cost by CourseName Procedure
    PROCEDURE TotalExamsCostByCourseName(cName IN Course.courseName%type) AS
         ref_cursor SYS_REFCURSOR;
    BEGIN
        OPEN ref_cursor FOR
        select SUM(Cost) "TotalCost"
        from Exam e 
        join Course c
        on e.courseId = c.id
        where c.courseName= cName;

        DBMS_SQL.RETURN_RESULT(ref_cursor);
    END TotalExamsCostByCourseName;


    -- Get Number of users by CourseName Procedure    
    PROCEDURE GetNumOfUsersByCourseName(cName IN Course.courseName%type) As
        ref_cursor SYS_REFCURSOR;
    BEGIN
        OPEN ref_cursor FOR
        select count(*) "TotalUsers"
        from Account a 
        join Invoice i 
        on a.id = i.accountId

        join Exam e
        on e.id = i.examId

        join Course c
        on e.courseId = c.id

        where c.courseName= cName;

        DBMS_SQL.RETURN_RESULT(ref_cursor);
    END GetNumOfUsersByCourseName;  

    -- Get Number of users by ExamName Procedure
    PROCEDURE GetNumOfUsersByExamName(eName IN Exam.title%TYPE) As
        ref_cursor SYS_REFCURSOR;
    BEGIN
        OPEN ref_cursor FOR
        select count(*) "TotalUsers"
        from Account a 
        join Invoice i 
        on a.id = i.accountId

        join Exam e
        on e.id = i.examId

        where e.title= eName;

        DBMS_SQL.RETURN_RESULT(ref_cursor);
    END GetNumOfUsersByExamName; 

    -- Get Number of Certificates
    PROCEDURE GetNumOfCertificate As
        ref_cursor SYS_REFCURSOR;
    BEGIN
        OPEN ref_cursor FOR
        select count(*) "TotalUsers"
        from Certificate;

        DBMS_SQL.RETURN_RESULT(ref_cursor);
    END GetNumOfCertificate;


End ReportPackage;