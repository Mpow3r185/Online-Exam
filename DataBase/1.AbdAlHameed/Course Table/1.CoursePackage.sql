-- Start Code

CREATE OR REPLACE PACKAGE CoursePackage AS
    
    -- Course CRUD Operations
    PROCEDURE CourseCRUD(
        func IN VARCHAR DEFAULT NULL,
        cid IN Course.id%type DEFAULT NULL,
        cName IN Course.courseName%type DEFAULT NULL,
        des IN Course.description%type DEFAULT NULL,
        st IN Course.status%type DEFAULT NULL,
        cImage IN Course.courseImage%type DEFAULT NULL);

    -- Get Courses Names
    PROCEDURE GetCoursesNames;

    -- Search Course Procedure
    PROCEDURE SearchCourse(
        cid IN Course.id%type DEFAULT NULL,
        cName IN Course.courseName%type DEFAULT NULL);

    -- Get Courses Sorted By Number Of Registrants
    PROCEDURE GetPopularCourses;

    -- Get Course By Id
    PROCEDURE GetCourseById(cid IN Course.id%type);

END CoursePackage;

-- End Code