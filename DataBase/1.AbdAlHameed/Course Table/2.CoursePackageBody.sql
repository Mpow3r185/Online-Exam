-- Start Code

CREATE OR REPLACE PACKAGE BODY CoursePackage AS
    
    -- Course CRUD Operations
    PROCEDURE CourseCRUD(
        func IN VARCHAR DEFAULT NULL,
        cid IN Course.id%type DEFAULT NULL,
        cName IN Course.courseName%type DEFAULT NULL,
        des IN Course.description%type DEFAULT NULL,
        st IN Course.status%type DEFAULT NULL,
        cImage IN Course.courseImage%type DEFAULT NULL) AS
        
        ref_cursor SYS_REFCURSOR;
    BEGIN
        IF func = 'CREATE' THEN
            INSERT INTO Course
            (courseName, description, status, courseimage)
            VALUES(cName, des, UPPER(st), cImage);

            COMMIT;
        ELSIF func = 'UPDATE' THEN
            UPDATE Course
            SET courseName = cName,
                description = des,
                status = UPPER(st),
                courseImage = cImage
            WHERE id = cid;

            COMMIT;
        ELSIF func = 'DELETE' THEN
            DELETE FROM Course WHERE id = cid;

            COMMIT;
        ELSE
            OPEN ref_cursor FOR
            SELECT *
            FROM Course;
    
            DBMS_SQL.RETURN_RESULT(ref_cursor);
        END IF;
    
    END CourseCRUD;
    
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
        cid IN Course.id%type DEFAULT NULL,
        cName IN Course.courseName%type DEFAULT NULL) AS

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