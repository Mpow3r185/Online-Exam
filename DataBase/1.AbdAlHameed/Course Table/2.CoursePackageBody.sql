-- Start Code

CREATE OR REPLACE PACKAGE BODY CoursePackage AS
    
    -- CRUD Procedures
    -- Get Courses Procedure
    PROCEDURE GetCourses AS
        ref_cursor SYS_REFCURSOR;
    BEGIN
        OPEN ref_cursor FOR
        SELECT *
        FROM Course;

        DBMS_SQL.RETURN_RESULT(ref_cursor);
    END GetCourses;

    -- Create Course Procedure
    PROCEDURE CreateCourse(
        cName IN Course.courseName%type,
        des IN Course.description%type,
        st IN Course.status%type,
        cImage IN Course.courseImage%type) AS 
    BEGIN
        INSERT INTO Course
        (courseName, description, status, courseimage)
        VALUES(cName, des, UPPER(st), cImage);

        commit;
    END CreateCourse;

    -- Update Course Procedure
    PROCEDURE UpdateCourse(
        cid IN Course.id%type,
        cName IN Course.courseName%type,
        des IN Course.description%type,
        st IN Course.status%type,
        cImage IN Course.courseImage%type) AS
        BEGIN
            UPDATE Course
            SET courseName = cName,
                description = des,
                status = UPPER(st),
                courseImage = cImage
            WHERE id = cid;

        commit;
        END UpdateCourse;

    -- Delete Course Procedure
    PROCEDURE DeleteCourse(cid IN Course.id%type) AS
    BEGIN
        DELETE FROM Course WHERE id = cid;

        commit;
    END DeleteCourse;
    -- CRUD Procedures

    -- Get Courses Names
    PROCEDURE GetCoursesNames AS
        ref_cursor SYS_REFCURSOR;
    BEGIN
        OPEN ref_cursor FOR
        SELECT courseName
        FROM Course;

        DBMS_SQL.RETURN_RESULT(ref_cursor);
    END GetCoursesNames;

    -- Search Course Procedure
    PROCEDURE SearchCourse(
        cid IN Course.id%type,
        cName IN Course.courseName%type) AS

        ref_cursor SYS_REFCURSOR;
    BEGIN
        OPEN ref_cursor FOR
        SELECT *
        FROM Course
        WHERE (cid IS NULL OR id = cid)
        AND (cName IS NULL OR courseName LIKE '%' || cName || '%');

        DBMS_SQL.RETURN_RESULT(ref_cursor);
    END SearchCourse;

END CoursePackage;

-- End Code