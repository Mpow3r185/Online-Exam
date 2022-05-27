-- Start Code

CREATE OR REPLACE PACKAGE CoursePackage AS
    
    -- CRUD Procedures
    -- Get Courses Procedure
    PROCEDURE GetCourses;
    
    -- Create Course Procedure
    PROCEDURE CreateCourse(
        cName IN Course.courseName%type,
        des IN Course.description%type,
        st IN Course.status%type,
        cImage IN Course.courseImage%type);
    
    -- Update Course Procedure
    PROCEDURE UpdateCourse(
        cid IN Course.id%type,
        cName IN Course.courseName%type,
        des IN Course.description%type,
        st IN Course.status%type,
        cImage IN Course.courseImage%type);
    
    -- Delete Course Procedure
    PROCEDURE DeleteCourse(cid IN Course.id%type);
    -- CRUD Procedures
    
    -- Get Courses Names
    PROCEDURE GetCoursesNames;
    
    -- Get Course By Course Id
    PROCEDURE GetCourseById(cid IN Course.id%type);
    
    -- Search Course By Name
    PROCEDURE GetCourseByName(cName IN Course.courseName%type);
    
END CoursePackage;

-- End Code